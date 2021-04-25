
namespace B3.Graphics {
	/// <summary>An abstract class that helps renders</summary>
	public abstract class Renderer : IRenderable {
		#region Field Variables
		// Variables
		/// <summary>The point shader program used for the point batcher</summary>
		protected IShaderProgram pointProgram;
		/// <summary>The line shader program used for the line batcher</summary>
		protected IShaderProgram lineProgram;
		/// <summary>The triangle shader program used for the triangle batcher</summary>
		protected IShaderProgram triangleProgram;
		private IGame game;
		private IBatcher<Vertex3PC> pointBatcher;
		private IBatcher<Vertex3PC> lineBatcher;
		private IBatcher<Vertex3PCTN> triangleBatcher;
		private static Renderer instance;
		
		#endregion // Field Variables
		
		#region Public Properties
		
		/// <summary>Gets the game the renderer uses</summary>
		public IGame Game { get; }
		
		/// <summary>Gets and sets the point shader program</summary>
		public IShaderProgram PointShaderProgram { get { return this.pointProgram; } set {
			if(this.pointProgram == value) { return; }
			
			this.FlushPointBatcher();
			this.pointProgram = value;
		} }
		
		/// <summary>Gets and sets the line shader program</summary>
		public IShaderProgram LineShaderProgram { get { return this.lineProgram; } set {
			if(this.lineProgram == value) { return; }
			
			this.FlushLineBatcher();
			this.lineProgram = value;
		} }
		
		/// <summary>Gets and sets the triangle (mesh) shader program</summary>
		public IShaderProgram MeshShaderProgram { get { return this.triangleProgram; } set {
			if(this.triangleProgram == value) { return; }
			
			this.FlushTriangleBatcher();
			this.triangleProgram = value;
		} }
		
		#endregion // Public Properties
		
		#region Public Static Properties
		
		/// <summary>Gets the renderer from the engine that helps in rendering things</summary>
		public static Renderer Instance { get { return instance; } }
		
		#endregion // Public Static Properties
		
		#region Public Constructors
		
		/// <summary>A base constructor for setting up the renderer</summary>
		/// <param name="game">The game used for getting the basic premade shader programs</param>
		/// <param name="pointBatcher">The point batcher to be used by the renderer</param>
		/// <param name="lineBatcher">The line batcher to be used by the renderer</param>
		/// <param name="triangleBatcher">The triangle batcher to be used by the renderer</param>
		protected Renderer(
			IGame game,
			IBatcher<Vertex3PC> pointBatcher,
			IBatcher<Vertex3PC> lineBatcher,
			IBatcher<Vertex3PCTN> triangleBatcher
		) {
			Renderer.instance = this;
			this.game = game;
			this.pointBatcher = pointBatcher;
			this.lineBatcher = lineBatcher;
			this.triangleBatcher = triangleBatcher;
		}
		
		#endregion // Public Constructors
		
		#region Public Methods
		
		/// <summary>Renders the object</summary>
		public void Render() {
			this.FlushPointBatcher();
			this.FlushLineBatcher();
			this.FlushTriangleBatcher();
		}
		
		/// <summary>Renders and flushes out the point batcher </summary>
		public void FlushPointBatcher() {
			if(this.pointBatcher.Count == 0) { return; }
			
			if(this.pointProgram != null) {
				this.pointProgram.Use();
				this.game.GlobalSetUniforms(this.pointProgram);
			}
			this.pointBatcher.Flush();
		}
		
		/// <summary>Renders and flushes out the line batcher </summary>
		public void FlushLineBatcher() {
			if(this.lineBatcher.Count == 0) { return; }
			
			if(this.lineProgram != null) {
				this.lineProgram.Use();
				this.game.GlobalSetUniforms(this.lineProgram);
			}
			this.lineBatcher.Flush();
		}
		
		/// <summary>Renders and flushes out the triangle batcher </summary>
		public void FlushTriangleBatcher() {
			if(this.triangleBatcher.Count == 0) { return; }
			
			if(this.triangleProgram != null) {
				this.triangleProgram.Use();
				this.game.GlobalSetUniforms(this.triangleProgram);
			}
			this.triangleBatcher.Flush();
		}
		
		/// <summary>Batches the given point</summary>
		/// <param name="point">The point to batch</param>
		public void Batch(IConvertable<Vertex3PC> point) {
			// Variables
			Vertex3PC convPoint = point.Convert();
			
			this.pointBatcher.Batch(ref convPoint);
		}
		
		/// <summary>Batches the given line</summary>
		/// <param name="segA">The first point that forms the line segment</param>
		/// <param name="segB">The second point that forms the line segment</param>
		public void Batch(IConvertable<Vertex3PC> segA, IConvertable<Vertex3PC> segB) {
			// Variables
			Vertex3PC convA = segA.Convert();
			Vertex3PC convB = segB.Convert();
			
			this.lineBatcher.Batch(ref convA, ref convB);
		}
		
		/// <summary>Batches the given triangle</summary>
		/// <param name="triA">The first point that forms the triangle</param>
		/// <param name="triB">The second point that forms the triangle</param>
		/// <param name="triC">The third point that forms the triangle</param>
		public void Batch(IConvertable<Vertex3PCTN> triA, IConvertable<Vertex3PCTN> triB, IConvertable<Vertex3PCTN> triC) {
			// Variables
			Vertex3PCTN convA = triA.Convert();
			Vertex3PCTN convB = triB.Convert();
			Vertex3PCTN convC = triC.Convert();
			
			this.triangleBatcher.Batch(ref convA, ref convB, ref convC);
		}
		
		#endregion // Public Methods
	}
}
