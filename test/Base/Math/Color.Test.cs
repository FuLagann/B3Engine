
using Xunit;

namespace B3.Testing {
	public class ColorTest {
		[Fact]
		public void Constructors() {
			// Variables
			Color a = new Color(16, 24, 32, 255);
			Color b = new Color(1, 2, 3, 4);
			Color c = new Color(0x00101820);
			Color d = new Color(0x101820);
			Color e = new Color(0x010203, 4);
			Color red = new Color(255, 0, 0);
			Color green = new Color(0, 255, 0);
			Color blue = new Color(0, 0, 255);
			Color yellow = new Color(255, 255, 0);
			Color magenta = new Color(255, 0, 255);
			Color cyan = new Color(0, 255, 255);
			Color white = new Color(255, 255, 255);
			Color black = new Color(0, 0, 0);
			
			Assert.Equal(a, c);
			Assert.Equal(a, d);
			Assert.Equal(b, e);
			Assert.Equal(Color.Red, red);
			Assert.Equal(Color.Green, green);
			Assert.Equal(Color.Blue, blue);
			Assert.Equal(Color.Yellow, yellow);
			Assert.Equal(Color.Magenta, magenta);
			Assert.Equal(Color.Cyan, cyan);
			Assert.Equal(Color.White, white);
			Assert.Equal(Color.Black, black);
		}
		
		[Theory]
		[InlineData(1.1f, -0.1f, 0.5f, 0xff007f)]
		public void FloatPropeties(float r, float g, float b, int rgb) {
			// Variables
			Color a = Random.Color;
			Color e = new Color(rgb);
			
			a.Redf = r;
			a.Greenf = g;
			a.Bluef = b;
			
			Assert.Equal(e, a);
		}
		
		[Theory]
		[InlineData(0x101820, 0x080808, 0x182028), InlineData(0xff00ff, 0xffffff, 0xffffff)]
		[InlineData(0x000000, 0x000000, 0x000000), InlineData(0xffffff, 0xffffff, 0xffffff)]
		[InlineData(0x505050, 0x505050, 0xa0a0a0), InlineData(0x0f01f1, 0x010f1f, 0x1010ff)]
		public void Add(int a, int b, int e) {
			// Variables
			Color ca = new Color(a);
			Color cb = new Color(b);
			Color ce = new Color(e);
			
			Assert.Equal(ce, Color.Add(ref ca, ref cb));
		}
		
		[Theory]
		[InlineData(0x101820, 0x080808, 0x081018), InlineData(0xff00ff, 0xffffff, 0x000000)]
		[InlineData(0x000000, 0x000000, 0x000000), InlineData(0xffffff, 0xffffff, 0x000000)]
		[InlineData(0x505050, 0x505050, 0x000000), InlineData(0x0f01f1, 0x010f1f, 0x0E00D2)]
		public void Subtract(int a, int b, int e) {
			// Variables
			Color ca = new Color(a);
			Color cb = new Color(b);
			Color ce = new Color(e);
			
			Assert.Equal(ce, Color.Subtract(ref ca, ref cb));
		}
		
		[Fact]
		public void LerpClamped() {
			for(int k = 0; k < 25; k++) {
				// Variables
				Color a = Random.Color;
				Color b = Random.Color;
				Color e = new Color(0);
				float t = Random.Value;
				
				e.Redf = Mathx.LerpClamped(a.Redf, b.Redf, t);
				e.Greenf = Mathx.LerpClamped(a.Greenf, b.Greenf, t);
				e.Bluef = Mathx.LerpClamped(a.Bluef, b.Bluef, t);
				e.Alphaf = Mathx.LerpClamped(a.Alphaf, b.Alphaf, t);
				
				Assert.Equal(e, Color.LerpClamped(ref a, ref b, t));
			}
		}
		
		[Theory]
		[InlineData(0x7fff7f, 0xA9A9A9)]
		[InlineData(0x331122, 0x222222)]
		public void Grayscale(int a, int e) {
			// Variables
			Color ca = new Color(a);
			Color ce = new Color(e);
			
			Assert.Equal(ce, Color.Grayscale(ref ca));
		}
		
		[Theory]
		[InlineData(0x7fff7f, 0x800080)]
		[InlineData(0x331122, 0xcceedd)]
		public void Invert(int a, int e) {
			// Variables
			Color ca = new Color(a);
			Color ce = new Color(e);
			
			Assert.Equal(ce, Color.Invert(ref ca));
		}
		
		[Theory]
		[InlineData(0x112233, 2.0f, 0x224466), InlineData(0x121212, 2.0f, 0x242424)]
		[InlineData(0x101820, 2.0f, 0x203040), InlineData(0xff007f, 2.0f, 0xff00fe)]
		public void Multiply(int a, float b, int e) {
			// Variables
			Color ca = new Color(a);
			Color ce = new Color(e);
			
			Assert.Equal(ce, Color.Multiply(b, ref ca));
		}
		
		[Theory]
		[InlineData(0x112233, 2.0f, 0x081119), InlineData(0x121212, 2.0f, 0x090909)]
		[InlineData(0x101820, 2.0f, 0x080c10), InlineData(0xff007f, 2.0f, 0x7f003f)]
		public void Divide(int a, float b, int e) {
			// Variables
			Color ca = new Color(a);
			Color ce = new Color(e);
			
			Assert.Equal(ce, Color.Divide(b, ref ca));
		}
	}
}
