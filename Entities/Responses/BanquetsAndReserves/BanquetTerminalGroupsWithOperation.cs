using IikoTransport.Net.Entities.Responses.General.Terminals.GroupsOfDeliveryTerminals;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.BanquetsAndReserves
{
    /// <summary>
    /// All terminal groups of specified organizations,
    /// for which banquet/reserve booking are available.
    /// Source: https://api-ru.iiko.services/#tag/Banquetsreserves/paths/~1api~11~1reserve~1available_terminal_groups/post.
    /// </summary>
    [JsonObject]
    public class BanquetTerminalGroupsWithOperation : DeliveryTerminalGroupInfo
    {
        /// <summary>
        /// Terminal groups are in sleep mode because they are not active.
        /// Can be awakened by https://api-ru.iiko.services/api/1/terminal_groups/awake operation.
        /// </summary>
        [JsonProperty(PropertyName = "terminalGroupsInSleep", Required = Required.Always)]
        public new IEnumerable<TerminalInfo> TerminalGroupsInSleep { get; set; } = default!;
    }
}
