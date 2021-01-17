
using System.Runtime.InteropServices;

namespace B3 {
	/// <summary>A 2D representation of a list of points that forms a polygon</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct Polygon : System.IEquatable<Polygon> {
		#region Field Variables
		// Variables
		private Vector2[] vertices;
		/// <summary>An empty polygon with no points on the list</summary>
		public static readonly Polygon Empty = new Polygon(new Vector2[0]);
		
		#endregion // Field Variables
		
		#region Public Properties
		
		/// <summary>Gets and sets the list of vertices from the polygon</summary>
		public Vector2 this[int index] { get { return this.vertices[index]; } set { this.vertices[index] = value; } }
		
		/// <summary>Gets the count of vertices within the polygon</summary>
		public int Count { get { return this.vertices.Length; } }
		
		/// <summary>Gets the center of the polygon</summary>
		public Vector2 Center { get {
			if(this.Count == 0) {
				return Vector2.Zero;
			}
			
			// Variables
			Vector2 center = this.vertices[0];
			
			for(int i = 1; i < this.Count; i++) {
				Mathx.Add(ref center, ref this.vertices[i], out center);
			}
			Mathx.Divide(this.Count, ref center, out center);
			
			return center;
		} }
		
		#endregion // Public Properties
		
		#region Public Constructors
		
		/// <summary>A base constructor for creating a polygon</summary>
		public Polygon(Vector2[] vertices) {
			this.vertices = vertices;
		}
		
		#endregion // Public Constructors
		
		#region Public Static Methods
		
		#region Add Methods
		
		/// <summary>Adds the vertex to the polygon</summary>
		/// <param name="polygon">The polygon to add with</param>
		/// <param name="vertex">The vertex to add into the polygon</param>
		public static void Add(ref Polygon polygon, ref Vector2 vertex) {
			System.Array.Resize(ref polygon.vertices, polygon.Count + 1);
			polygon.vertices[polygon.Count - 1] = vertex;
		}
		
		/// <summary>Adds the vertex to the polygon</summary>
		/// <param name="polygon">The polygon to add with</param>
		/// <param name="vertex">The vertex to add into the polygon</param>
		public static void Add(ref Polygon polygon, Vector2 vertex) { Add(ref polygon, ref vertex); }
		
		/// <summary>Adds the vertex to the polygon</summary>
		/// <param name="polygon">The polygon to add with</param>
		/// <param name="vertex">The vertex to add into the polygon</param>
		/// <returns>Returns a new polygon with the vertex added</returns>
		public static Polygon Add(Polygon polygon, Vector2 vertex) {
			// Variables
			Polygon result = polygon;
			
			Add(ref result, ref vertex);
			
			return result;
		}
		
		#endregion // Add Methods
		
		#region Remove Methods
		
		/// <summary>Removes the vertex from the polygon by the given vertex</summary>
		/// <param name="polygon">The polygon to remove with</param>
		/// <param name="vertex">The vertex to remove from</param>
		public static void Remove(ref Polygon polygon, ref Vector2 vertex) {
			for(int i = 0; i < polygon.Count; i++) {
				if(polygon.vertices[i] == vertex) {
					Remove(ref polygon, i);
					return;
				}
			}
		}
		
		/// <summary>Removes the vertex from the polygon by the given vertex</summary>
		/// <param name="polygon">The polygon to remove with</param>
		/// <param name="vertex">The vertex to remove from</param>
		public static void Remove(ref Polygon polygon, Vector2 vertex) { Remove(ref polygon, ref vertex); }
		
		/// <summary>Removes the vertex from the polygon by the given vertex</summary>
		/// <param name="polygon">The polygon to remove with</param>
		/// <param name="vertex">The vertex to remove from</param>
		/// <returns>Returns a new polygon with the vertex removed</returns>
		public static Polygon Remove(Polygon polygon, Vector2 vertex) {
			// Variables
			Polygon result = polygon;
			
			Remove(ref result, ref vertex);
			
			return result;
		}
		
		/// <summary>Removes the vertex from the polygon by the given index</summary>
		/// <param name="polygon">The polygon to remove with</param>
		/// <param name="index">The index to remove from</param>
		public static void Remove(ref Polygon polygon, int index) {
			if(polygon.Count == 0) {
				return;
			}
			if(index < 0 || index >= polygon.Count) {
				return;
			}
			
			// Variables
			Vector2[] temp = polygon.vertices;
			
			for(int i = index; i < polygon.Count - 1; i ++) {
				temp[i] = temp[i + 1];
			}
			System.Array.Resize(ref temp, polygon.Count - 1);
			polygon.vertices = temp;
		}
		
		/// <summary>Removes the vertex from the polygon by the given index</summary>
		/// <param name="polygon">The polygon to remove with</param>
		/// <param name="index">The index to remove from</param>
		/// <returns>Returns a polygon with the vertex removed</returns>
		public static Polygon Remove(Polygon polygon, int index) {
			// Variables
			Polygon result = polygon;
			
			Remove(ref polygon, index);
			
			return result;
		}
		
		#endregion // Remove Methods
		
		#endregion // Public Static Methods
		
		#region Public Methods
		
		/// <summary>Adds the vertex to the polygon</summary>
		/// <param name="vertex">The vertex to add into the polygon</param>
		public void Add(Vector2 vertex) { Add(ref this, ref vertex); }
		
		/// <summary>Removes the vertex from the polygon by the given vertex</summary>
		/// <param name="vertex">The vertex to remove from</param>
		public void Remove(Vector2 vertex) { Remove(ref this, ref vertex); }
		
		/// <summary>Removes the vertex from the polygon by the given index</summary>
		/// <param name="index">The index to remove from</param>
		public void Remove(int index) { Remove(ref this, index); }
		
		/// <summary>Finds if the two polygons are equal to each other</summary>
		/// <param name="other">The other polygon</param>
		/// <returns>Returns true if the two polygons are equal</returns>
		public bool Equals(Polygon other) {
			if(this.Count != other.Count) {
				return false;
			}
			
			for(int i = 0; i < this.Count; i++) {
				if(this.vertices[i] != other.vertices[i]) {
					return false;
				}
			}
			
			return true;
		}
		
		/// <summary>Finds if the two polygons are equal to each other</summary>
		/// <param name="other">The other polygon</param>
		/// <returns>Returns true if the two polygons are equal</returns>
		public override bool Equals(object other) {
			if(other == null) {
				return false;
			}
			if(other is Polygon) {
				return this.Equals((Polygon)other);
			}
			return false;
		}
		
		/// <summary>Gets the hash code from the polygon</summary>
		/// <returns>Returns the hash code from the polygon</returns>
		public override int GetHashCode() {
			// Variables
			int hash = 0;
			
			foreach(Vector2 vertex in this.vertices) {
				hash = hash ^ vertex.GetHashCode();
			}
			
			return hash;
		}
		
		/// <summary>Gets the polygon in string form</summary>
		/// <returns>Returns the polygon in string form</returns>
		public override string ToString() {
			// Variables
			string s = "[ ";
			
			for(int i = 0; i < this.Count; i++) {
				s += this.vertices[i] + (i != this.Count - 1 ? ", " : " ]");
			}
			
			return "{ vertices: " + s + " }";
		}
		
		#endregion // Public Methods
		
		#region Operators
		
		/// <summary>Finds if the two polygons are equal to each other</summary>
		/// <param name="left">The first polygon</param>
		/// <param name="right">The second polygon</param>
		/// <returns>Returns true if the two polygons are equal</returns>
		public static bool operator ==(Polygon left, Polygon right) { return left.Equals(right); }
		
		/// <summary>Finds if the two polygons are not equal to each other</summary>
		/// <param name="left">The first polygon</param>
		/// <param name="right">The second polygon</param>
		/// <returns>Returns true if the two polygons are not equal</returns>
		public static bool operator !=(Polygon left, Polygon right) { return !left.Equals(right); }
		
		#endregion // Operators
	}
}
