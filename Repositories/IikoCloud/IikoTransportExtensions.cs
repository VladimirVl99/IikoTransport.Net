using IikoTransport.Net.Entities.Responses.Webhooks;

namespace IikoTransport.Net.Repositories.IikoCloud
{
    public static class IikoTransportExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iikoTransport"></param>
        /// <param name="updateHandler"></param>
        /// <param name="errorHandler"></param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="Exception"></exception>
        public static void StartReceiving(
            this IIikoTransport iikoTransport,
            Func<IIikoTransport, Update, CancellationToken, Task> updateHandler,
            Func<IIikoTransport, Exception, CancellationToken, Task> errorHandler,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(iikoTransport.WebHooksUri))
            {
                throw new Exception("Uri for WebHooks cannot be empty.");
            }

            var handler = new WebhookHandler(updateHandler, errorHandler, iikoTransport,
                cancellationToken);

            handler.Start();
        }
    }
}
