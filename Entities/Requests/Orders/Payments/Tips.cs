using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IikoTransport.Net.Entities.Requests.Orders.Payments
{
    /// <summary>
    /// Order tips component.
    /// </summary>
    [JsonObject]
    public class Tips : Payment
    {
        /// <summary>
        /// Payment type kind.
        /// </summary>
        [JsonProperty(PropertyName = "paymentTypeKind", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public new TipsTypeKind PaymentTypeKind { get; set; }

        /// <summary>
        /// Tips type ID.
        /// Can be obtained by /api/1/tips_types operation.
        /// </summary>
        [JsonProperty(PropertyName = "tipsTypeId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid TipsTypeId { get; set; }
    }
}
