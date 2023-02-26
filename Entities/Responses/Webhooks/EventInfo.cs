using IikoTransport.Net.Entities.Common.Orders.Errors;
using IikoTransport.Net.Entities.Responses.General.Menu.OutOfStockItems;
using IikoTransport.Net.Entities.Responses.General.Operations;
using IikoTransport.Net.Entities.Responses.Webhooks.Orders;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IikoTransport.Net.Entities.Responses.Webhooks
{
    /// <summary>
    /// Information about a webHooks' event.
    /// </summary>
    [JsonObject]
    public class EventInfo
    {
        /// <summary>
        /// Order ID.
        /// Also can be an employee ID when eventType equals 'PersonalShift'.
        /// </summary>
        [JsonProperty(PropertyName = "id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? Id { get; set; }

        /// <summary>
        /// POS delivery order ID.
        /// </summary>
        [JsonProperty(PropertyName = "posId", DefaultValueHandling = DefaultValueHandling.Ignore)]
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
        [JsonProperty(PropertyName = "organizationId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? OrganizationId { get; set; }

        /// <summary>
        /// Timestamp of most recent order change that took place on iikoTransport server.
        /// </summary>
        [JsonProperty(PropertyName = "timestamp", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long? Timestamp { get; set; }

        /// <summary>
        /// Order creation status. In case of asynchronous creation,
        /// it allows to track the instance an order was validated/created in iikoFront.
        /// </summary>
        [JsonProperty(PropertyName = "creationStatus", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public CommandStatus? CreationStatus { get; set; }

        /// <summary>
        /// Order creation error details.
        /// </summary>
        [JsonProperty(PropertyName = "errorInfo", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public ErrorInfo? ErrorInfo { get; set; }

        /// <summary>
        /// Banquet/reserve is deleted.
        /// </summary>
        [JsonProperty(PropertyName = "isDeleted", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? IsDeleted { get; set; }

        /// <summary>
        /// Terminal groups with out-of-stock list updates.
        /// </summary>
        [JsonProperty(PropertyName = "terminalGroupsStopListsUpdates", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<TerminalGroupStopListUpdate>? TerminalGroupStopListUpdates { get; set; }

        /// <summary>
        /// Personal shift state flag (true - shift is opened, false - shift is closed).
        /// </summary>
        [JsonProperty(PropertyName = "opened", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? Opened { get; set; }

        /// <summary>
        /// ID of the terminal group where the personal shift is opened/closed.
        /// </summary>
        [JsonProperty(PropertyName = "terminalGroupId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? TerminalGroupId { get; set; }

        /// <summary>
        /// Contains information about delivery, table and reserve orders.
        /// </summary>
        [JsonProperty(PropertyName = "order", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Order? Order { get; set; }
    }
}
