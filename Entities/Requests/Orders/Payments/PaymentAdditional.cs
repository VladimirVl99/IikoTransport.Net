using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IikoTransport.Net.Entities.Requests.Orders.Payments
{
    /// <summary>
    /// Additional payment parameters.
    /// </summary>
    [JsonObject]
    public class PaymentAdditional
    {
        /// <summary>
        /// Guest credential, authorizing payment.
        /// </summary>
        [JsonProperty(PropertyName = "credential", Required = Required.Always)]
        public string Credential { get; set; } = default!;

        /// <summary>
        /// Guest credential search scope.
        /// </summary>
        [JsonProperty(PropertyName = "searchScope", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public SearchScope SearchScope { get; set; }

        /// <summary>
        /// Type.
        /// </summary>
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentAdditionalType Type { get; set; }
    }
}
