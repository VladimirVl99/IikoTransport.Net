using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.General.Employees
{
    /// <summary>
    /// Information about a personal session.
    /// </summary>
    [JsonObject]
    public class PersonalSessionInfo : PersonalSessionActionResult
    {
        /// <summary>
        /// Is personal session opened.
        /// </summary>
        [JsonProperty(PropertyName = "error", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? IsSessionOpened { get; set; }
    }
}
