
using B3.Graphics;

namespace B3 {
	/// <summary>A class to easily transform a world matrix for easy object manipulation</summary>
	public class Transform : IShaderVariable {
		#region Field Variables
		// Variables
		private Vector3 position;
		private Vector3 scale;
		private Quaternion rotation;
		private Matrix matrix;
		// TODO: Add parent-children system
		
		#endregion // Field Variables
		
		#region Public Properties
		
		/// <summary>Gets the matrix used by the transform</summary>
		public Matrix World { get { return this.matrix; } }
		
		/// <summary>Gets and sets the position of the transform</summary>
		public Vector3 Position { get { return this.position; } set {
			this.position = value;
			this.UpdateMatrix(true);
		} }
		
		/// <summary>Gets and sets the scale of the transform</summary>
		public Vector3 Scale { get { return this.scale; } set {
			this.scale = value;
			this.UpdateMatrix(false);
		} }
		
		/// <summary>Gets and sets the rotation of the transform</summary>
		public Quaternion Rotation { get { return this.rotation; } set {
			this.rotation = value;
			this.UpdateMatrix(false);
		} }
		
		/// <summary>Gets and sets the forward vector of the transform</summary>
		public Vector3 Forward { get {
			// Variables
			Vector3 result = Vector3.UnitZ;
			
			Quaternion.Multiply(ref this.rotation, ref result, out result);
			
			return result;
		} set {
			// TODO: Move this code to a separate private method to not repeat it with Forward, Right, and Up
			if(value == Vector3.Zero) {
				this.rotation = Quaternion.Identity;
				this.UpdateMatrix(false);
				return;
			}	
			
			// Variables
			Matrix lookAt;
			Vector3 target = value;
			Vector3 up = Vector3.UnitY;
			
			Vector3.Add(ref this.position, ref target, out target);
			Matrix.CreateLookAt(ref this.position, ref target, ref up, out lookAt);
			Quaternion.FromMatrix(ref lookAt, out this.rotation);
			this.UpdateMatrix(false);
		} }
		
		/// <summary>Gets and sets the right vector of the transform</summary>
		public Vector3 Right { get {
			// Variables
			Vector3 result = Vector3.UnitX;
			
			Quaternion.Multiply(ref this.rotation, ref result, out result);
			
			return result;
		} set {
			if(value == Vector3.Zero) {
				this.rotation = Quaternion.Identity;
				this.UpdateMatrix(false);
				return;
			}	
			
			// Variables
			Matrix lookAt;
			Vector3 target = value;
			Vector3 up = Vector3.UnitY;
			Quaternion rot;
			
			Vector3.Subtract(ref target, ref this.position, out target);
			Matrix.CreateLookAt(ref this.position, ref target, ref up, out lookAt);
			Quaternion.FromMatrix(ref lookAt, out this.rotation);
			up = this.Up;
			Quaternion.FromAxisAngle(ref up, -Mathx.PiOverTwo, out rot);
			Mathx.Multiply(ref rot, ref this.rotation, out this.rotation);
			
			this.UpdateMatrix(false);
		} }
		
		/// <summary>Gets and sets the up vector of the transform</summary>
		public Vector3 Up { get {
			// Variables
			Vector3 result = Vector3.UnitY;
			
			Quaternion.Multiply(ref this.rotation, ref result, out result);
			
			return result;
		} set {
			if(value == Vector3.Zero) {
				this.rotation = Quaternion.Identity;
				this.UpdateMatrix(false);
				return;
			}	
			
			// Variables
			Matrix lookAt;
			Vector3 target = value;
			Vector3 up = Vector3.UnitY;
			Quaternion rot;
			
			Vector3.Subtract(ref target, ref this.position, out target);
			Matrix.CreateLookAt(ref this.position, ref target, ref up, out lookAt);
			Quaternion.FromMatrix(ref lookAt, out this.rotation);
			up = this.Right;
			Quaternion.FromAxisAngle(ref up, Mathx.PiOverTwo, out rot);
			Mathx.Multiply(ref rot, ref this.rotation, out this.rotation);
			
			this.UpdateMatrix(false);
		} }
		
		/// <summary>Gets and sets the euler angles used for rotation by the transform</summary>
		public Vector3 EulerAngles { get { return Quaternion.ToEulerAngles(ref this.rotation); } set {
			Quaternion.FromEulerAngles(ref value, out this.rotation);
			this.UpdateMatrix(false);
		} }
		
		// TODO: public Vector3 AbsolutePosition { get; set; }
		// TODO: public Vector3 AbsoluteScale { get; set; }
		// TODO: public Quaternion AbsoluteRotation { get; set; }
		
		#endregion // Public Properties
		
		#region Public Constructors
		
		/// <summary>A base constructor for creating a transform</summary>
		public Transform() {
			this.matrix = Matrix.Identity;
			this.position = Vector3.Zero;
			this.scale = Vector3.One;
		}
		
		#endregion // Public Constructors
		
		#region Public Methods
		
		/// <summary>Sets the transform into the shader program for use in the shaders. Sets it as the world matrix, world</summary>
		/// <param name="program">The shader program used</param>
		public void SetUniform(IShaderProgram program) { program.SendUniform("world", this.matrix); }
		
		/// <summary>Makes the transform look towards the target</summary>
		/// <param name="target">The location in space to look at</param>
		public void LookAt(Vector3 target) { this.Forward = target; }
		
		#endregion // Public Methods
		
		#region Private Methods
		
		/// <summary>Updates the matrix discreetly</summary>
		private void UpdateMatrix(bool updatingPosition) {
			if(!updatingPosition) {
				// Variables
				Matrix temp;
				
				Matrix.CreateTranslation(ref this.position, out this.matrix);
				Quaternion.ToMatrix(ref this.rotation, out temp);
				Matrix.Multiply(ref this.matrix, ref temp, out this.matrix);
				Matrix.CreateScale(ref this.scale, out temp);
				Matrix.Multiply(ref this.matrix, ref temp, out this.matrix);
			}
			this.matrix.row1.w = this.position.x;
			this.matrix.row2.w = this.position.y;
			this.matrix.row3.w = this.position.z;
		}
		
		#endregion // Private Methods
	}
}
