using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.Orders.Payments
{
    /// <summary>
    /// Payment type.
    /// </summary>
    [JsonObject]
    public class PaymentType
    {
        /// <summary>
        /// ID.
        /// </summary>
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public Guid Id { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        public string Name { get; set; } = default!;

        /// <summary>
        /// Payment type classifier.
        /// </summary>
        [JsonProperty(PropertyName = "kind", Required = Required.Always)]
        public PaymentClassifier Kind { get; set; }
    }
}
