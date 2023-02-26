using IikoTransport.Net.Entities.Responses.General.Operations;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.General.Employees
{
    /// <summary>
    /// Information about actions on a personal session.
    /// </summary>
    [JsonObject]
    public class PersonalSessionActionResult : OperationInfo
    {
        /// <summary>
        /// Error details.
        /// </summary>
        [JsonProperty(PropertyName = "error", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Error { get; set; }
    }
}
