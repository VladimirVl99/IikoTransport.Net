using IikoTransport.Net.Entities.Responses.General.Operations;
using IikoTransport.Net.Entities.Responses.Webhooks;
using IikoTransport.Net.Entities.Responses.Webhooks.Filters;

namespace IikoTransport.Net.Repositories.IikoTransport.Webhooks
{
    /// <summary>
    /// Webhook notifications. Webhook handlers can be registered by calling the POST
    /// https://api-ru.iiko.services/api/1/webhooks/update_settings method or in
    /// the 'iikoTransport API' iikoWeb application.
    /// </summary>
    public interface IWebhooks
    {
        #region Webhooks https://api-ru.iiko.services/#tag/Webhooks

        /// <summary>
        /// Get webhooks settings for specified organization and authorized API login.
        /// Source: https://api-ru.iiko.services/#tag/Webhooks/paths/~1api~11~1webhooks~1settings/post.
        /// </summary>
        /// <param name="organizationId">Organization UOC Id.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <returns></returns>
        Task<WebhookSettings> GetWebhooksSettingsForSpecifiedOrganizationAsync(Guid organizationId);

        /// <summary>
        /// Update webhooks settings for specified organization and authorized API login.
        /// Source: https://api-ru.iiko.services/#tag/Webhooks/paths/~1api~11~1webhooks~1update_settings/post.
        /// </summary>
        /// <param name="organizationId">Organization UOC Id.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="webHooksUri">Webhook handler url.</param>
        /// <param name="authToken">Authorization token to pass to the webhook handler.</param>
        /// <param name="webHooksFilter">Webhooks filter.</param>
        /// <returns></returns>
        Task<OperationInfo> UpdateWebhooksSettingsForSpecifiedOrganizationAsync(Guid organizationId,
            string webHooksUri, string? authToken = null, Filter? webHooksFilter = null);

        #endregion
    }
}
