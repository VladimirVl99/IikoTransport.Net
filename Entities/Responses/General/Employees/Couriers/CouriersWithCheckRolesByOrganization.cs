using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.General.Employees.Couriers
{
    /// <summary>
    /// Contains information about an employee with checked roles of organization.
    /// </summary>
    [JsonObject]
    public class CouriersWithCheckRolesByOrganization
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
        public IEnumerable<EmployeeWithCheckedRole> Items { get; set; } = default!;
    }
}
