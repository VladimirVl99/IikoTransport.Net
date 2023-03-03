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
        private readonly CancellationToken _cancellationToken;

        private readonly Func<IIikoTransport, Update, CancellationToken, Task> _updateHandler;
        private readonly Func<IIikoTransport, Exception, CancellationToken, Task> _errorHandler;


        public WebhookHandler(
            Func<IIikoTransport, Update, CancellationToken, Task> updateHandler,
            Func<IIikoTransport, Exception, CancellationToken, Task> errorHandler,
            IIikoTransport iikoTransport,
            CancellationToken cancellationToken = default)
        {
            _updateHandler = updateHandler ?? throw new ArgumentNullException(nameof(updateHandler));
            _errorHandler = errorHandler ?? throw new ArgumentNullException(nameof(errorHandler));
            _url = iikoTransport.WebHooksUri!;
            _iikoTransport = iikoTransport;
            _cancellationToken = cancellationToken;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Start()
        {
            var serverTread = new Thread(new ThreadStart(Run));
            serverTread.Start();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Run()
        {
            var listener = new HttpListener();
            listener.Prefixes.Add(_url);
            listener.Start();

            while (true)
            {
                try
                {
                    HttpListenerContext? httpContext = null;

                    Task.Run(async () =>
                    {
                        httpContext = await listener.GetContextAsync();
                    },
                    _cancellationToken).Wait();

                    if (httpContext is null)
                    {
                        throw new Exception($"{nameof(httpContext)} is null.");
                    }

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
                    {
                        await _updateHandler(_iikoTransport, update, _cancellationToken).ConfigureAwait(false);
                    },
                    _cancellationToken).Wait();

                    if (_cancellationToken.IsCancellationRequested)
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Task.Run(async () =>
                    {
                        await _errorHandler(_iikoTransport, ex, _cancellationToken).ConfigureAwait(false);
                    },
                    _cancellationToken).Wait();

                    if (_cancellationToken.IsCancellationRequested)
                    {
                        break;
                    }
                }
            }

            listener.Stop();
            listener.Close();
        }
    }
}
