using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IikoTransport.Net.Entities.Responses.Delivery.DeliveryRestrictions.AllowedRestirctions
{
    /// <summary>
    /// Information about a reject item with cause.
    /// </summary>
    [JsonObject]
    public class RejectItem
    {
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
        /// Delivery zone name which this TerminalGroupId belongs to.
        /// </summary>
        [JsonProperty(PropertyName = "zone", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Zone { get; set; }

        /// <summary>
        /// Reject cause code.
        /// </summary>
        [JsonProperty(PropertyName = "rejectCode", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public RejectCode RejectCode { get; set; }

        /// <summary>
        /// Reject hint.
        /// </summary>
        [JsonProperty(PropertyName = "rejectHint", Required = Required.Always)]
        public string RejectHint { get; set; } = default!;

        /// <summary>
        /// Reject additional information.
        /// </summary>
        [JsonProperty(PropertyName = "rejectItemData", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public RejectItemData? RejectItemData { get; set; }
    }
}
