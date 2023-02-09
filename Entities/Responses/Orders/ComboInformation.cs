using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.Orders
{
    /// <summary>
    /// Combo details.
    /// </summary>
    [JsonObject]
    public class ComboInformation
    {
        /// <summary>
        /// New combo ID.
        /// </summary>
        [JsonProperty(PropertyName = "comboId", Required = Required.Always)]
        public Guid ComboId { get; set; }

        /// <summary>
        /// Action ID that defines combo.
        /// </summary>
        [JsonProperty(PropertyName = "comboSourceId", Required = Required.Always)]
        public Guid ComboSourceId { get; set; }

        /// <summary>
        /// Combo group ID to which item belongs.
        /// </summary>
        [JsonProperty(PropertyName = "groupId", Required = Required.Always)]
        public Guid GroupId { get; set; }
    }
}
