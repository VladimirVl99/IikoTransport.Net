using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.General.Menu.Combo
{
    /// <summary>
    /// Contains warning about errors, not blocking loyalty calculation.
    /// </summary>
    [JsonObject]
    public class Warning
    {
        /// <summary>
        /// Code of an error. Can be null.
        /// </summary>
        [JsonProperty(PropertyName = "Code", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Code { get; set; }

        /// <summary>
        /// Description of an error. Can be null.
        /// </summary>
        [JsonProperty(PropertyName = "Message", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Message { get; set; }
    }
}
