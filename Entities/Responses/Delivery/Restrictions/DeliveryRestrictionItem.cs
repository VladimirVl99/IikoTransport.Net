using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.Delivery.Restrictions
{
    /// <summary>
    /// Delivery restriction.
    /// </summary>
    [JsonObject]
    public class DeliveryRestrictionItem
    {
        /// <summary>
        /// The minimum order amount for a given point in a given time interval in this delivery zone.
        /// </summary>
        [JsonProperty(PropertyName = "minSum", Required = Required.AllowNull)]
        public double? MinSum { get; set; }

        /// <summary>
        /// Terminal group ID.
        /// Can be obtained by https://api-ru.iiko.services/api/1/terminal_groups operation.
        /// </summary>
        [JsonProperty(PropertyName = "terminalGroupId", Required = Required.AllowNull)]
        public Guid? TerminalGroupId { get; set; }

        /// <summary>
        /// Organization ID.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.
        /// </summary>
        [JsonProperty(PropertyName = "organizationId", Required = Required.AllowNull)]
        public Guid? OrganizationId { get; set; }

        /// <summary>
        /// Name of delivery zone from cartography.
        /// </summary>
        [JsonProperty(PropertyName = "zone", Required = Required.AllowNull)]
        public string? Zone { get; set; }

        /// <summary>
        /// Days of the week.
        /// </summary>
        [JsonProperty(PropertyName = "weekMap", Required = Required.Always)]
        public int WeekMap { get; set; }

        /// <summary>
        /// The time from which the point can process orders from the selected zone,
        /// in minutes from the beginning of the day.
        /// </summary>
        [JsonProperty(PropertyName = "from", Required = Required.AllowNull)]
        public int? From { get; set; }

        /// <summary>
        /// The maximum time at which a point can carry an order to a given zone,
        /// in minutes from the beginning of the day.
        /// </summary>
        [JsonProperty(PropertyName = "to", Required = Required.AllowNull)]
        public int? To { get; set; }

        /// <summary>
        /// Priority of point in delivery zone.
        /// </summary>
        [JsonProperty(PropertyName = "priority", Required = Required.Always)]
        public int Priority { get; set; }

        /// <summary>
        /// Delivery duration in delivery zone.
        /// </summary>
        [JsonProperty(PropertyName = "deliveryDurationInMinutes", Required = Required.Always)]
        public long DeliveryDurationInMinutes { get; set; }

        /// <summary>
        /// Link to "delivery service payment".
        /// </summary>
        [JsonProperty(PropertyName = "deliveryServiceProductId", Required = Required.AllowNull)]
        public Guid? DeliveryServiceProductId { get; set; }
    }
}
