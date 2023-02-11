using IikoTransport.Net.Entities.Common.Addresses.Regions;
using IikoTransport.Net.Entities.Common.Addresses.Streets;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Common.Addresses
{
    /// <summary>
    /// Delivery address details.
    /// </summary>
    [JsonObject]
	public class Address
	{
		/// <summary>
		/// Street.
		/// </summary>
		[JsonProperty(PropertyName = "street", Required = Required.Always)]
		public StreetShort Street { get; set; } = default!;

		/// <summary>
		/// Postcode.
		/// </summary>
		[JsonProperty(PropertyName = "index", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string? Index { get; set; }

		/// <summary>
		/// House.
		/// </summary>
		[JsonProperty(PropertyName = "house", Required = Required.Always)]
		public string House { get; set; } = default!;

		/// <summary>
		/// Building.
		/// </summary>
		[JsonProperty(PropertyName = "building", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string? Building { get; set; }

		/// <summary>
		/// Apartment.
		/// </summary>
		[JsonProperty(PropertyName = "flat", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string? Flat { get; set; }

		/// <summary>
		/// Entrance.
		/// </summary>
		[JsonProperty(PropertyName = "entrance", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string? Entrance { get; set; }

		/// <summary>
		/// Floor.
		/// </summary>
		[JsonProperty(PropertyName = "floor", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string? Floor { get; set; }

		/// <summary>
		/// Intercom.
		/// </summary>
		[JsonProperty(PropertyName = "doorphone", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string? Doorphone { get; set; }

		/// <summary>
		/// Region.
		/// </summary>
		[JsonProperty(PropertyName = "region", Required = Required.Always)]
		public RegionShort? Region { get; set; }
	}
}
