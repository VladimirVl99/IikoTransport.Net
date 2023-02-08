using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.General.Employees
{
    /// <summary>
    /// Contains information of an employee.
    /// </summary>
    [JsonObject]
    public class EmployeeShort
    {
        /// <summary>
        /// Employee ID.
        /// </summary>
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public Guid Id { get; set; }

        /// <summary>
        /// Name of user.
        /// </summary>
        [JsonProperty(PropertyName = "firstName", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? FirstName { get; set; }

        /// <summary>
        /// Second name.
        /// </summary>
        [JsonProperty(PropertyName = "middleName", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? MiddleName { get; set; }

        /// <summary>
        /// Last name.
        /// </summary>
        [JsonProperty(PropertyName = "lastName", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? LastName { get; set; }

        /// <summary>
        /// Displayed name (system name).
        /// </summary>
        [JsonProperty(PropertyName = "displayName", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? DisplayName { get; set; }

        /// <summary>
        /// Code.
        /// </summary>
        [JsonProperty(PropertyName = "code", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Code { get; set; }

        /// <summary>
        /// User deletion flag.
        /// </summary>
        [JsonProperty(PropertyName = "isDeleted", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool IsDeleted { get; set; }
    }
}
