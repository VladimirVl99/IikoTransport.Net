using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Requests.Orders.Payments
{
    /// <summary>
    /// Order tips component.
    /// </summary>
    [JsonObject]
    public class Tips : Payment
    {
        /// <summary>
        /// Tips type ID.
        /// Can be obtained by /api/1/tips_types operation.
        /// </summary>
        [JsonProperty(PropertyName = "tipsTypeId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid TipsTypeId { get; set; }
    }
}
