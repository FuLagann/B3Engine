
namespace B3 {
	/// <summary>An enumeration of system cursors to use</summary>
	public enum SystemCursorType : int {
		/// <summary>The standard arrow cursor</summary>
		Arrow,
		/// <summary>The I cursor used when editting text</summary>
		IBeam,
		/// <summary>The buffering cursor when something is loading</summary>
		Wait,
		/// <summary>The crosshair cursor used when drawing a range</summary>
		Crosshair,
		/// <summary>The buffering cursor that is combined with the standard arrow</summary>
		WaitArrow,
		/// <summary>The cursor that shows you can resize on the top-left / bottom-right corner</summary>
		SizeNWSE,
		/// <summary>The cursor that shows you can resize on the top-right / bottom-left corner</summary>
		SizeNESW,
		/// <summary>The cursor that shows you can resize on the left / right</summary>
		SizeWE,
		/// <summary>The cursor that shows you can resize on the top / bottom</summary>
		SizeNS,
		/// <summary>The cursor that shows you can resize on all sides / can move an object</summary>
		SizeAll,
		/// <summary>The cursor that shows you cannot interact with that</summary>
		No,
		/// <summary>The cursor that shows you can grab something or pan around</summary>
		Hand
	}
}
