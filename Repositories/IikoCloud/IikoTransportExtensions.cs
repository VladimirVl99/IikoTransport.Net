using IikoTransport.Net.Entities.Responses.Webhooks;

namespace IikoTransport.Net.Repositories.IikoCloud
{
    public static class IikoTransportExtensions
    {
        public static void StartReceiving(
            this IIikoTransport iikoTransport,
            Func<IIikoTransport, Update, Task> updateHandler,
            Func<IIikoTransport, Exception, Task> errorHandler)
        {
            if (string.IsNullOrWhiteSpace(iikoTransport.WebHooksUri))
            {
                throw new Exception("Uri for WebHooks cannot be empty.");
            }

            var handler = new WebhookHandler(updateHandler, errorHandler, iikoTransport);
            handler.Start();
        }
    }
}
