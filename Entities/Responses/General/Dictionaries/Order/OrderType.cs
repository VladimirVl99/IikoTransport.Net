using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.General.Dictionaries.Order
{
    /// <summary>
    /// Contains items for organization.
    /// </summary>
    [JsonObject]
    public class OrderType : OrderTypeShort
    {
        /// <summary>
        /// IsDeleted attribute of order type.
        /// </summary>
        [JsonProperty(PropertyName = "isDeleted", Required = Required.Default)]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// External system revision number.
        /// </summary>
        [JsonProperty(PropertyName = "externalRevision", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long? ExternalRevision { get; set; }
    }
}
