using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.General.Menu.OutOfStockItems
{
    /// <summary>
    /// Terminal group with out-of-stock list update.
    /// </summary>
    [JsonObject]
    public class TerminalGroupStopListUpdate
    {
        /// <summary>
        /// Terminal ID.
        /// </summary>
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public Guid Id { get; set; }

        /// <summary>
        /// Whether out-of-stock list is fully updated.
        /// </summary>
        [JsonProperty(PropertyName = "isFull", Required = Required.Always)]
        public bool IsFull { get; set; }
    }
}
