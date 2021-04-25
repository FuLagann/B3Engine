
using B3.Events;
using B3.Graphics.VertexStructures;

using OpenTK.Graphics.OpenGL;

namespace B3.Graphics {
	/// <summary>A class for a frame buffer that does post-processing effects and creates a rendering target</summary>
	public sealed class FrameBuffer : IFrameBuffer {
		#region Field Variables
		// Variables
		private int handle;
		private int renderBufferHandle;
		private Texture2D renderTexture;
		private EventArgs args;
		private VertexArray<Vertex2PT> vao;
		private IShaderProgram program;
		
		#endregion // Field Variables
		
		#region Properties
		
		/// <summary>Gets and sets the level of MSAA (used for anti-aliasing)</summary>
		public int MsaaLevel { get; set; }
		
		/// <summary>Gets and sets the width of the frame buffer, typically set by the window's width</summary>
		public int Width { get; set; }
		
		/// <summary>Gets and sets the height of the frame buffer, typically set by the window's height</summary>
		public int Height { get; set; }
		
		/// <summary>Gets the render texture created by the frame buffer</summary>
		public ITexture RenderTexture { get { return this.renderTexture; } }
		
		/// <summary>Gets the id handle of the buffer that gets generated and used by the graphics library</summary>
		public int Handle { get { return this.handle; } }
		
		/// <summary>Gets and sets the shader program being used</summary>
		public IShaderProgram Program { get; set; }
		
		#endregion // Properties
		
		#region Public Events
		
		/// <summary>An event for when the frame gets rendered; anything in this event will get rendered into the frame buffer instead</summary>
		public event EventHandler<EventArgs> OnRender;
		
		#endregion // Public Events
		
		#region Public Constructors
		
		/// <summary>A base constructor for creating a frame buffer, defining the width and height manually</summary>
		/// <param name="game">The game used to make sure OpenGL was loaded in correctly</param>
		/// <param name="width">The width of the frame buffer to create the render texture with</param>
		/// <param name="height">The height of the frame buffer to create the render texture with</param>
		/// <param name="msaaLevel">The level of anti-aliasing used</param>
		public FrameBuffer(IGame game, int width, int height, int msaaLevel) {
			this.Width = width;
			this.Height = height;
			this.MsaaLevel = msaaLevel;
			this.args = new EventArgs(this);
			if(game == null || game.IsWindowInitialized) {
				this.Initialize(game, width, height);
			}
			else {
				game.OnLoad += () => {
					this.Initialize(game, width, height);
				};
			}
		}
		
		/// <summary>A constructor for creating a frame buffer, defining the width and height dynamically using the game</summary>
		/// <param name="game">The game used to make sure OpenGL was loaded in correctly</param>
		/// <param name="msaaLevel">The level of anti-aliasing used</param>
		public FrameBuffer(IGame game, int msaaLevel) : this(game, (int)game.Window.Size.x, (int)game.Window.Size.y, msaaLevel) {}
		
		#endregion // Public Constructors
		
		#region Public Methods
		
		/// <summary>Binds the buffer to use</summary>
		public void Bind() { GL.BindFramebuffer(FramebufferTarget.Framebuffer, this.handle); }
		
		/// <summary>Buffers the data</summary>
		public void Buffer() {}
		
		/// <summary>Renders the object</summary>
		public void Render() {
			this.Bind();
			GL.Enable(EnableCap.DepthTest);
			GL.ClearColor(
				0.1f, 0.1f, 1.0f, 1.0f
			);
			GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
			this.OnRender?.Invoke(this.args);
			
			GL.BindFramebuffer(FramebufferTarget.Framebuffer, 0);
			GL.Disable(EnableCap.DepthTest);
			GL.ClearColor(1.0f, 0.0f, 1.0f, 1.0f);
			GL.Clear(ClearBufferMask.ColorBufferBit);
			this.program.Use();
			this.vao.Render();
			// this.program.Use();
			// this.vao.Bind();
			// GL.BindTexture(TextureTarget.Texture2D, this.renderTexture.Handle);
			// GL.DrawArrays(PrimitiveType.Triangles, 0, 6);
		}
		
		/// <summary>Disposes the frame buffer</summary>
		public void Dispose() { GL.DeleteFramebuffer(this.handle); }
		
		#endregion // Public Methods
		
		#region Private Methods
		
		/// <summary>Initializes the frame buffer by creating a render texture</summary>
		/// <param name="game">The game used to make sure OpenGL was loaded in correctly</param>
		/// <param name="width">The width of the frame buffer</param>
		/// <param name="height">The height of the frame buffer</param>
		private void Initialize(IGame game, int width, int height) {
			// Variables
			string vertexCode = @"#version 330 core
layout (location = 0) in vec2 aPos;
layout (location = 1) in vec2 aTexCoord;

out vec2 TexCoords;

void main()
{
    gl_Position = vec4(aPos.x, aPos.y, 0.0, 1.0); 
    TexCoords = aTexCoord;
}";
			string fragmentCode = @"#version 330 core
out vec4 FragColor;
  
in vec2 TexCoords;

uniform sampler2D screenTexture;

const float offset = 1.0 / 300.0;  

void main()
{
    vec2 offsets[9] = vec2[](
        vec2(-offset,  offset), // top-left
        vec2( 0.0f,    offset), // top-center
        vec2( offset,  offset), // top-right
        vec2(-offset,  0.0f),   // center-left
        vec2( 0.0f,    0.0f),   // center-center
        vec2( offset,  0.0f),   // center-right
        vec2(-offset, -offset), // bottom-left
        vec2( 0.0f,   -offset), // bottom-center
        vec2( offset, -offset)  // bottom-right    
    );

    float kernel[9] = float[](
		1, 1, 1,
		1, -8, 1,
		1, 1, 1 
	);
    
    vec3 sampleTex[9];
    for(int i = 0; i < 9; i++)
    {
        sampleTex[i] = vec3(texture(screenTexture, TexCoords.st + offsets[i]));
    }
    vec3 col = vec3(0.0);
    for(int i = 0; i < 9; i++)
        col += sampleTex[i] * kernel[i];
    
    FragColor = vec4(col, 1.0);
}  ";
			Logger.Log($"{width},{height}");
			this.handle = GL.GenFramebuffer();
			this.Bind();
			this.renderTexture = Texture2D.CreateEmpty(game, width, height);
			
			GL.FramebufferTexture2D(FramebufferTarget.Framebuffer, FramebufferAttachment.ColorAttachment0, TextureTarget.Texture2D, this.renderTexture.Handle, 0);
			//GL.BindTexture(TextureTarget.Texture2D, 0);
			
			this.renderBufferHandle = GL.GenRenderbuffer();
			GL.BindRenderbuffer(RenderbufferTarget.Renderbuffer, this.renderBufferHandle);
			GL.RenderbufferStorage(RenderbufferTarget.Renderbuffer, RenderbufferStorage.Depth24Stencil8, width, height);
			GL.FramebufferRenderbuffer(FramebufferTarget.Framebuffer, FramebufferAttachment.DepthAttachment, RenderbufferTarget.Renderbuffer, this.renderBufferHandle);
			//GL.BindRenderbuffer(RenderbufferTarget.Renderbuffer, 0);
			GL.BindFramebuffer(FramebufferTarget.Framebuffer, 0);
			
			this.program = new ShaderProgram(
				null,
				new Shader(null, ShaderType.Vertex, vertexCode),
				new Shader(null, ShaderType.Fragment, fragmentCode)
			);
			this.program.OnUse += delegate(EventArgs args) {
				this.vao.Bind();
				this.program.SendUniform("screenTexture", this.renderTexture, 0);
			};
			
			this.vao = new VertexArray<Vertex2PT>(game, new VertexBuffer<Vertex2PT>(
				game, new Vertex2PT[] {
					new Vertex2PT(new Vector2(-1.0f, 1.0f), new Vector2(0.0f, 1.0f)),
					new Vertex2PT(new Vector2(-1.0f, -1.0f), new Vector2(0.0f, 0.0f)),
					new Vertex2PT(new Vector2(1.0f, -1.0f), new Vector2(1.0f, 0.0f)),
					
					new Vertex2PT(new Vector2(-1.0f, 1.0f), new Vector2(0.0f, 1.0f)),
					new Vertex2PT(new Vector2(1.0f, -1.0f), new Vector2(1.0f, 0.0f)),
					new Vertex2PT(new Vector2(1.0f, 1.0f), new Vector2(1.0f, 1.0f))
				}, BufferUsage.StaticDraw
			));
			this.vao.Bind();
			this.vao.Buffer();
		}
		
		#endregion // Private Methods
	}
}
