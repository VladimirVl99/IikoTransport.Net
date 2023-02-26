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
        /// Card program ID.
        /// </summary>
        [JsonProperty(PropertyName = "programId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? ProgramId { get; set; }

        /// <summary>
        /// Card program name.
        /// </summary>
        [JsonProperty(PropertyName = "programName", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? ProgramName { get; set; }

        /// <summary>
        /// Discount information for order items.
        /// </summary>
        [JsonProperty(PropertyName = "discountItems", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<IikoCardDiscountItem>? DiscountItems { get; set; }

        /// <summary>
        /// Discount type.
        /// Can be obtained by https://api-ru.iiko.services/api/1/discounts operation.
        /// </summary>
        [JsonProperty(PropertyName = "discountTypeId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? DiscountTypeId { get; set; }

        /// <summary>
        /// Discount/surcharge sum.
        /// </summary>
        [JsonProperty(PropertyName = "sum", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double? Sum { get; set; }

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
