using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.General.Employees
{
    /// <summary>
    /// Checked employee's role.
    /// </summary>
    [JsonObject]
    public class RoleCheckResult
    {
        /// <summary>
        /// Checked for employee role.
        /// </summary>
        [JsonProperty(PropertyName = "checkedRoleCode", Required = Required.Always)]
        public string CheckedRoleCode { get; set; } = default!;

        /// <summary>
        /// Sign that employee has role "checkedRoleCode".
        /// </summary>
        [JsonProperty(PropertyName = "employeeHasRole", Required = Required.Always)]
        public bool EmployeeHasRole { get; set; }
    }
}
