using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.General.Terminals.GroupsOfDeliveryTerminals
{
    /// <summary>
    /// Contains information about the terminal group.
    /// </summary>
    [JsonObject]
    public class TerminalGroup
    {
        private string _timeZone = string.Empty;


        /// <summary>
        /// Delivery group ID.
        /// Can be obtained by https://api-ru.iiko.services/api/1/terminal_groups operation.
        /// </summary>
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public Guid Id { get; set; }

        /// <summary>
        /// Organization ID to which delivery group belongs.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.
        /// </summary>
        [JsonProperty(PropertyName = "organizationId", Required = Required.Always)]
        public Guid OrganizationId { get; set; }

        /// <summary>
        /// Terminal group name.
        /// </summary>
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        public string Name { get; set; } = default!;

        /// <summary>
        /// Terminal group time zone.
        /// </summary>
        [JsonProperty(PropertyName = "timeZone", Required = Required.Always)]
        public string TimeZoneAsString
        {
            get => _timeZone;
            set => _timeZone = value ?? default!;
        }

        [JsonIgnore]
        public TimeSpan TimeZone
            => TimeSpan.TryParse(_timeZone, out var result) ? result : TimeSpan.Zero;
    }
}
