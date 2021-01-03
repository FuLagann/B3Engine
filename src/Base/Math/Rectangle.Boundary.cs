
using B3.Graphics;

namespace B3 {
	public partial struct Rectangle : IBoundary {
		#region Public Methods
		
		/// <summary>Finds if the point is contained within the boundary</summary>
		/// <param name="point">The point used to find if it contained within the boundary</param>
		/// <returns>Returns true if the point is contained within the boundary</returns>
		public bool Contains(Vector2 point) {
			return (
				point.x >= this.x && point.x <= this.x + this.width &&
				point.y >= this.y && point.y <= this.y + this.height
			);
		}
		
		/// <summary>Finds if the point is contained within the boundary</summary>
		/// <param name="point">The point used to find if it contained within the boundary</param>
		/// <returns>Returns true if the point is contained within the boundary</returns>
		public bool Contains(Vector3 point) { return this.Contains((Vector2)point); }
		
		/// <summary>Finds if the ray is intersecting the boundary</summary>
		/// <param name="ray">The ray to find if it intersects with the boundary</param>
		/// <returns>Returns the information pertaining to the intersection</returns>
		public IntersectionInfo Intersects(Ray ray) {
			// Variables
			Box box = new Box(this.x, this.y, 0.0f, this.width, this.height, 0.0f);
			
			return box.Intersects(ray);
		}
		
		/// <summary>Renders the object when debugging mode is on</summary>
		/// <param name="game">The reference to the game, used to get to the RenderingContext</param>
		public void DebugRender(IGame game) { this.DebugRender(game, game.ShaderHelper.DefaultLineShaderProgram); }
		
		/// <summary>Renders the object when debugging mode is on using a specific shader program</summary>
		/// <param name="game">The reference to the game, used to get to the RenderingContext</param>
		/// <param name="program">The shading program used</param>
		public void DebugRender(IGame game, IShaderProgram program) {
			// Variables
			ILineBatcher batcher = game.RenderHelper.GetBatcher(BatcherType.Lines) as ILineBatcher;
			float left = this.Left;
			float top = this.Top;
			float right = this.Right;
			float bottom = this.Bottom;
			
			batcher.Color = Color.Red;
			batcher.AddLines(new Vector3[] {
				new Vector3(left, top, 0.0f),
				new Vector3(right, top, 0.0f),
				new Vector3(right, bottom, 0.0f),
				new Vector3(left, bottom, 0.0f)
			});
		}
		
		#endregion // Public Methods
	}
}
