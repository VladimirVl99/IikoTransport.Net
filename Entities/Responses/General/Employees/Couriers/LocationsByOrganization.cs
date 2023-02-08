using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.General.Employees.Couriers
{
    /// <summary>
    /// Contains information about a driver's coordinates broken down by organization.
    /// </summary>
    [JsonObject]
    public class LocationsByOrganization
    {
        /// <summary>
        /// Organization ID.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.
        /// </summary>
        [JsonProperty(PropertyName = "organizationId", Required = Required.Always)]
        public Guid OrganizationId { get; set; }

        /// <summary>
        /// Items for organization.
        /// </summary>
        [JsonProperty(PropertyName = "items", Required = Required.Always)]
        public IEnumerable<Locations> Items { get; set; } = default!;
    }
}
