using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.General.Terminals.AvailabilityOfGroupOfTerminals
{
    /// <summary>
    /// Contains availability attribute of each requested terminals.
    /// </summary>
    [JsonObject]
    public class TerminalGroupAliveInfo
    {
        /// <summary>
        /// Attribute that shows whether a terminal is available to request processing.
        /// </summary>
        [JsonProperty(PropertyName = "isAlive", Required = Required.Always)]
        public bool IsAlive { get; set; }

        /// <summary>
        /// ID of front group of terminals. Can be obtained by
        /// https://api-ru.iiko.services/api/1/terminal_groups operation.
        /// </summary>
        [JsonProperty(PropertyName = "terminalGroupId", Required = Required.Always)]
        public Guid TerminalGroupId { get; set; }

        /// <summary>
        /// Organizations ID. Can be obtained by
        /// https://api-ru.iiko.services/api/1/organizations operation.
        /// </summary>
        [JsonProperty(PropertyName = "organizationId", Required = Required.Always)]
        public Guid OrganizationId { get; set; }
    }
}
