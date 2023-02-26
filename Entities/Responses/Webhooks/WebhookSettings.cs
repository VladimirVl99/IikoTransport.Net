using IikoTransport.Net.Entities.Responses.General.Operations;
using IikoTransport.Net.Entities.Responses.Webhooks.Filters;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.Webhooks
{
    /// <summary>
    /// Webhooks settings for specified organization and authorized API login.
    /// Source: https://api-ru.iiko.services/#tag/Webhooks/paths/~1api~11~1webhooks~1settings/post.
    /// </summary>
    [JsonObject]
    public class WebhookSettings : OperationInfo
    {
        /// <summary>
        /// Api login name.
        /// </summary>
        [JsonProperty(PropertyName = "apiLoginName", Required = Required.AllowNull)]
        public string? ApiLoginName { get; set; }

        /// <summary>
        /// Webhook handler url.
        /// </summary>
        [JsonProperty(PropertyName = "webHooksUri", Required = Required.AllowNull)]
        public string? WebHooksUri { get; set; }

        /// <summary>
        /// Authorization token to pass to the webhook handler.
        /// </summary>
        [JsonProperty(PropertyName = "authToken", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? AuthToken { get; set; }

        /// <summary>
        /// Webhooks filter.
        /// </summary>
        [JsonProperty(PropertyName = "webHooksFilter", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Filter? WebHooksFilter { get; set; }
    }
}
