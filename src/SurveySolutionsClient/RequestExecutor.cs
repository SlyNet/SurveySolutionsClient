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

        public Task PatchAsync(string baseUrl, string path, object jsonBody,
            Credentials credentials, CancellationToken cancellationToken)
        {
            return SendRequest(baseUrl, path, credentials, jsonBody, cancellationToken, "PATCH");
        }

        public async Task<T> PatchAsync<T>(string baseUrl, string path, object? jsonBody,
            Credentials credentials, CancellationToken cancellationToken)
        {
            var response = await SendRequest(baseUrl, path, credentials, jsonBody, cancellationToken, "PATCH").ConfigureAwait(false);
            return await DeserializeResponse<T>(cancellationToken, response).ConfigureAwait(false);
        }

        public Task<HttpResponseMessage> PostAsync(string baseUrl, string path, object jsonBody, Credentials credentials, CancellationToken cancellationToken)
        {
            return ReceiveResponse(baseUrl, path, credentials, jsonBody, cancellationToken, HttpMethod.Post.Method);
        }

        public async Task<T> PostAsync<T>(string baseUrl, string path, object jsonBody, Credentials credentials, CancellationToken cancellationToken)
        {
            var response = await SendRequest(baseUrl, path, credentials, jsonBody, cancellationToken, HttpMethod.Post.Method).ConfigureAwait(false);
            try
            {
                return await DeserializeResponse<T>(cancellationToken, response).ConfigureAwait(false);
            }
            catch (JsonException)
            {
                response.Seek(0, SeekOrigin.Begin);
                using var streamReader = new StreamReader(response);
                var stringContent = await streamReader.ReadToEndAsync().ConfigureAwait(false);
                throw;
            }
        }

        private async Task<Stream> SendRequest(string baseUrl, string path, Credentials credentials,
            object? jsonBody, 
            CancellationToken cancellationToken, 
            string httpMethod)
        {
            var serverResponse = await ReceiveResponse(baseUrl, path, credentials, jsonBody, cancellationToken, httpMethod);

            if (!serverResponse.IsSuccessStatusCode)
            {
                string responseBody = await serverResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                throw new ApiCallException($"Server responded with {serverResponse.StatusCode} status code", responseBody, serverResponse);
            }

            var responseObject = await serverResponse.Content.ReadAsStreamAsync().ConfigureAwait(false);
            return responseObject;
        }

        private async Task<HttpResponseMessage> ReceiveResponse(string baseUrl, string path, Credentials credentials, object? jsonBody,
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
            request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("text/json"));

            if (jsonBody != null)
            {
                request.Content = new StringContent(JsonSerializer.Serialize(jsonBody));
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }

            HttpResponseMessage serverResponse =
                await this.httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
            return serverResponse;
        }

        public async Task<T> DeleteAsync<T>(string baseUrl, string path, Credentials credentials, CancellationToken cancellationToken)
        {
            var response = await SendRequest(baseUrl, path, credentials, null, cancellationToken, HttpMethod.Delete.Method).ConfigureAwait(false);
            return await DeserializeResponse<T>(cancellationToken, response).ConfigureAwait(false);
        }
    }
}