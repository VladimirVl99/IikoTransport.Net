using IikoTransport.Net.Entities.Responses.General.Operations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.General.Organizations.AvailableOrganizations
{
    /// <summary>
    /// Contains organizations available to api-login user.
    /// Source: https://api-ru.iiko.services/#tag/Organizations.
    /// </summary>
    [JsonObject]
    public class OrganizationInfo : OperationInfo
    {
        /// <summary>
        /// List of organizations. Can be obtained by
        /// https://api-ru.iiko.services/api/1/organizations operation.
        /// </summary>
        [JsonProperty(PropertyName = "organizations", Required = Required.Always)]
        public IEnumerable<Organization> Organizations { get; set; } = default!;
    }
}
