using Medium.Client.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Medium.Client.HttpClients
{
    public sealed class BaseHttpClient
    {
        private HttpClient _httpClient;

        public BaseHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> GetAsync<T>(string url)
        {
            var request = CreateHttpRequest(HttpMethod.Get, url);

            return await GetResponse<T>(request);
        }

        public async Task<T> GetAsync<T>(string url, string propertyName)
        {
            var request = CreateHttpRequest(HttpMethod.Get, url);

            return await GetResponse<T>(request, propertyName);
        }

        public async Task<T> PostAsync<T>(string url, object body)
        {
            var request = CreateHttpRequest(HttpMethod.Post, url);
            request.Content = new StringContent(SerializeBody(body), Encoding.UTF8, "application/json");

            return await GetResponse<T>(request);
        }

        private HttpRequestMessage CreateHttpRequest(HttpMethod httpMethod, string endpointPath)
        {
            var request = new HttpRequestMessage(httpMethod, endpointPath);
            return request;
        }

        private string SerializeBody(object body)
        {
            var settings = new JsonSerializerSettings();
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            return JsonConvert.SerializeObject(body, settings);
        }

        /// <summary>
        /// Gets the API response and converts into <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="httpRequest"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="MediumClientException"></exception>
        private async Task<T> GetResponse<T>(HttpRequestMessage httpRequest)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.SendAsync(httpRequest).ConfigureAwait(false);

                if (!response.IsSuccessStatusCode)
                    throw new ArgumentException($"The path {httpRequest.RequestUri} gets the following status code: " + response.StatusCode);

                var responseStr = await response.Content.ReadAsStringAsync();
                var responseObject = JsonConvert.DeserializeObject<T>(responseStr);

                return responseObject;
            }
            catch (Exception ex)
            {
                throw new MediumClientException("Medium client catched an exception.", ex);
            }
        }

        /// <summary>
        /// Gets a specific json property from API response.
        /// Converts into <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="httpRequest"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="MediumClientException"></exception>
        private async Task<T> GetResponse<T>(HttpRequestMessage httpRequest, string propertyName)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.SendAsync(httpRequest).ConfigureAwait(false);

                if (!response.IsSuccessStatusCode)
                    throw new ArgumentException($"The path {httpRequest.RequestUri} gets the following status code: " + response.StatusCode);

                var responseStr = await response.Content.ReadAsStringAsync();

                var jObject = JObject.Parse(responseStr);
                var jToken = jObject.GetValue(propertyName);

                T value = jToken.ToObject<T>();
                return value;
            }
            catch (Exception ex)
            {
                throw new MediumClientException("Medium client catched an exception.", ex);
            }
        }
    }
}
