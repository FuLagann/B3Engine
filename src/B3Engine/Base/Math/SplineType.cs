
namespace B3 {
	/// <summary>An enumeration for the types of interpolations a spline should do</summary>
	public enum SplineType {
		/// <summary>Tells the spline that all interpolations between points should be linear</summary>
		Linear,
		
		/// <summary>Tells the spline that all interpolations between points should be Catmull-Rom spline interpolations</summary>
		CatmullRom
	}
}
