using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.General.Terminals.AwakeTerminalGroups
{
    /// <summary>
    /// Result of awake terminal groups from sleep mode.
    /// </summary>
    [JsonObject]
    public class AwakeTerminalGroupsResult
    {
        /// <summary>
        /// Identifiers of successfully processed terminal groups.
        /// </summary>
        [JsonProperty(PropertyName = "successfullyProcessed", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<Guid>? SuccessfullyProcessed { get; set; }

        /// <summary>
        /// Identifiers of terminal groups whose processing failed.
        /// </summary>
        [JsonProperty(PropertyName = "failedProcessed", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<Guid>? FailedProcessed { get; set; }
    }
}
