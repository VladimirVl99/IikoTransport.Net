using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.General.Menu.OutOfStockItems
{
    /// <summary>
    /// Contains information about out-of-stock list.
    /// </summary>
    [JsonObject]
    public class StopListItem
    {
        /// <summary>
        /// Product balance.
        /// </summary>
        [JsonProperty(PropertyName = "balance", Required = Required.Always)]
        public double Balance { get; set; }

        /// <summary>
        /// Out-of-stock list product ID.
        /// </summary>
        [JsonProperty(PropertyName = "productId", Required = Required.Always)]
        public Guid ProductId { get; set; }
    }
}
