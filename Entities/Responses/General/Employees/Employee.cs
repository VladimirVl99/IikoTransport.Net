using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.General.Employees
{
    /// <summary>
    /// Employee info.
    /// </summary>
    [JsonObject]
    public class Employee : EmployeeShort
    {
        /// <summary>
        /// Email.
        /// </summary>
        [JsonProperty(PropertyName = "email", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Email { get; set; }

        /// <summary>
        /// Phone.
        /// </summary>
        [JsonProperty(PropertyName = "phone", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Phone { get; set; }

        /// <summary>
        /// Cell phone.
        /// </summary>
        [JsonProperty(PropertyName = "cellPhone", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? CellPhone { get; set; }
    }
}
