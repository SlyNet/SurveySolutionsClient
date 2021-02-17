using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using SurveySolutionsClient.Exceptions;

namespace SurveySolutionsClient
{
    internal class RequestExecutor
    {
        private readonly HttpClient httpClient;

        public RequestExecutor(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<T> GetAsync<T>(string baseUrl, string path, Credentials credentials,
            CancellationToken cancellationToken)
        {
            if (credentials == null)
            {
                throw new ArgumentNullException(nameof(credentials));
            }

            var fullUrl = new Uri(new Uri(baseUrl), path);

            var request = new HttpRequestMessage
            {
                RequestUri = fullUrl,
                Method = HttpMethod.Get
            };
            
            string base64String = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{credentials.UserName}:{credentials.Password}"));
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", base64String);
            request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
            
            HttpResponseMessage serverResponse = await httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);

            if (!serverResponse.IsSuccessStatusCode)
            {
                throw new ApiCallException($"Server responded with {serverResponse.StatusCode} status code", serverResponse);
            }

            var responseObject = await serverResponse.Content.ReadAsStreamAsync().ConfigureAwait(false);

            var result = await JsonSerializer.DeserializeAsync<T>(responseObject, cancellationToken: cancellationToken).ConfigureAwait(false);
            return result ?? throw new Exception("Failed to deserialize");
        }
    }
}