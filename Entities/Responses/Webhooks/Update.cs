using IikoTransport.Net.Entities.Common.Date;
using IikoTransport.Net.Entities.Responses.General.Operations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IikoTransport.Net.Entities.Responses.Webhooks
{
    /// <summary>
    /// Webhook notification.
    /// Source: https://api-ru.iiko.services/#tag/Webhooks.
    /// </summary>
    [JsonObject]
    public class Update : OperationInfo
    {
        /// <summary>
        /// Event type.
        /// </summary>
        [JsonProperty(PropertyName = "eventType", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public EventType EventType { get; set; }

        /// <summary>
        /// Event date and time (UTC).
        /// </summary>
        [JsonProperty(PropertyName = "eventTime", Required = Required.Always)]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd HH:mm:ss.fff")]
        public DateTime EventTime { get; set; }

        /// <summary>
        /// Organization ID.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.
        /// </summary>
        [JsonProperty(PropertyName = "organizationId", Required = Required.Always)]
        public Guid OrganizationId { get; set; }

        /// <summary>
        /// Event details.
        /// </summary>
        [JsonProperty(PropertyName = "eventInfo", Required = Required.Always)]
        public EventInfo EventInfo { get; set; } = default!;
    }
}
