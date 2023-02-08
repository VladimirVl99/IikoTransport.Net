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
    public class OrderType
    {
        /// <summary>
        /// Order type ID in RMS.
        /// </summary>
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public Guid Id { get; set; }

        /// <summary>
        /// Order type name.
        /// </summary>
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        public string Name { get; set; } = default!;

        /// <summary>
        /// Enum: "Common" "DeliveryByCourier" "DeliveryPickUp".
        /// Service type.
        /// </summary>
        [JsonProperty(PropertyName = "orderServiceType", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public OrderServiceType OrderServiceType { get; set; }

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
