
using B3.Graphics;

namespace B3 {
	public partial struct Circle : IBoundary {
		#region Public Methods
		
		/// <summary>Finds if the point is contained within the boundary</summary>
		/// <param name="point">The point used to find if it contained within the boundary</param>
		/// <returns>Returns true if the point is contained within the boundary</returns>
		public bool Contains(Vector2 point) {
			// Variables
			Vector2 temp;
			float magnitude;
			
			Mathx.Subtract(ref point, ref this.center, out temp);
			magnitude = temp.Magnitude;
			
			return (magnitude <= this.radius);
		}
		
		/// <summary>Finds if the point is contained within the boundary</summary>
		/// <param name="point">The point used to find if it contained within the boundary</param>
		/// <returns>Returns true if the point is contained within the boundary</returns>
		public bool Contains(Vector3 point) { return this.Contains((Vector2)point); }
		
		/// <summary>Finds if the ray is intersecting the boundary</summary>
		/// <param name="ray">The ray to find if it intersects with the boundary</param>
		/// <returns>Returns the information pertaining to the intersection</returns>
		public IntersectionInfo Intersects(Ray ray) {
			if(Mathx.Approx(ray.Origin.z, ray.Direction.z) && Mathx.Approx(ray.Origin.z, 0.0f)) {
				// Variables
				Sphere sphere = new Sphere(this.center.x, this.center.y, 0.0f, this.radius);
				
				return sphere.Intersects(ray);
			}
			
			// Variables
			IntersectionInfo info = new IntersectionInfo();
			Vector3 xy;
			float t = -(ray.Origin.z / ray.Direction.z);
			
			Vector3.Multiply(t, ray.Direction, out xy);
			Vector3.Add(ray.Origin, xy, out xy);
			
			info.hasIntersected = this.Contains(xy);
			info.distance = (info.hasIntersected ? t : 0.0f);
			info.impactPoint = xy;
			
			return info;
		}
		
		/// <summary>Renders the object when debugging mode is on</summary>
		/// <param name="game">The reference to the game, used to get to the rendering context</param>
		public void DebugRender(IGame game) { this.DebugRender(game, game.ShaderHelper.DefaultLineShaderProgram); }
		
		/// <summary>Renders the object when debugging mode is on using a specific shader program</summary>
		/// <param name="game">The reference to the game, used to get to the rendering context</param>
		/// <param name="program">The shading program used</param>
		public void DebugRender(IGame game, IShaderProgram program) {
			// Variables
			ILineBatcher batcher = game.RenderHelper.GetBatcher(program, BatcherType.Lines) as ILineBatcher;
			Vector3[] vertices = new Vector3[8];
			float delta;
			
			for(int i = 0; i < vertices.Length; i++) {
				delta = (float)i / (float)vertices.Length;
				delta *= Mathx.TwoPi;
				vertices[i] = new Vector3(Mathx.Cos(delta), Mathx.Sin(delta), 0.0f);
			}
			
			batcher.Color = Color.Red;
			batcher.AddLines(vertices);
		}
		
		#endregion // Public Methods
	}
}
