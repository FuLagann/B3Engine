
using B3.Graphics;

namespace B3 {
	public partial struct Box : IBoundary {
		#region Public Methods
		
		/// <summary>Finds if the point is contained within the boundary</summary>
		/// <param name="point">The point used to find if it contained within the boundary</param>
		/// <returns>Returns true if the point is contained within the boundary</returns>
		public bool Contains(Vector2 point) { return this.Contains((Vector3)point); }
		
		/// <summary>Finds if the point is contained within the boundary</summary>
		/// <param name="point">The point used to find if it contained within the boundary</param>
		/// <returns>Returns true if the point is contained within the boundary</returns>
		public bool Contains(Vector3 point) {
			return (
				point.x >= this.x && point.x <= this.x + this.width &&
				point.y >= this.y && point.y <= this.y + this.height &&
				point.z >= this.z && point.z <= this.z + this.depth
			);
		}
		
		/// <summary>Finds if the ray is intersecting the boundary</summary>
		/// <param name="ray">The ray to find if it intersects with the boundary</param>
		/// <returns>Returns the information pertaining to the intersection</returns>
		public IntersectionInfo Intersects(Ray ray) {
			// Variables
			IntersectionInfo info = new IntersectionInfo();
			float txmin = ((ray.Direction.x >= 0.0f ? this.x : this.x + this.width) - ray.Origin.x) / ray.Direction.x;
			float txmax = ((ray.Direction.x >= 0.0f ? this.x + this.width : this.x) - ray.Origin.x) / ray.Direction.x;
			float tymin = ((ray.Direction.y >= 0.0f ? this.y : this.y + this.height) - ray.Origin.y) / ray.Direction.y;
			float tymax = ((ray.Direction.y >= 0.0f ? this.y + this.height : this.y) - ray.Origin.y) / ray.Direction.y;
			
			info.impactPoint = ray.Origin;
			
			if((txmin > tymax) || (tymin > txmax)) {
				info.hasIntersected = false;
				info.distance = 0.0f;
				
				return info;
			}
			
			if(tymin > txmin) { txmin = tymin; }
			if(tymax < txmax) { txmax = tymax; }
			
			// Variables
			float tzmin = ((ray.Direction.z >= 0.0f ? this.z : this.z + this.width) - ray.Origin.z) / ray.Direction.z;
			float tzmax = ((ray.Direction.z >= 0.0f ? this.z + this.width : this.z) - ray.Origin.z) / ray.Direction.z;
			
			if((txmin > tzmax) || (tzmin > txmax)) {
				info.hasIntersected = false;
				info.distance = 0.0f;
				
				return info;
			}
			
			if(tzmin > txmin) { txmin = tzmin; }
			if(tzmax < txmax) { txmax = tzmax; }
			
			info.hasIntersected = true;
			if(txmin >= 0.0f) {
				info.distance = txmin;
			}
			else {
				if(txmax < 0.0f) {
					info.distance = 0.0f;
					info.hasIntersected = false;
					
					return info;
				}
				info.distance = txmax;
			}
			
			// Variables
			Vector3 temp;
			
			Vector3.Multiply(info.distance, ray.Direction, out temp);
			Mathx.Add(ref temp, ref info.impactPoint, out info.impactPoint);
			
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
			Vector3 topLeftNear = new Vector3(this.Top, this.Left, this.Near);
			Vector3 topRightNear = new Vector3(this.Top, this.Right, this.Near);
			Vector3 bottomRightNear = new Vector3(this.Bottom, this.Right, this.Near);
			Vector3 bottomLeftNear = new Vector3(this.Bottom, this.Left, this.Near);
			Vector3 topLeftFar = new Vector3(this.Top, this.Left, this.Far);
			Vector3 topRightFar = new Vector3(this.Top, this.Right, this.Far);
			Vector3 bottomRightFar = new Vector3(this.Bottom, this.Right, this.Far);
			Vector3 bottomLeftFar = new Vector3(this.Bottom, this.Left, this.Far);
			
			batcher.Color = Color.Red;
			batcher.AddLines(new Vector3[] {
				topLeftNear,
				topRightNear,
				bottomRightNear,
				bottomLeftNear
			});
			batcher.AddLines(new Vector3[] {
				topLeftFar,
				topRightFar,
				bottomRightFar,
				bottomLeftFar
			});
			batcher.AddLine(topLeftNear, topLeftFar);
			batcher.AddLine(topRightNear, topRightFar);
			batcher.AddLine(bottomRightNear, bottomRightFar);
			batcher.AddLine(bottomLeftNear, bottomLeftFar);
		}
		
		#endregion // Public Methods
	}
}
