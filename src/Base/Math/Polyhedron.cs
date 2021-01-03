
using System.Runtime.InteropServices;

namespace B3 {
	/// <summary>A 3D representation of a polygon</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct Polyhedron : System.IEquatable<Polyhedron> {
		#region Field Variables
		// Variables
		private Vector3[] vertices;
		/// <summary>An empty polyhedron with no vertices in the list</summary>
		public static readonly Polyhedron Empty = new Polyhedron(new Vector3[0]);
		
		#endregion // Field Variables
		
		#region Public Properties
		
		/// <summary>Gets and sets the vertex from the given index</summary>
		public Vector3 this[int index] { get { return this.vertices[index]; } set { this.vertices[index] = value; } }
		
		/// <summary>Gets the number of vertices within the polyhedron</summary>
		public int Count { get { return this.vertices.Length; } }
		
		/// <summary>Gets the center of the polyhedron</summary>
		public Vector3 Center { get {
			if(this.Count == 0) {
				return Vector3.Zero;
			}
			
			// Variables
			Vector3 center = this.vertices[0];
			
			for(int i = 1; i < this.Count; i++) {
				Mathx.Add(ref center, ref this.vertices[i], out center);
			}
			Mathx.Divide(this.Count, ref center, out center);
			
			return center;
		} }
		
		#endregion // Public Properties
		
		#region Public Constructors
		
		/// <summary>A base constructor for creating a polyhedron</summary>
		/// <param name="vertices">The vertices of the polyhedron</param>
		public Polyhedron(Vector3[] vertices) {
			this.vertices = vertices;
		}
		
		#endregion // Public Constructors
		
		#region Public Methods
		
		/// <summary>Finds if the two polyhedrons are equal to each other</summary>
		/// <param name="other">The other polyhedron</param>
		/// <returns>Returns true if the two polyhedrons are equal</returns>
		public bool Equals(Polyhedron other) {
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
		
		/// <summary>Finds if the two polyhedrons are equal to each other</summary>
		/// <param name="other">The other polyhedron</param>
		/// <returns>Returns true if the two polyhedrons are equal</returns>
		public override bool Equals(object other) {
			if(other == null) {
				return false;
			}
			if(other is Polyhedron) {
				return this.Equals((Polyhedron)other);
			}
			return false;
		}
		
		/// <summary>Gets the hash code from the polyhedron</summary>
		/// <returns>Returns the hash code from the polyhedron</returns>
		public override int GetHashCode() {
			// Variables
			int hash = 0;
			
			foreach(Vector3 vertex in this.vertices) {
				hash = hash ^ vertex.GetHashCode();
			}
			
			return hash;
		}
		
		/// <summary>Gets the polyhedron in string form</summary>
		/// <returns>Returns the polyhedron in string form</returns>
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
		
		/// <summary>Finds if the two polyhedrons are equal to each other</summary>
		/// <param name="left">The first polyhedron</param>
		/// <param name="right">The second polyhedron</param>
		/// <returns>Returns true if the two polyhedrons are equal</returns>
		public static bool operator ==(Polyhedron left, Polyhedron right) { return left.Equals(right); }
		
		
		/// <summary>Finds if the two polyhedrons are not equal to each other</summary>
		/// <param name="left">The first polyhedron</param>
		/// <param name="right">The second polyhedron</param>
		/// <returns>Returns true if the two polyhedrons are not equal</returns>
		public static bool operator !=(Polyhedron left, Polyhedron right) { return !left.Equals(right); }
		
		#endregion // Operators
	}
}
