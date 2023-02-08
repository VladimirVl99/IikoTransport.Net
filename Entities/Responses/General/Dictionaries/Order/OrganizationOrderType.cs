using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.General.Dictionaries.Order
{
    /// <summary>
    /// Contains list of order types.
    /// </summary>
    [JsonObject]
    public class OrganizationOrderType
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
        public IEnumerable<OrderType> Items { get; set; } = default!;
    }
}
