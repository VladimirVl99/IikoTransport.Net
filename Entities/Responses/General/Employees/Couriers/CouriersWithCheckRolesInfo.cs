using IikoTransport.Net.Entities.Responses.General.Operations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.General.Employees.Couriers
{
    /// <summary>
    /// Contains list of all employees which are delivery drivers in specified restaurants,
    /// and checks whether each employee has passed role.
    /// Source: https://api-ru.iiko.services/#tag/Employees/paths/~1api~11~1employees~1couriers~1by_role/post.
    /// </summary>
    [JsonObject]
    public class CouriersWithCheckRolesInfo : OperationInfo
    {
        /// <summary>
        /// List of drivers.
        /// </summary>
        [JsonProperty(PropertyName = "employeesWithCheckRoles", Required = Required.Always)]
        public IEnumerable<CouriersWithCheckRolesByOrganization> EmployeesWithCheckRoles { get; set; } = default!;
    }
}
