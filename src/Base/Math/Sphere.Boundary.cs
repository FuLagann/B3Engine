
using B3.Graphics;

namespace B3 {
	public partial struct Sphere : IBoundary {
		#region Public Methods
		
		/// <summary>Finds if the point is contained within the boundary</summary>
		/// <param name="point">The point used to find if it contained within the boundary</param>
		/// <returns>Returns true if the point is contained within the boundary</returns>
		public bool Contains(Vector2 point) { return this.Contains((Vector3)point); }
		
		/// <summary>Finds if the point is contained within the boundary</summary>
		/// <param name="point">The point used to find if it contained within the boundary</param>
		/// <returns>Returns true if the point is contained within the boundary</returns>
		public bool Contains(Vector3 point) {
			// Variables
			Vector3 temp;
			float dist;
			
			Mathx.Subtract(ref point, ref this.center, out temp);
			dist = temp.Magnitude;
			
			return (dist <= this.radius);
		}
		
		/// <summary>Finds if the ray is intersecting the boundary</summary>
		/// <param name="ray">The ray to find if it intersects with the boundary</param>
		/// <returns>Returns the information pertaining to the intersection</returns>
		public IntersectionInfo Intersects(Ray ray) {
			// Variables
			IntersectionInfo info = new IntersectionInfo();
			Vector3 line;
			float t;
			float d;
			
			Vector3.Subtract(this.center, ray.Origin, out line);
			Vector3.Dot(line, ray.Direction, out t);
			Vector3.Dot(ref line, ref line, out d);
			d -= (t * t);
			
			if(d > this.radius * this.radius) {
				info.hasIntersected = false;
				info.impactPoint = ray.Origin;
				info.distance = 0.0f;
				
				return info;
			}
			
			// Variables
			float th = Mathx.Sqrt(this.radius * this.radius - d);
			float tmin = t - th;
			float tmax = t + th;
			
			if(tmin > tmax) {
				// Variables
				float temp = tmin;
				
				tmin = tmax;
				tmax = tmin;
			}
			
			if(tmin < 0.0f) {
				tmin = tmax;
				if(tmin < 0.0f) {
					info.hasIntersected = false;
					info.distance = 0.0f;
					info.impactPoint = ray.Origin;
					
					return info;
				}
			}
			
			info.distance = tmin;
			info.hasIntersected = true;
			Vector3.Multiply(info.distance, ray.Direction, out info.impactPoint);
			Vector3.Add(ray.Origin, info.impactPoint, out info.impactPoint);
			
			return info;
		}
		
		/// <summary>Renders the object when debugging mode is on</summary>
		/// <param name="game">The reference to the game, used to get to the RenderingContext</param>
		public void DebugRender(IGame game) { this.DebugRender(game, game.ShaderHelper.DefaultLineShaderProgram); }
		
		/// <summary>Renders the object when debugging mode is on using a specific shader program</summary>
		/// <param name="game">The reference to the game, used to get to the RenderingContext</param>
		/// <param name="program">The shading program used</param>
		public void DebugRender(IGame game, IShaderProgram program) {
			// Variables
			ILineBatcher batcher = game.RenderHelper.GetBatcher(program, BatcherType.Lines) as ILineBatcher;
			float cos;
			float sin;
			float delta;
			Vector3[] xyCircle = new Vector3[8];
			Vector3[] xzCircle = new Vector3[8];
			Vector3[] yzCircle = new Vector3[8];
			
			for(int i = 0; i < xyCircle.Length; i++) {
				delta = (float)i / (float)xyCircle.Length;
				delta *= Mathx.TwoPi;
				cos = Mathx.Cos(delta);
				sin = Mathx.Sin(delta);
				xyCircle[i] = new Vector3(cos, sin, 0.0f);
				xzCircle[i] = new Vector3(cos, 0.0f, sin);
				yzCircle[i] = new Vector3(0.0f, cos, sin);
			}
			
			batcher.Color = Color.Red;
			batcher.AddLines(xyCircle);
			batcher.AddLines(xzCircle);
			batcher.AddLines(yzCircle);
		}
		
		#endregion // Public Methods
	}
}
