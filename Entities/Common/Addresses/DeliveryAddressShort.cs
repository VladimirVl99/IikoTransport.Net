using IikoTransport.Net.Entities.Responses.Delivery.Drafts;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Common.Addresses
{
    /// <summary>
    /// Common information about an order delivery address.
    /// </summary>
    [JsonObject]
    public class DeliveryAddressShort
    {
        /// <summary>
        /// Street.
        /// </summary>
        [JsonProperty(PropertyName = "street", Required = Required.Always)]
        public Street Street { get; set; } = default!;

        /// <summary>
        /// [ 0 .. 10 ] characters.
        /// Postcode.
        /// </summary>
        [JsonProperty(PropertyName = "index", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Index { get; set; }

        /// <summary>
        /// [ 0 .. 100 ] characters.
        /// House.
        /// In case useUaeAddressingSystem enabled max length - 100, otherwise - 10.
        /// </summary>
        [JsonProperty(PropertyName = "house", Required = Required.Always)]
        public string House { get; set; } = default!;

        /// <summary>
        /// [ 0 .. 10 ] characters.
        /// Building.
        /// </summary>
        [JsonProperty(PropertyName = "building", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Building { get; set; }

        /// <summary>
        /// [ 0 .. 100 ] characters.
        /// Apartment.
        /// In case useUaeAddressingSystem enabled max length - 100, otherwise - 10.
        /// </summary>
        [JsonProperty(PropertyName = "flat", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Flat { get; set; }

        /// <summary>
        /// [ 0 .. 10 ] characters.
        /// Entrance.
        /// </summary>
        [JsonProperty(PropertyName = "entrance", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Entrance { get; set; }

        /// <summary>
        /// [ 0 .. 10 ] characters.
        /// Floor.
        /// </summary>
        [JsonProperty(PropertyName = "floor", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Floor { get; set; }

        /// <summary>
        /// [ 0 .. 10 ] characters.
        /// Intercom.
        /// </summary>
        [JsonProperty(PropertyName = "doorphone", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Doorphone { get; set; }

        /// <summary>
        /// Delivery area ID.
        /// </summary>
        [JsonProperty(PropertyName = "regionId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? Region { get; set; }
    }
}
