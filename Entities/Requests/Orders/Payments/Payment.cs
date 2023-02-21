using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IikoTransport.Net.Entities.Requests.Orders.Payments
{
    /// <summary>
    /// Order payment component.
    /// </summary>
    [JsonObject]
    public class Payment
    {
        /// <summary>
        /// Payment type kind.
        /// </summary>
        [JsonProperty(PropertyName = "paymentTypeKind", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentTypeKind PaymentTypeKind { get; set; }

        /// <summary>
        /// Amount due.
        /// </summary>
        [JsonProperty(PropertyName = "sum", Required = Required.Always)]
        public double Sum { get; set; }

        /// <summary>
        /// Payment type.
        /// Can be obtained by https://api-ru.iiko.services/api/1/payment_types operation.
        /// </summary>
        [JsonProperty(PropertyName = "paymentTypeId", Required = Required.Always)]
        public Guid PaymentTypeId { get; set; }

        /// <summary>
        /// Whether payment item is processed by external payment system (made from outside).
        /// </summary>
        [JsonProperty(PropertyName = "isProcessedExternally", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool IsProcessedExternally { get; set; }

        /// <summary>
        /// Additional payment parameters.
        /// </summary>
        [JsonProperty(PropertyName = "paymentAdditionalData", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public PaymentAdditional? PaymentAdditionalData { get; set; }

        /// <summary>
        /// Whether the payment item is externally fiscalized.
        /// Allowed from version 7.6.3.
        /// </summary>
        [JsonProperty(PropertyName = "isFiscalizedExternally", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool IsFiscalizedExternally { get; set; }
    }
}
