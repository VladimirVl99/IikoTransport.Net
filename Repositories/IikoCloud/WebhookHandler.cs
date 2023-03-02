using IikoTransport.Net.Entities.Responses.Webhooks;
using Newtonsoft.Json;
using System.Net;

namespace IikoTransport.Net.Repositories.IikoCloud
{
    public class WebhookHandler
    {
        private const string DefaultNullableExceptionMessage = "Fail to convert json response to the object.";


        private readonly string _url;
        private readonly IIikoTransport _iikoTransport;

        private readonly Func<IIikoTransport, Update, Task> _updateHandler;
        private readonly Func<IIikoTransport, Exception, Task> _errorHandler;


        public WebhookHandler(
            Func<IIikoTransport, Update, Task> updateHandler,
            Func<IIikoTransport, Exception, Task> errorHandler,
            IIikoTransport iikoTransport)
        {
            _updateHandler = updateHandler ?? throw new ArgumentNullException(nameof(updateHandler));
            _errorHandler = errorHandler ?? throw new ArgumentNullException(nameof(errorHandler));
            _url = iikoTransport.WebHooksUri!;
            _iikoTransport = iikoTransport;
        }

        public void Start()
        {
            var serverTread = new Thread(new ThreadStart(Run));
            serverTread.Start();
        }

        public void Run()
        {
            var listener = new HttpListener();
            listener.Prefixes.Add(_url);
            listener.Start();

            while (true)
            {
                try
                {
                    var httpContextTask = listener.GetContextAsync();
                    httpContextTask.Wait();
                    var httpContext = httpContextTask.Result;

                    var request = httpContext.Request;
                    string text;
                    using (var reader = new StreamReader(request.InputStream,
                                                         request.ContentEncoding))
                    {
                        text = reader.ReadToEnd();
                    }

                    var update = JsonConvert.DeserializeObject<Update>(text)
                        ?? throw new Exception(DefaultNullableExceptionMessage);

                    httpContext.Response.StatusCode = 200;
                    httpContext.Response.Close();

                    Task.Run(async () =>
                        await _updateHandler(_iikoTransport, update).ConfigureAwait(false)
                    );
                }
                catch (Exception ex)
                {
                    Task.Run(async () =>
                        await _errorHandler(_iikoTransport, ex).ConfigureAwait(false)
                    );
                }
            }

            listener.Stop();
            listener.Close();
        }
    }
}
