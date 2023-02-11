using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Common.Addresses.Regions
{
	/// <summary>
	/// Information about a region.
	/// </summary>
	[JsonObject]
	public class Region : RegionShort
	{
		/// <summary>
		/// External revision.
		/// </summary>
		[JsonProperty(PropertyName = "externalRevision", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public long? ExternalRevision { get; set; }

		/// <summary>
		/// Is-Deleted attribute.
		/// </summary>
		[JsonProperty(PropertyName = "isDeleted", Required = Required.Always)]
		public bool IsDeleted { get; set; }
	}
}
