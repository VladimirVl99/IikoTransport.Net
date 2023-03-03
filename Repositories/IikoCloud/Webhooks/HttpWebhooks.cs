using IikoTransport.Net.Entities.Responses.General.Operations;
using IikoTransport.Net.Entities.Responses.Webhooks;
using IikoTransport.Net.Entities.Responses.Webhooks.Filters;
using Newtonsoft.Json;

namespace IikoTransport.Net.Repositories.IikoCloud.Webhooks
{
    public class HttpWebhooks : HttpHelper, IWebhooks
    {
        #region Fields

        private const string DefaultGetWebhooksSettingsForSpecifiedOrganizationUri
            = "https://api-ru.iiko.services/api/1/webhooks/settings";
        private const string DefaultUpdateWebhooksSettingsForSpecifiedOrganizationUri
            = "https://api-ru.iiko.services/api/1/webhooks/update_settings";

        private const string DefaultNullableExceptionMessage = "Fail to convert json response to the object.";

        #endregion

        #region Properties

        public string Token { get; set; }

        #endregion

        #region Constructors

        public HttpWebhooks(string token) => Token = token;

        #endregion

        #region Methods

        #region Webhooks https://api-ru.iiko.services/#tag/Webhooks

        public async Task<WebhookSettings> GetWebhooksSettingsForSpecifiedOrganizationAsync(Guid organizationId,
            CancellationToken? cancellationToken = default)
        {
            string body = JsonConvert.SerializeObject(new
            {
                organizationId
            });

            var responseBody = await SendHttpPostBearerRequestAsync(DefaultGetWebhooksSettingsForSpecifiedOrganizationUri,
                body, Token, cancellationToken);

            return JsonConvert.DeserializeObject<WebhookSettings>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        public async Task<OperationInfo> UpdateWebhooksSettingsForSpecifiedOrganizationAsync(Guid organizationId,
            string webHooksUri, string? authToken = null, Filter? webHooksFilter = null,
            CancellationToken? cancellationToken = default)
        {
            string body = JsonConvert.SerializeObject(new
            {
                organizationId,
                webHooksUri,
                authToken,
                webHooksFilter
            });

            var responseBody = await SendHttpPostBearerRequestAsync(DefaultUpdateWebhooksSettingsForSpecifiedOrganizationUri,
                body, Token, cancellationToken);

            return JsonConvert.DeserializeObject<OperationInfo>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        #endregion

        #endregion
    }
}
