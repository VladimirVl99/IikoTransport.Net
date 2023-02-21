using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.Delivery.DeliveryRestrictions
{
    /// <summary>
    /// Range of house numbers in the delivery zone.
    /// </summary>
    [JsonObject]
    public class DeliveryZoneHouse
    {
        /// <summary>
        /// Enum: 0 1 2 3.
        /// Type of house number range.
        /// </summary>
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        public int Type { get; set; }

        /// <summary>
        /// Starting house number.
        /// </summary>
        [JsonProperty(PropertyName = "startingNumber", Required = Required.Always)]
        public int StartingNumber { get; set; }

        /// <summary>
        /// Maximum house number.
        /// </summary>
        [JsonProperty(PropertyName = "maxNumber", Required = Required.Always)]
        public int MaxNumber { get; set; }

        /// <summary>
        /// Unlimited range.
        /// </summary>
        [JsonProperty(PropertyName = "isUnlimitedRange", Required = Required.Always)]
        public bool IsUnlimitedRange { get; set; }

        /// <summary>
        /// Specific numbers.
        /// </summary>
        [JsonProperty(PropertyName = "specificNumbers", Required = Required.Always)]
        public IEnumerable<string> SpecificNumbers { get; set; } = default!;
    }
}
