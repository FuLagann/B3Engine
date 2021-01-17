
namespace B3 {
	/// <summary>An enumaration for all the different interpolation loop types</summary>
	public enum InterpolationLoopType : int {
		/// <summary>For when there is no loop, the interpolation will stop once it's finished</summary>
		NoLoop = 0,
		
		/// <summary>For when there is no loop and you want the interpolation to move backwards, the interpolation will stop once it's finished</summary>
		NoLoopBackwards = 1,
		
		/// <summary>For when you want the interpolation to loop, it will never finish the interpolation</summary>
		FullLoop = 2,
		
		/// <summary>For when you want the interpolation to loop backwards, it will never finish the interpolation</summary>
		FullLoopBackwards = 3,
		
		/// <summary>
		/// For when you want the interpolation to yoyo back and forth starting with the forth; this will also be used when the
		/// YoyoLoopBackwards has been completed. It will never finish the interpolation
		/// </summary>
		YoyoLoop = 4,
		
		/// <summary>
		/// For when you want the interpolation to yoyo back and forth starting with the back; this will also be used when the YoyoLoop has been completed.
		/// It will never finish the interpolation
		/// </summary>
		YoyoLoopBackwards = 5
	}
}
