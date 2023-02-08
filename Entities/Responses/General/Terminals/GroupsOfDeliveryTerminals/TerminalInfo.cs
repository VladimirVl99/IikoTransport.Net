using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.General.Terminals.GroupsOfDeliveryTerminals
{
    /// <summary>
    /// Contains information on terminal group broken down by organizations.
    /// </summary>
    [JsonObject]
    public class TerminalInfo
    {
        /// <summary>
        /// Organization ID. Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.
        /// </summary>
        [JsonProperty(PropertyName = "organizationId", Required = Required.Always)]
        public Guid OrganizationId { get; set; }

        /// <summary>
        /// Items for organization.
        /// </summary>
        [JsonProperty(PropertyName = "items", Required = Required.Always)]
        public IEnumerable<TerminalGroup> Items { get; set; } = default!;
    }
}
