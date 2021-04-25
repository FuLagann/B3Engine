
using B3.Graphics.VertexStructures;

namespace B3.Graphics {
	// TODO: Change this to internal
	/// <summary>An internal class for creating the opengl renderer</summary>
	public sealed class OpenGLRenderer : Renderer {
		#region Public Constructors
		
		/// <summary>A base constructor for creating the OpenGL implementation of a renderer</summary>
		/// <param name="game">The game used for setting up the batcher</param>
		public OpenGLRenderer(IGame game) : base(
			game,
			new PointBatcher<Vertex3PC>(
				new VertexArray<Vertex3PC>(
					game,
					new VertexBuffer<Vertex3PC>(
						game,
						null,
						BufferUsage.DynamicDraw
					),
					RenderType.Points
				)
			),
			new LineBatcher<Vertex3PC>(
				new VertexArray<Vertex3PC>(
					game,
					new VertexBuffer<Vertex3PC>(
						game,
						null,
						BufferUsage.DynamicDraw
					),
					RenderType.Lines
				)
			),
			new TriangleBatcher<Vertex3PCTN>(
				new Mesh<Vertex3PCTN>(
					game,
					new VertexBuffer<Vertex3PCTN>(
						game, 
						null,
						BufferUsage.DynamicDraw
					),
					new IndexBuffer(
						game,
						null,
						BufferUsage.DynamicDraw
					),
					RenderType.Triangles
				)
			)
		) {}
		
		#endregion // Public Constructors
	}
}
