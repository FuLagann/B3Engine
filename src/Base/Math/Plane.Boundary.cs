
using B3.Graphics;

namespace B3 {
	public partial struct Plane : IBoundary {
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
			float dist = (Mathx.Dot(ref this.normal, ref point) + this.distance) / (this.normal.Magnitude);
			
			return Mathx.Approx(dist, 2.0f * this.distance, 0.000001f);
		}
		
		/// <summary>Finds if the ray is intersecting the boundary</summary>
		/// <param name="ray">The ray to find if it intersects with the boundary</param>
		/// <returns>Returns the information pertaining to the intersection</returns>
		public IntersectionInfo Intersects(Ray ray) {
			// Variables
			IntersectionInfo info = new IntersectionInfo();
			float dot = Vector3.Dot(this.normal, ray.Direction);
			
			if(!Mathx.Approx(dot, 0.0f)) {
				// Variables
				Vector3 point;
				Vector3 planePoint;
				float t;
				
				Mathx.Multiply(this.distance, ref this.normal, out planePoint);
				Vector3.Subtract(planePoint, ray.Origin, out point);
				Mathx.Dot(ref point, ref this.normal, out t);
				
				t /= dot;
				
				info.hasIntersected = (t >= 0.0f);
				if(info.hasIntersected) {
					info.distance = t;
					Vector3.Multiply(t, ray.Direction, out info.impactPoint);
					Vector3.Add(ray.Origin, info.impactPoint, out info.impactPoint);
					
					return info;
				}
			}
			
			info.hasIntersected = false;
			info.distance = 0.0f;
			info.impactPoint = ray.Origin;
			
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
			Vector3 up = (this.normal == Vector3.UnitY ? Vector3.UnitZ : Vector3.UnitY);
			Vector3 right;
			Vector3 forward;
			Vector3 origin;
			Vector3 topLeft;
			Vector3 topRight;
			Vector3 bottomRight;
			Vector3 bottomLeft;
			
			Mathx.CrossProduct(ref this.normal, ref up, out right);
			Mathx.CrossProduct(ref this.normal, ref right, out forward);
			Mathx.Multiply(this.distance, ref this.normal, out origin);
			Mathx.Multiply(10.0f, ref right, out right);
			Mathx.Multiply(10.0f, ref forward, out forward);
			up = this.normal;
			Mathx.Multiply(5.0f, ref up, out up);
			Mathx.Add(ref origin, ref up, out up);
			
			// Top Left
			Mathx.Subtract(ref origin, ref forward, out topLeft);
			Mathx.Subtract(ref topLeft, ref right, out topLeft);
			
			// Top Right
			Mathx.Subtract(ref origin, ref forward, out topRight);
			Mathx.Add(ref topRight, ref right, out topRight);
			
			// Bottom Right
			Mathx.Add(ref origin, ref forward, out bottomRight);
			Mathx.Add(ref bottomRight, ref right, out bottomRight);
			
			// Bottom Left
			Mathx.Add(ref origin, ref forward, out bottomLeft);
			Mathx.Subtract(ref bottomLeft, ref right, out bottomLeft);
			
			batcher.Color = Color.Red;
			batcher.AddLines(new Vector3[] {
				topLeft,
				topRight,
				bottomRight,
				bottomLeft
			});
			batcher.Color = Color.Green;
			batcher.AddLine(origin, up);
		}
		
		#endregion // Public Methods
	}
}
