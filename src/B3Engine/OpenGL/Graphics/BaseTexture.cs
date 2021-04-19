
using B3.Events;

using OpenTK.Graphics.OpenGL;

namespace B3.Graphics {
	/// <summary>A base class for textures</summary>
	public abstract class BaseTexture : ITexture {
		#region Field Variables
		// Variables
		private int handle;
		private TextureType type;
		
		#endregion // Field Variables
		
		#region Public Properties
		
		/// <summary>Gets the id handle of the buffer that gets generated and used by the graphics library</summary>
		public int Handle { get { return this.handle; } }
		
		/// <summary>Gets the type of texture that the texture is</summary>
		public TextureType Target { get { return this.type; } }
		
		/// <summary>Gets and sets the parameters of the texture</summary>
		public TexParam Parameters { get; set; }
		
		#endregion // Public Properties
		
		#region Public Constructors
		
		/// <summary>A base constructor for the base texture</summary>
		/// <param name="game">The game used to make sure OpenGL was loaded in correctly</param>
		/// <param name="location">The location of the file to get the texture from</param>
		/// <param name="type">The type of texture used for rendering</param>
		protected BaseTexture(IGame game, string location, TextureType type) {
			this.Parameters = new TexParam();
			this.type = type;
			if(game == null || game.IsWindowInitialized) {
				this.handle = GL.GenTexture();
				this.Initialize(location);
			}
			else {
				game.OnLoad += () => {
					this.handle = GL.GenTexture();
					this.Initialize(location);
				};
			}
		}
		
		#endregion // Public Constructors
		
		#region Public Methods
		
		/// <summary>Sets the texture from the given file</summary>
		/// <param name="location">The location of the file</param>
		public abstract void SetFromFile(string location);
		
		/// <summary>Binds the buffer to use</summary>
		public virtual void Bind() { GL.BindTexture(this.type.ToOpenGL(), this.handle); }
		
		/// <summary>Binds the texture and activates it into any of the 32 slots used by the graphics library</summary>
		/// <param name="index">The index of the texture reserved by the graphics library to bind to</param>
		/// <remarks>The maximum index is 31, it loops around afterwards)</remarks>
		public void Bind(byte index) {
			// Variables
			int unit = (int)TextureUnit.Texture0 + (int)(index % 32);
			GL.ActiveTexture((TextureUnit)unit);
			this.Bind();
		}
		
		/// <summary>Buffers the data</summary>
		public virtual void Buffer() {
			// Variables
			TextureTarget target = this.type.ToOpenGL();
			
			GL.TexParameter(target, TextureParameterName.TextureWrapS, (int)this.Parameters.wrapS);
			GL.TexParameter(target, TextureParameterName.TextureWrapT, (int)this.Parameters.wrapT);
			GL.TexParameter(target, TextureParameterName.TextureMinFilter, (int)this.Parameters.minFilter);
			GL.TexParameter(target, TextureParameterName.TextureMagFilter, (int)this.Parameters.magFilter);
			if(this.Parameters.baseLevel.HasValue) { GL.TexParameter(target, TextureParameterName.TextureBaseLevel, this.Parameters.baseLevel.Value); }
			if(this.Parameters.lodBias.HasValue) { GL.TexParameter(target, TextureParameterName.TextureLodBias, this.Parameters.lodBias.Value); }
			if(this.Parameters.maxLevel.HasValue) { GL.TexParameter(target, TextureParameterName.TextureMaxLevel, this.Parameters.maxLevel.Value); }
			if(this.Parameters.maxLOD.HasValue) { GL.TexParameter(target, TextureParameterName.TextureMaxLod, this.Parameters.maxLOD.Value); }
			if(this.Parameters.minLOD.HasValue) { GL.TexParameter(target, TextureParameterName.TextureMinLod, this.Parameters.minLOD.Value); }
			if(this.Parameters.wrapR.HasValue) { GL.TexParameter(target, TextureParameterName.TextureWrapR, (int)this.Parameters.wrapR.Value); }
		}
		
		/// <summary>Disposes of the texture</summary>
		public virtual void Dispose() { GL.DeleteTexture(this.handle); }
		
		#endregion // Public Methods
		
		#region Protected Methods
		
		/// <summary>Initializes the texture</summary>
		/// <param name="location">The location of the file to the texture being used</param>
		protected abstract void Initialize(string location);
		
		#endregion // Protected Methods
	}
}
