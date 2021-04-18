
using OpenTK.Graphics.OpenGL;

using System.IO;
using System.Text.RegularExpressions;

using Drawing = System.Drawing;
using Imaging = System.Drawing.Imaging;

namespace B3.Graphics {
	/// <summary>A class that handles 2D textures</summary>
	public sealed class Texture2D : BaseTexture {
		#region Public Constructors
		
		/// <summary>A base constructor for setting up 2D textures</summary>
		/// <param name="game">The game used to make sure OpenGL was loaded in correctly</param>
		/// <param name="location">The location of the file to get the texture from</param>
		public Texture2D(IGame game, string location) : base(game, location, TextureType.Texture2D) {}
		
		#endregion // Public Constructors
		
		#region Public Static Methods
		
		/// <summary>Creates an empty texture with a set width and height</summary>
		/// <param name="game">The game used to make sure OpenGL was loaded in correctly</param>
		/// <param name="width">The width of the texture</param>
		/// <param name="height">The height of the texture</param>
		/// <returns>Returns an empty texture with a set width and height</returns>
		public static Texture2D CreateEmpty(IGame game, int width, int height) {
			return new Texture2D(game, $"{width};{height}");
		}
		
		#endregion // Public Static Methods
		
		#region Public Methods
		
		/// <summary>Sets the texture from the given file</summary>
		/// <param name="location">The location of the file</param>
		public override void SetFromFile(string location) {
			// Variables
			Regex regex = new Regex(@"(\d+);(\d+)");
			Match match = regex.Match(location);
			
			if(match.Success) {
				// Variables
				int width, height;
				
				int.TryParse(match.Groups[1].Value, out width);
				int.TryParse(match.Groups[2].Value, out height);
				
				GL.TexImage2D(
					this.Target.ToOpenGL(),
					0,
					PixelInternalFormat.Rgba8,
					width,
					height,
					0,
					PixelFormat.Rgb,
					PixelType.Byte,
					System.IntPtr.Zero
				);
				return;
			}
			
			using(Stream stream = FS.ReadStream(location)) {
				// Variables
				Drawing.Bitmap bmp = Drawing.Bitmap.FromStream(stream) as Drawing.Bitmap;
				Imaging.BitmapData data = bmp.LockBits(
					new Drawing.Rectangle(0, 0, bmp.Width, bmp.Height),
					Imaging.ImageLockMode.ReadOnly,
					Imaging.PixelFormat.Format32bppRgb
				);
				
				this.Bind();
				GL.TexImage2D(
					this.Target.ToOpenGL(),
					0,
					PixelInternalFormat.Rgba,
					bmp.Width,
					bmp.Height,
					0,
					PixelFormat.Rgba,
					PixelType.UnsignedByte,
					data.Scan0
				);
				bmp.UnlockBits(data);
			}
		}
		
		#endregion // Public Methods
		
		#region Protected Methods
		
		/// <summary>Initializes the texture</summary>
		/// <param name="location">The location of the file to the texture being used</param>
		protected override void Initialize(string location) {
			this.Bind();
			this.SetFromFile(location);
			this.Buffer();
		}
		
		#endregion // Protected Methods
	}
}
