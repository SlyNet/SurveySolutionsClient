using System;
using System.IO;
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
            var responseObject = await SendRequest(baseUrl, path, credentials, null, cancellationToken, HttpMethod.Get.Method);

            return await DeserializeResponse<T>(cancellationToken, responseObject);
        }

        private static async Task<T> DeserializeResponse<T>(CancellationToken cancellationToken, Stream responseObject)
        {
            var result = await JsonSerializer.DeserializeAsync<T>(responseObject, cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return result ?? throw new Exception("Failed to deserialize");
        }

        public async Task PatchAsync(string baseUrl, string path, object jsonBody,
            Credentials credentials, CancellationToken cancellationToken)
        {
            await SendRequest(baseUrl, path, credentials, jsonBody, cancellationToken, "PATCH");
        }

        public async Task<T> PatchAsync<T>(string baseUrl, string path, object? jsonBody,
            Credentials credentials, CancellationToken cancellationToken)
        {
            var response = await SendRequest(baseUrl, path, credentials, jsonBody, cancellationToken, "PATCH");
            return await DeserializeResponse<T>(cancellationToken, response);
        }

        private async Task<Stream> SendRequest(string baseUrl, string path, Credentials credentials,
            object? jsonBody,
            CancellationToken cancellationToken, string httpMethod)
        {
            var fullUrl = new Uri(new Uri(baseUrl), path);

            var request = new HttpRequestMessage
            {
                RequestUri = fullUrl,
                Method = new HttpMethod(httpMethod)
            };

            string base64String =
                Convert.ToBase64String(Encoding.UTF8.GetBytes($"{credentials.UserName}:{credentials.Password}"));
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", base64String);
            request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));

            if (jsonBody != null)
            {
                request.Content = new StringContent(JsonSerializer.Serialize(jsonBody));
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }

            HttpResponseMessage serverResponse = await this.httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);

            if (!serverResponse.IsSuccessStatusCode)
            {
                throw new ApiCallException($"Server responded with {serverResponse.StatusCode} status code", serverResponse);
            }

            var responseObject = await serverResponse.Content.ReadAsStreamAsync().ConfigureAwait(false);
            return responseObject;
        }
    }
}