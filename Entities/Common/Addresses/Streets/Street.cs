using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Common.Addresses.Streets
{
	/// <summary>
	/// Information about a street.
	/// </summary>
	[JsonObject]
	public class Street : StreetShort
	{
		/// <summary>
		/// External system revision No.
		/// </summary>
		[JsonProperty(PropertyName = "externalRevision", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public long? ExternalRevision { get; set; }

		/// <summary>
		/// ID in classifier, e.g., address database.
		/// </summary>
		[JsonProperty(PropertyName = "classifierId", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string? ClassifierId { get; set; }

		/// <summary>
		/// Is-Deleted attribute.
		/// </summary>
		[JsonProperty(PropertyName = "isDeleted", Required = Required.Always)]
		public bool IsDeleted { get; set; }
	}
}
