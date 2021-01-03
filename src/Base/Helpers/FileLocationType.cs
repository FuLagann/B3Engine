
namespace B3.Management {
	/// <summary>The enumeration that tells the asset locations what type of file location is being used</summary>
	public enum FileLocationType {
		/// <summary>The default file location type, which is centered around the binaries folder</summary>
		Default,
		/// <summary>The file location that is embedded within the .dll library</summary>
		Embedded,
		/// <summary>The file location that can be found on a http server</summary>
		Http,
		/// <summary>The file location that can be found on a https server</summary>
		Https
	}
}
