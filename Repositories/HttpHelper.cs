using System.Net.Http.Headers;
using System.Net;
using System.Text;

namespace IikoTransport.Net.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class HttpHelper
    {
        /// <summary>
        /// Send http post bearer request to the Api server.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="token"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        protected static async Task<string> SendHttpPostBearerRequestAsync(string url, string body, string? token = null)
        {
            using var client = new HttpClient();

            if (token != null)
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var data = new StringContent(body, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, data);
            string responseBody = await response.Content.ReadAsStringAsync();

            if (!response.StatusCode.Equals(HttpStatusCode.OK))
                throw new HttpRequestException(responseBody, null, response.StatusCode);

            return responseBody;
        }

        /// <summary>
        /// Send http get bearer request to the Api server.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        protected static async Task<string> SendHttpGetBearerRequestAsync(string url, string token)
        {
            using var client = new HttpClient();

            if (token != null)
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            if (!response.StatusCode.Equals(HttpStatusCode.OK))
                throw new HttpRequestException(responseBody, null, response.StatusCode);

            return responseBody;
        }

        /// <summary>
        /// Send http post request to the Api server.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        protected static async Task<string> SendHttpPostRequestAsync(string url, string body)
        {
            using var client = new HttpClient();

            var data = new StringContent(body, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, data);
            string responseBody = await response.Content.ReadAsStringAsync();

            if (!response.StatusCode.Equals(HttpStatusCode.OK))
                throw new HttpRequestException(responseBody, null, response.StatusCode);

            return responseBody;
        }

        /// <summary>
        /// Send http get request to the Api server.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        protected static async Task<string> SendHttpGetRequestAsync(string url)
        {
            using var client = new HttpClient();

            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            if (!response.StatusCode.Equals(HttpStatusCode.OK))
                throw new HttpRequestException(responseBody, null, response.StatusCode);

            return responseBody;
        }
    }
}
