using IikoTransport.Net.Entities.Common.Addresses;
using IikoTransport.Net.Entities.Responses.General.Operations;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.Delivery.DeliveryRestrictions.AllowedRestirctions
{
    /// <summary>
    /// Suitable terminal groups for delivery restrictions.
    /// Source: https://api-ru.iiko.services/#tag/Delivery-restrictions/paths/~1api~11~1delivery_restrictions~1allowed/post.
    /// </summary>
    [JsonObject]
    public class SuitableTerminalGroupsWithOperation : OperationInfo
    {
        /// <summary>
        /// A sign of successful verification.
        /// </summary>
        [JsonProperty(PropertyName = "isAllowed", Required = Required.Always)]
        public bool IsAllowed { get; set; }

        /// <summary>
        /// Delivery address ID in external mapping system.
        /// </summary>
        [JsonProperty(PropertyName = "addressExternalId", Required = Required.AllowNull)]
        public string? AddressExternalId { get; set; }

        /// <summary>
        /// Coordinates returned by geocoding service.
        /// </summary>
        [JsonProperty(PropertyName = "location", Required = Required.AllowNull)]
        public Coordinate? Location { get; set; }

        /// <summary>
        /// Suitable terminal groups with a delivery duration for them.
        /// </summary>
        [JsonProperty(PropertyName = "allowedItems", Required = Required.Always)]
        public IEnumerable<AllowedItemWithDuration> AllowedItems { get; set; } = default!;

        /// <summary>
        /// Rejected items with cause.
        /// </summary>
        [JsonProperty(PropertyName = "rejectedItems", Required = Required.Always)]
        public IEnumerable<RejectItem> RejectItems { get; set; } = default!;
    }
}
