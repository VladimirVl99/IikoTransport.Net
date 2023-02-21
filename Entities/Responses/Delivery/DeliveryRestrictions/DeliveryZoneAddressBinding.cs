using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.Delivery.DeliveryRestrictions
{
	/// <summary>
	/// Address describing a polygon.
	/// </summary>
	[JsonObject]
	public class DeliveryZoneAddressBinding
	{
        /// <summary>
        /// ID of the delivery zone's street.
        /// </summary>
        [JsonProperty(PropertyName = "streetId", Required = Required.Always)]
        public Guid StreetId { get; set; }

        /// <summary>
        /// Postcode.
        /// </summary>
        [JsonProperty(PropertyName = "postcode", Required = Required.Always)]
        public string Postcode { get; set; } = default!;

        /// <summary>
        /// Range of house numbers in the delivery zone.
        /// </summary>
        [JsonProperty(PropertyName = "houses", Required = Required.Always)]
        public DeliveryZoneHouse Houses { get; set; } = default!;
	}
}
