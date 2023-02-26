using IikoTransport.Net.Entities.Responses.General.Operations;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.General.Terminals.GroupsOfDeliveryTerminals
{
    /// <summary>
    /// Contains information on groups of delivery terminals.
    /// Source: https://api-ru.iiko.services/#tag/Terminal-groups/paths/~1api~11~1terminal_groups/post.
    /// </summary>
    [JsonObject]
    public class DeliveryTerminalGroupInfo : OperationInfo
    {
        /// <summary>
        /// List of terminal groups broken down by organizations.
        /// </summary>
        [JsonProperty(PropertyName = "terminalGroups", Required = Required.Always)]
        public IEnumerable<TerminalInfo> TerminalGroups { get; set; } = default!;

        /// <summary>
        /// Terminal groups are in sleep mode because they are not active.
        /// Can be awakened by https://api-ru.iiko.services/api/1/terminal_groups/awake operation.
        /// </summary>
        [JsonProperty(PropertyName = "terminalGroupsInSleep", Required = Required.Always)]
        public IEnumerable<TerminalInfo> TerminalGroupsInSleep { get; set; } = default!;
    }
}
