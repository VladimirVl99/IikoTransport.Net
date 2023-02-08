using IikoTransport.Net.Entities.Responses.General.Operations;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.General.Menu.OutOfStockItems
{
    /// <summary>
    /// Contains information about out-of-stock items.
    /// </summary>
    [JsonObject]
    public class OutOfStockInfo : OperationInfo
    {
        /// <summary>
        /// Set of out-of-stock lists.
        /// </summary>
        [JsonProperty(PropertyName = "terminalGroupStopLists", Required = Required.Always)]
        public IEnumerable<StopList> TerminalGroupStopLists { get; set; } = default!;
    }
}
