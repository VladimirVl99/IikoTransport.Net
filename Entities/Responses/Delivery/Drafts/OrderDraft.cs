using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.Delivery.Drafts
{
    /// <summary>
    /// Information about an order draft.
    /// </summary>
    [JsonObject]
    public class OrderDraft
    {
        /// <summary>
        /// Order ID.
        /// </summary>
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public Guid Id { get; set; }

        /// <summary>
        /// Organization ID.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.
        /// </summary>
        [JsonProperty(PropertyName = "organizationId", Required = Required.Always)]
        public Guid OrganizationId { get; set; }

        /// <summary>
        /// ID of a user, who is editing this draft.
        /// </summary>
        [JsonProperty(PropertyName = "lockedByUser", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? LockedByUser { get; set; }

        /// <summary>
        /// Order.
        /// </summary>
        [JsonProperty(PropertyName = "order", Required = Required.Always)]
        public Order Order { get; set; } = default!;
    }
}
