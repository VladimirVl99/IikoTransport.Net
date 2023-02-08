using IikoTransport.Net.Entities.Responses.General.Operations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.General.Dictionaries.Order
{
    /// <summary>
    /// Contains information about order types.
    /// Source: https://api-ru.iiko.services/#tag/Dictionaries/paths/~1api~11~1deliveries~1order_types/post.
    /// </summary>
    [JsonObject]
    public class OrderTypeInfo : OperationInfo
    {
        /// <summary>
        /// List of order types.
        /// </summary>
        [JsonProperty(PropertyName = "orderTypes", Required = Required.Always)]
        public IEnumerable<OrganizationOrderType> OrderTypes { get; set; } = default!;
    }
}
