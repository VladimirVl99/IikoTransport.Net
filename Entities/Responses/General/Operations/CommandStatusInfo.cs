using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.General.Operations
{
    /// <summary>
    /// Contains information about status of command.
    /// Source: https://api-ru.iiko.services/#tag/Operations/paths/~1api~11~1commands~1status/post.
    /// </summary>
    [JsonObject]
    public class CommandStatusInfo
    {
        /// <summary>
        /// Status of command.
        /// </summary>
        [JsonProperty(PropertyName = "state", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public CommandStatus State { get; set; }
    }
}
