
namespace B3.Management {
	/// <summary>A class that gives you the information of the location to an asset and what manager it should be delegated to</summary>
	public class AssetLocation {
		#region Field Variables
		// Variables
		// private ManagerType managerType;
		private System.Type type;
		private FileLocationType fileLocationType;
		private string filePath;
		private string name;
		
		#endregion // Field Variables
		
		#region Public Properties
		
		// /// <summary>Gets the type of manager that the asset should go to</summary>
		// public ManagerType ManagerType { get { return this.managerType; } }
		
		/// <summary>Gets the type for the asset to cast to</summary>
		public System.Type Type { get { return this.type; } }
		
		/// <summary>Gets the type of file location where the asset is located at</summary>
		public FileLocationType FileLocationType { get { return this.fileLocationType; } }
		
		/// <summary>Gets the path to the file</summary>
		public string FilePath { get { return this.filePath; } }
		
		/// <summary>Gets the name of the asset</summary>
		public string Name { get { return this.name; } }
		
		#endregion // Public Properties
		
		#region Public Constructors
		
		/// <summary>A base class for creating an asset location</summary>
		/// <param name="type">The type for the asset to cast to</param>
		/// <param name="fileLocationType">The type of file location where the asset is located at</param>
		/// <param name="filePath">The path to the file</param>
		/// <param name="name">The name of the asset</param>
		public AssetLocation(
			// ManagerType managerType,
			System.Type type,
			FileLocationType fileLocationType,
			string filePath,
			string name
		) {
			// this.managerType = managerType;
			this.type = type;
			this.fileLocationType = fileLocationType;
			this.filePath = filePath;
			this.name = name;
		}
		
		#endregion // Public Constructors
	}
}
