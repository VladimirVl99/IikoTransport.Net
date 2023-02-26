using IikoTransport.Net.Entities.Common.Date;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.LoyaltyAndDiscounts.Customers
{
    /// <summary>
    /// Customer's card.
    /// </summary>
    [JsonObject]
    public class GuestCardInfo
    {
        /// <summary>
        /// Card id.
        /// </summary>
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public Guid Id { get; set; }

        /// <summary>
        /// Card track.
        /// </summary>
        [JsonProperty(PropertyName = "track", Required = Required.Always)]
        public string Track { get; set; } = default!;

        /// <summary>
        /// Card number.
        /// </summary>
        [JsonProperty(PropertyName = "number", Required = Required.Always)]
        public string Number { get; set; } = default!;

        /// <summary>
        /// Card valid to date.
        /// </summary>
        [JsonProperty(PropertyName = "validToDate", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd HH:mm:ss.fff")]
        public DateTime? ValidToDate { get; set; }
    }
}
