using IikoTransport.Net.Entities.Responses.General.Operations;
using IikoTransport.Net.Entities.Responses.Orders.Errors;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.Orders
{
    /// <summary>
    /// Common information about a created order.
    /// </summary>
    [JsonObject]
    public class OrderInfoShort
    {
        /// <summary>
        /// Order ID.
        /// </summary>
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public Guid Id { get; set; }

        /// <summary>
        /// POS order ID.
        /// </summary>
        [JsonProperty(PropertyName = "externalNumber", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? PosId { get; set; }

        /// <summary>
        /// Order external number.
        /// </summary>
        [JsonProperty(PropertyName = "externalNumber", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? ExternalNumber { get; set; }

        /// <summary>
        /// Organization ID.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.
        /// </summary>
        [JsonProperty(PropertyName = "organizationId", Required = Required.Always)]
        public Guid OrganizationId { get; set; }

        /// <summary>
        /// Timestamp of most recent order change that took place on iikoTransport server.
        /// </summary>
        [JsonProperty(PropertyName = "timestamp", Required = Required.Always)]
        public long Timestamp { get; set; }

        /// <summary>
        /// Enum: "Success" "InProgress" "Error".
        /// Order creation status. In case of asynchronous creation, it allows to track the instance
        /// an order was validated/created in iikoFront.
        /// </summary>
        [JsonProperty(PropertyName = "creationStatus", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public CommandStatus CreationStatus { get; set; }

        /// <summary>
        /// Order creation error details.
        /// Required only if "creationStatus"="Error".
        /// </summary>
        [JsonProperty(PropertyName = "errorInfo", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public ErrorInfo? ErrorInfo { get; set; }
    }
}
