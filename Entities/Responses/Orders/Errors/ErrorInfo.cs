using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IikoTransport.Net.Entities.Responses.Orders.Errors
{
    /// <summary>
    /// Order creation error details.
    /// </summary>
    [JsonObject]
    public class ErrorInfo
    {
        /// <summary>
        /// Error code.
        /// </summary>
        [JsonProperty(PropertyName = "code", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Code Code { get; set; }

        /// <summary>
        /// Nonlocalized message.
        /// </summary>
        [JsonProperty(PropertyName = "message", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Message { get; set; }

        /// <summary>
        /// Localized message.
        /// </summary>
        [JsonProperty(PropertyName = "description", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Description { get; set; }

        /// <summary>
        /// Additional information.
        /// </summary>
        [JsonProperty(PropertyName = "additionalData", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? AdditionalData { get; set; }
    }
}
