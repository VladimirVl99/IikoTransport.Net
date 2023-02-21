using IikoTransport.Net.Entities.Common.Customers;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.Orders.Customers
{
    /// <summary>
    /// Customer info.
    /// </summary>
    [JsonObject]
    public class Customer : CustomerShort
    {
        /// <summary>
        /// Is client in blacklist.
        /// </summary>
        [JsonProperty(PropertyName = "inBlacklist", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? InBlacklist { get; set; }

        /// <summary>
        /// Reason why client was added to blacklist.
        /// </summary>
        [JsonProperty(PropertyName = "blacklistReason", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? BlacklistReason { get; set; }
    }
}
