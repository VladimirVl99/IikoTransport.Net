using IikoTransport.Net.Entities.Responses.General.Operations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.General.Terminals.AvailabilityOfGroupOfTerminals
{
    /// <summary>
    /// Contains information on availability of group or terminals.
    /// Source: https://api-ru.iiko.services/#tag/Terminal-groups/paths/~1api~11~1terminal_groups~1is_alive/post.
    /// </summary>
    [JsonObject]
    public class AvailabilityTerminalGroup : OperationInfo
    {
        /// <summary>
        /// Availability attribute of each requested terminal.
        /// </summary>
        [JsonProperty(PropertyName = "isAliveStatus", Required = Required.Always)]
        public IEnumerable<TerminalGroupAliveInfo> IsAliveStatus { get; set; } = default!;
    }
}
