using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IikoTransport.Net.Entities.Requests.Orders.Loyalties
{
    /// <summary>
    /// Information about a discount/surcharges.
    /// </summary>
    [JsonObject]
    public class Discount
    {
        /// <summary>
        /// Discount type.
        /// Can be obtained by https://api-ru.iiko.services/api/1/discounts operation.
        /// </summary>
        [JsonProperty(PropertyName = "discountTypeId", Required = Required.Always)]
        public Guid DiscountTypeId { get; set; }

        /// <summary>
        /// Discount/surcharge sum.
        /// </summary>
        [JsonProperty(PropertyName = "sum", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double Sum { get; set; }

        /// <summary>
        /// Order item positions.
        /// </summary>
        [JsonProperty(PropertyName = "selectivePositions", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<Guid>? SelectivePositions { get; set; }

        /// <summary>
        /// Discount type.
        /// </summary>
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public DiscountType Type { get; set; }
    }
}
