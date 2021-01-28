
using B3.Management;

using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace B3 {
	/// <summary>A static class for reading and writing files in various different file systems. FS stands for File Systems</summary>
	public static class FS {
		#region Field Variables
		// Variables
		private static int frameDistance = 1;
		private static readonly TaskFactory Factory = new TaskFactory(
			CancellationToken.None,
			TaskCreationOptions.None,
			TaskContinuationOptions.None,
			TaskScheduler.Default
		);
		
		#endregion // Field Variables
		
		#region Public Static Properties
		
		/// <summary>Gets the base path of where the application is located on the computer</summary>
		public static string BasePath { get { return System.AppDomain.CurrentDomain.BaseDirectory; } }
		
		#endregion // Public Static Properties
		
		#region Public Static Methods
		
		#region Exists Methods
		
		/// <summary>Finds if the asset location exists</summary>
		/// <param name="location">The asset location to query if it exists</param>
		/// <returns>Returns true if the asset exists</returns>
		public static bool Exists(AssetLocation location) {
			FS.frameDistance = 2;
			switch(location.FileLocationType) {
				default:
				case FileLocationType.Default: return FileExists(location.FilePath);
				case FileLocationType.Embedded: return EmbeddedExists(location.FilePath);
				case FileLocationType.Http: return WebExists($"http://{location.FilePath}");
				case FileLocationType.Https: return WebExists($"https://{location.FilePath}");
			}
		}
		
		/// <summary>Finds if the file location exists</summary>
		/// <param name="location">The file location to query if it exists</param>
		/// <returns>Returns true if the file exists</returns>
		public static bool Exists(string location) {
			if(string.IsNullOrEmpty(location)) {
				throw new System.Exception("No file location was specified");
			}
			
			// Variables
			FileLocationType locationType = GetLocationType(location);
			string trueLocation = GetLocation(location, locationType);
			
			FS.frameDistance = 2;
			switch(locationType) {
				default:
				case FileLocationType.Default: return FileExists(trueLocation);
				case FileLocationType.Embedded: return EmbeddedExists(trueLocation);
				case FileLocationType.Http:
				case FileLocationType.Https: return WebExists(trueLocation);
			}
		}
		
		/// <summary>Finds if the file exists</summary>
		/// <param name="filepath">The path to the file to find if it exists</param>
		/// <returns>Returns true if the file exists</returns>
		public static bool FileExists(string filepath) { return File.Exists(filepath); }
		
		/// <summary>Finds if the webpage exists</summary>
		/// <param name="webpath">The path to the webpage to find if it exists</param>
		/// <returns>Returns true if the webpage exists</returns>
		public static bool WebExists(string webpath) {
			// Variables
			bool results = false;
			
			try {
				using(HttpClient client = new HttpClient()) {
					// Variables
					HttpResponseMessage res = RunSync<HttpResponseMessage>(async () => await client.GetAsync(webpath));
					
					if(res.StatusCode == HttpStatusCode.OK) {
						results = true;
					}
				}
			} catch { results = false; }
			
			return results;
		}
		
		/// <summary>Finds if the embedded file exists</summary>
		/// <param name="embeddedpath">The path to the embedded file</param>
		/// <returns>Returns true if the embedded file exists</returns>
		public static bool EmbeddedExists(string embeddedpath) {
			// Variables
			StackFrame frame = (new StackTrace()).GetFrame(FS.frameDistance);
			MethodBase method;
			System.Type type;
			Assembly assembly;
			bool results = false;
			
			FS.frameDistance = 1;
			method = frame.GetMethod();
			type = method.DeclaringType;
			assembly = type.Assembly;
			
			if(assembly != null) {
				using(Stream resourceStream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{embeddedpath}")) {
					if(resourceStream != null) {
						results = true;
					}
				}
			}
			
			return results;
		}
		
		/// <summary>Finds if the embedded file exists</summary>
		/// <param name="embeddedpath">The path to the embedded file</param>
		/// <param name="assembly">The assembly to look into for the embedded file</param>
		/// <returns>Returns true if the embedded file exists</returns>
		public static bool EmbeddedExists(string embeddedpath, Assembly assembly) {
			if(assembly == null) {
				FS.frameDistance = 2;
				return EmbeddedExists(embeddedpath);
			}
			
			// Variables
			bool results = false;
			
			using(Stream resourceStream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{embeddedpath}")) {
				if(resourceStream != null) {
					results = true;
				}
			}
			
			return results;
		}
		
		#endregion // Exists Methods
		
		#region Read Methods
		
		/// <summary>Reads the file content from the given asset location</summary>
		/// <param name="location">The location of the asset to get the file contents from</param>
		/// <returns>Returns the file content from the given asset location</returns>
		public static string Read(AssetLocation location) {
			FS.frameDistance = 2;
			switch(location.FileLocationType) {
				default:
				case FileLocationType.Default: return ReadFromFile(location.FilePath);
				case FileLocationType.Embedded: return ReadFromEmbedded(location.FilePath);
				case FileLocationType.Http: return ReadFromWeb($"http://{location.FilePath}");
				case FileLocationType.Https: return ReadFromWeb($"https://{location.FilePath}");
			}
		}
		
		/// <summary>Reads the file content from the given location</summary>
		/// <param name="location">The location of the file contents</param>
		/// <returns>Returns the contents from the given location</returns>
		/// <remarks>
		/// Preface it with a `file://`, `http://`, `https://`, or `embedded://`
		/// to take it from a specific type of location
		/// </remarks>
		public static string Read(string location) {
			if(string.IsNullOrEmpty(location)) {
				throw new System.Exception("No file location was specified");
			}
			
			// Variables
			FileLocationType locationType = GetLocationType(location);
			string trueLocation = GetLocation(location, locationType);
			
			FS.frameDistance = 2;
			switch(locationType) {
				default:
				case FileLocationType.Default: return ReadFromFile(trueLocation);
				case FileLocationType.Embedded: return ReadFromEmbedded(trueLocation);
				case FileLocationType.Http:
				case FileLocationType.Https: return ReadFromWeb(trueLocation);
			}
		}
		
		/// <summary>Reads the file from the default file system</summary>
		/// <param name="filepath">The path to the file</param>
		/// <returns>Returns the file contents from the default file system</returns>
		public static string ReadFromFile(string filepath) { return File.ReadAllText(filepath); }
		
		/// <summary>Reads the file from the web</summary>
		/// <param name="webpath">The web path to the file</param>
		/// <returns>Returns the file contents from the web</returns>
		public static string ReadFromWeb(string webpath) {
			// Variables
			string results = "";
			
			using(HttpClient client = new HttpClient()) {
				// Variables
				HttpResponseMessage res = RunSync<HttpResponseMessage>(async () => await client.GetAsync(webpath));
				
				results = RunSync<string>(async () => await res.Content.ReadAsStringAsync());
			}
			
			return results;
		}
		
		/// <summary>Reads from the embedded resource</summary>
		/// <param name="embeddedpath">The path to the embedded resource</param>
		/// <returns>Returns the file contents from the embedded resource</returns>
		public static string ReadFromEmbedded(string embeddedpath) {
			// Variables
			StackFrame frame = (new StackTrace()).GetFrame(FS.frameDistance);
			MethodBase method;
			System.Type type;
			Assembly assembly;
			
			FS.frameDistance = 1;
			method = frame.GetMethod();
			type = method.DeclaringType;
			assembly = type.Assembly;
			
			if(assembly != null) {
				using(Stream resourceStream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{embeddedpath}")) {
					if(resourceStream != null) {
						using(StreamReader reader = new StreamReader(resourceStream)) {
							return reader.ReadToEnd();
						}
					}
				}
			}
			
			return "";
		}
		
		/// <summary>Reads the embedded file from the path and specific assembly to look into</summary>
		/// <param name="embeddedpath">The path to the embedded file</param>
		/// <param name="assembly">
		/// The assembly that holds the embedded file. Can be found by grabbing it from a type that
		/// the assembly implements:
		/// ```csharp
		/// typeof(TypeFromTheAssembly).Assembly
		/// ```
		/// </param>
		/// <returns>Returns the contents of the embedded file</returns>
		public static string ReadFromEmbedded(string embeddedpath, Assembly assembly) {
			if(assembly == null) {
				FS.frameDistance = 2;
				return ReadFromEmbedded(embeddedpath);
			}
			using(Stream resourceStream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{embeddedpath}")) {
				if(resourceStream != null) {
					using(StreamReader reader = new StreamReader(resourceStream)) {
						return reader.ReadToEnd();
					}
				}
			}
			
			return "";
		}
		
		#endregion // Read Methods
		
		#region ReadStream Methods
		
		/// <summary>Reads the stream from the given asset location</summary>
		/// <param name="location">The location of the asset to read from</param>
		/// <returns>Returns the stream from the asset location</returns>
		public static Stream ReadStream(AssetLocation location) {
			FS.frameDistance = 2;
			switch(location.FileLocationType) {
				default:
				case FileLocationType.Default: return ReadStreamFromFile(location.FilePath);
				case FileLocationType.Embedded: return ReadStreamFromEmbedded(location.FilePath);
				case FileLocationType.Http: return ReadStreamFromWeb($"http://{location.FilePath}");
				case FileLocationType.Https: return ReadStreamFromWeb($"https://{location.FilePath}");
			}
		}
		
		/// <summary>Reads the string from the given location</summary>
		/// <param name="location">The file location to read from</param>
		/// <returns>Returns the stream from the location</returns>
		public static Stream ReadStream(string location) {
			if(string.IsNullOrEmpty(location)) {
				throw new System.Exception("No file location was specified");
			}
			
			// Variables
			FileLocationType locationType = GetLocationType(location);
			string trueLocation = GetLocation(location, locationType);
			
			FS.frameDistance = 2;
			switch(locationType) {
				default:
				case FileLocationType.Default: return ReadStreamFromFile(trueLocation);
				case FileLocationType.Embedded: return ReadStreamFromEmbedded(trueLocation);
				case FileLocationType.Http:
				case FileLocationType.Https: return ReadStreamFromWeb(trueLocation);
			}
		}
		
		/// <summary>Reads the file and returns the stream</summary>
		/// <param name="filepath">The path to the file being read</param>
		/// <returns>Returns the stream of the file being read</returns>
		public static Stream ReadStreamFromFile(string filepath) { return File.OpenRead(filepath); }
		
		/// <summary>Reads the webpage and returns the stream</summary>
		/// <param name="webpath">The webpage to read from</param>
		/// <returns>Returns the stream of the webpage</returns>
		public static Stream ReadStreamFromWeb(string webpath) {
			// Variables
			Stream results;
			
			using(HttpClient client = new HttpClient()) {
				// Variables
				HttpResponseMessage res = RunSync<HttpResponseMessage>(async () => await client.GetAsync(webpath));
				
				results = RunSync<Stream>(async () => await res.Content.ReadAsStreamAsync());
			}
			
			return results;
		}
		
		/// <summary>Reads the embedded file and returns the stream</summary>
		/// <param name="embeddedpath">The embedded path to read from</param>
		/// <returns>Returns the stream of the embedded file</returns>
		public static Stream ReadStreamFromEmbedded(string embeddedpath) {
			// Variables
			StackFrame frame = (new StackTrace()).GetFrame(FS.frameDistance);
			MethodBase method;
			System.Type type;
			Assembly assembly;
			
			FS.frameDistance = 1;
			method = frame.GetMethod();
			type = method.DeclaringType;
			assembly = type.Assembly;
			
			if(assembly != null) {
				return assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{embeddedpath}");
			}
			
			return null;
		}
		
		#endregion // ReadStream Methods
		
		#region Write Methods
		
		/// <summary>Writes the content to the file given the asset's location</summary>
		/// <param name="location">The location of the asset</param>
		/// <param name="content">The contents to write into a file</param>
		public static void Write(AssetLocation location, string content) { WriteToFile(location.FilePath, content); }
		
		/// <summary>Writes the content to the file given the file location</summary>
		/// <param name="location">The location of the file</param>
		/// <param name="content">The contents to write into a file</param>
		public static void Write(string location, string content) {
			if(location == null || location == "") {
				throw new System.Exception("No file location was specified");
			}
			
			if(location.Contains("://")) {
				// Variables
				string[] typeLocation = location.Split("://");
				
				switch(typeLocation[0]) {
					default:
					case "file": {
						WriteToFile(typeLocation[1], content);
					} return;
				}
			}
			
			WriteToFile(location, content);
		}
		
		/// <summary>Write to the file using the file path</summary>
		/// <param name="filepath">The path to the file</param>
		/// <param name="content">The contents to write to the file</param>
		public static void WriteToFile(string filepath, string content) { File.WriteAllText(filepath, content); }
		
		#endregion // Write Methods
		
		#region Delete Methods
		
		/// <summary>Deletes the file given the asset location</summary>
		/// <param name="location">The location to the asset</param>
		/// <returns>Returns true if the file existed and has been deleted</returns>
		public static bool Delete(AssetLocation location) { return Delete(location.FilePath); }
		
		/// <summary>Deletes the file given the location</summary>
		/// <param name="location">The location to the file</param>
		/// <returns>Returns true if the file existed and has been deleted</returns>
		public static bool Delete(string location) {
			if(location == null || location == "") {
				throw new System.Exception("No file location was specified");
			}
			
			if(location.Contains("://")) {
				// Variables
				string[] typeLocation = location.Split("://");
				
				switch(typeLocation[0]) {
					default:
					case "file": return DeleteFile(typeLocation[1]);
				}
			}
			
			return DeleteFile(location);
		}
		
		/// <summary>Deletes the file given the path</summary>
		/// <param name="filepath">The path to the file</param>
		/// <returns>Returns true if the file existed and has been deleted</returns>
		public static bool DeleteFile(string filepath) {
			if(File.Exists(filepath)) {
				File.Delete(filepath);
				return true;
			}
			return false;
		}
		
		#endregion // Delete Methods
		
		#endregion // Public Static Methods
		
		#region Private Static Methods
		
		/// <summary>Gets the location given the full location</summary>
		/// <param name="location">The full location of the file</param>
		/// <param name="locationType">The type of file location</param>
		/// <returns>Returns the location of the file relative to the type of location</returns>
		private static string GetLocation(string location, FileLocationType locationType) {
			if(location.Contains("://")) {
				// Variables
				string[] typeLocation = location.Split("://");
				
				switch(locationType) {
					default:
					case FileLocationType.Default:
					case FileLocationType.Embedded:
						return typeLocation[1];
					case FileLocationType.Http:
					case FileLocationType.Https:
						return location;
				}
			}
			
			return location;
		}
		
		/// <summary>Gets the location type from the given string location</summary>
		/// <param name="location">The location of the file</param>
		/// <returns>Returns the file location type</returns>
		private static FileLocationType GetLocationType(string location) {
			if(location.Contains("://")) {
				// Variables
				string[] typeLocation = location.Split("://");
				
				switch(typeLocation[0]) {
					default:
					case "file": return FileLocationType.Default;
					case "http": return FileLocationType.Http;
					case "https": return FileLocationType.Https;
					case "embedded": return FileLocationType.Embedded;
				}
			}
			return FileLocationType.Default;
		}
		
		/// <summary>Runs the asynchronous method as a synchronous method</summary>
		/// <param name="func">The function that runs the asynchronous method as synchronous</param>
		/// <typeparam name="T">The type to return</typeparam>
		/// <returns>Returns the results of the asynchronous method</returns>
		private static T RunSync<T>(System.Func<Task<T>> func) {
			// Variables
			CultureInfo ui = CultureInfo.CurrentUICulture;
			CultureInfo culture = CultureInfo.CurrentCulture;
			
			return Factory.StartNew<Task<T>>(delegate() {
				Thread.CurrentThread.CurrentCulture = culture;
				Thread.CurrentThread.CurrentUICulture = ui;
				
				return func();
			}).Unwrap<T>().GetAwaiter().GetResult();
		}
		
		#endregion // Private Static Methods
	}
}
