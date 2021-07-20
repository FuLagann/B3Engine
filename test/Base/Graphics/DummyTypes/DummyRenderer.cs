
using B3.Graphics.VertexStructures;

namespace B3.Graphics.Testing {
	public sealed class DummyRenderer : Renderer {
		#region Public Constructors
		
		public DummyRenderer() : base(
			null,
			new PointBatcher<Vertex3PC>(
				new DummyVertexArray<Vertex3PC>(
					new DummyVertexBuffer<Vertex3PC>(null, BufferUsage.DynamicDraw),
					RenderType.Points
				)
			),
			new LineBatcher<Vertex3PC>(
				new DummyVertexArray<Vertex3PC>(
					new DummyVertexBuffer<Vertex3PC>(null, BufferUsage.DynamicDraw),
					RenderType.Lines
				)
			),
			new TriangleBatcher<Vertex3PCTN>(
				new DummyMesh<Vertex3PCTN>(
					new DummyVertexBuffer<Vertex3PCTN>(null, BufferUsage.DynamicDraw),
					new DummyIndexBuffer(null, BufferUsage.DynamicDraw),
					RenderType.Triangles
				)
			)
		) {}
		
		#endregion // Public Constructors
	}
}
