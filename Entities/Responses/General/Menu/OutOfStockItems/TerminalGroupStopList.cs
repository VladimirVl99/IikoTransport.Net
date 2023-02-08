using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.General.Menu.OutOfStockItems
{
    /// <summary>
    /// Contains information about items for organization.
    /// </summary>
    [JsonObject]
    public class TerminalGroupStopList
    {
        /// <summary>
        /// Terminal ID.
        /// </summary>
        [JsonProperty(PropertyName = "terminalGroupId", Required = Required.Always)]
        public Guid TerminalGroupId { get; set; }

        /// <summary>
        /// Out-of-stock list.
        /// </summary>
        [JsonProperty(PropertyName = "items", Required = Required.Always)]
        public IEnumerable<StopListItem> Items { get; set; } = default!;
    }
}
