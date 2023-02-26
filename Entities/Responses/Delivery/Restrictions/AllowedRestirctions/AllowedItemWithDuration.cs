using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.Delivery.Restrictions.AllowedRestirctions
{
    /// <summary>
    /// Suitable terminal group with a delivery duration.
    /// </summary>
    [JsonObject]
    public class AllowedItemWithDuration
    {
        /// <summary>
        /// Terminal group ID.
        /// Can be obtained by https://api-ru.iiko.services/api/1/terminal_groups operation.
        /// </summary>
        [JsonProperty(PropertyName = "terminalGroupId", Required = Required.Always)]
        public Guid TerminalGroupId { get; set; }

        /// <summary>
        /// Organization ID.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.
        /// </summary>
        [JsonProperty(PropertyName = "organizationId", Required = Required.Always)]
        public Guid OrganizationId { get; set; }

        /// <summary>
        /// Delivery duration in minutes.
        /// </summary>
        [JsonProperty(PropertyName = "deliveryDurationInMinutes", Required = Required.Always)]
        public long DeliveryDurationInMinutes { get; set; }

        /// <summary>
        /// Delivery zone name which this TerminalGroupId belongs to.
        /// </summary>
        [JsonProperty(PropertyName = "zone", Required = Required.AllowNull)]
        public string? Zone { get; set; }

        /// <summary>
        /// Link to "delivery service payment".
        /// </summary>
        [JsonProperty(PropertyName = "deliveryServiceProductId", Required = Required.Always)]
        public Guid? DeliveryServiceProductId { get; set; }
    }
}
