using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.UnsuccessResponse
{
    /// <summary>
    /// Unsuccess response schema.
    /// </summary>
    [JsonObject]
    public class UnsuccessResponse
    {
        /// <summary>
        /// Operation ID.
        /// </summary>
        [JsonProperty(PropertyName = "correlationId", Required = Required.Always)]
        public Guid CorrelationId { get; set; }

        /// <summary>
        /// Error text.
        /// </summary>
        [JsonProperty(PropertyName = "errorDescription", Required = Required.Always)]
        public string ErrorDescription { get; set; } = default!;

        /// <summary>
        /// Error code.
        /// </summary>
        [JsonProperty(PropertyName = "error", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Error { get; set; }
    }
}
