using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.General.Employees
{
    /// <summary>
    /// Contains information of employee with checed roles.
    /// </summary>
    [JsonObject]
    public class EmployeeWithCheckedRole : EmployeeShort
    {
        /// <summary>
        /// Result of check employee's roles.
        /// </summary>
        [JsonProperty(PropertyName = "checkRolesResult", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<RoleCheckResult>? CheckRolesResult { get; set; }
    }
}
