
namespace B3.Graphics {
	/// <summary>An enumeration of all the different types of rendering types</summary>
	public enum RenderType {
		/// <summary>Renders only points</summary>
		Points,
		/// <summary>Renders only lines</summary>
		Lines,
		/// <summary>Renders lines in a stip-loop with the last point connecting to the first point</summary>
		LineLoop,
		/// <summary>Renders lines in a strip, connecting to each other</summary>
		LineStrip,
		/// <summary>Renders only triangles</summary>
		Triangles,
		/// <summary>Renders triangles in a strip, connecting the last two points with the next newest point</summary>
		TriangleStrip,
		/// <summary>Renders triangles in a fan, connecting the first and last points with the next newest point</summary>
		TriangleFan,
		/// <summary>Renders only quads</summary>
		Quads,
		/// <summary>Renders quads in a strip, connecting the last two points with the next two newest points</summary>
		QuadsStrip,
		/// <summary>Renders a polygon as a single continuous face</summary>
		Polygon,
		// TODO: Figure out what these are before adding them in; needs description
		// LinesAdjacency,
		// LineStripAdjacency,
		// TrianglesAdjacency,
		// TriangleStripAdjacency,
		// Patches
	}
}
