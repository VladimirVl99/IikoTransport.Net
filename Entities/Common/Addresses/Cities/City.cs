using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Common.Addresses.Cities
{
	/// <summary>
	/// Information about a city.
	/// </summary>
	[JsonObject]
	public class City : CityShort
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

		/// <summary>
		/// ID in classifier, e.g., address database.
		/// </summary>
		[JsonProperty(PropertyName = "classifierId", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string? ClassifierId { get; set; }

		/// <summary>
		/// City additional information.
		/// </summary>
		[JsonProperty(PropertyName = "additionalInfo", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string? AdditionalInfo { get; set; }
	}
}
