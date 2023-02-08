using IikoTransport.Net.Entities.Responses.General.Dictionaries.Order;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.General.Dictionaries.TipsTypes
{
    /// <summary>
    /// Contains information about tips type for rms group.
    /// </summary>
    [JsonObject]
    public class TipsType
    {
        /// <summary>
        /// Tips type ID.
        /// Can be obtained by https://api-ru.iiko.services/api/1/tips_types operation.
        /// </summary>
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public Guid Id { get; set; }

        /// <summary>
        /// Tips type name.
        /// </summary>
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        public string Name { get; set; } = default!;

        /// <summary>
        /// Supported organizations IDs.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.
        /// </summary>
        [JsonProperty(PropertyName = "organizationIds", Required = Required.Always)]
        public IEnumerable<Guid> OrganizationIds { get; set; } = default!;

        /// <summary>
        /// Items Enum: "Common" "DeliveryByCourier" "DeliveryPickUp".
        /// Supported order service types.
        /// </summary>
        [JsonProperty(PropertyName = "orderServiceTypes", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public IEnumerable<OrderServiceType> OrderServiceTypes { get; set; } = default!;

        /// <summary>
        /// Supported payment types IDs.
        /// </summary>
        [JsonProperty(PropertyName = "paymentTypesIds", Required = Required.Always)]
        public IEnumerable<Guid> PaymentTypeIds { get; set; } = default!;
    }
}
