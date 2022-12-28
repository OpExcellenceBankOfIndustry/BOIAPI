using BOI.BOIApplications.Application.Contracts.Infrastructure;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Infrastructure.Helper
{
    public class HttpClientHelper : IHttpClientHelper
    {

        private readonly IHttpClientFactory _clientFactory;
        private readonly ILogger<HttpClientHelper> _logger;

        public HttpClientHelper(IHttpClientFactory httpClientFactory, ILogger<HttpClientHelper> logger)
        {
            _clientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<T> GetAsync<T>(string endpoint, IDictionary<string, string> values)
        {
            T model = default;
            try
            {
                var request = new HttpRequestMessage();
                var client = _clientFactory.CreateClient();
                var strParams = string.Empty;

                if (values != null)
                {
                    strParams = string.Join("&", values.Select(p => $"{p.Key}={p.Value}"));
                    endpoint = string.Concat(endpoint, "?", strParams);
                }

                request.RequestUri = new Uri(endpoint);
                request.Method = HttpMethod.Get;


                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var responseStr = await response.Content.ReadAsStringAsync();

                    model = JsonConvert.DeserializeObject<T>(responseStr);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + " " + ex.StackTrace);
            }
            return model;
        }

        public async Task<T> GetAsync<T, U>(string endpoint, U value)
        {

            T model = default;
            try
            {
                var client = _clientFactory.CreateClient();

                using (var request = new HttpRequestMessage(HttpMethod.Get, endpoint))
                {

                    var jsonValue = new StringContent(
                        JsonConvert.SerializeObject(value, new JsonSerializerSettings
                        {
                            ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() },
                            Formatting = Formatting.Indented
                        }),
                        Encoding.UTF8,
                        "application/json"); ;


                    request.Content = jsonValue;

                    var response = await client.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseStr = response.Content.ReadAsStringAsync().Result;
                        model = JsonConvert.DeserializeObject<T>(responseStr);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + " " + ex.StackTrace);
            }

            return model;
        }

        public async Task<List<T>> GetAllAsync<T>(string endpoint)
        {
            List<T> model = default;
            try
            {
                var client = _clientFactory.CreateClient();

                using (var request = new HttpRequestMessage(HttpMethod.Get, endpoint))
                {

                    var response = await client.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseStr = await response.Content.ReadAsStringAsync();
                        model = JsonConvert.DeserializeObject<List<T>>(responseStr);
                    }

                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + " " + ex.StackTrace);
            }
            return model;
        }

        public async Task<T> PostAsync<T, U>(string endpoint, U value)
        {

            T model = default;
            try
            {
                var client = _clientFactory.CreateClient();

                using (var request = new HttpRequestMessage(HttpMethod.Post, endpoint))
                {

                    var jsonValue = new StringContent(
                        JsonConvert.SerializeObject(value, new JsonSerializerSettings
                        {
                            ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() },
                            Formatting = Formatting.Indented
                        }),
                        Encoding.UTF8,
                        "application/json"); ;


                    request.Content = jsonValue;

                    var response = await client.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseStr = response.Content.ReadAsStringAsync().Result;
                        model = JsonConvert.DeserializeObject<T>(responseStr);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + " " + ex.StackTrace);
            }

            return model;
        }

        public async Task<T> PostFormAsync<T>(string endpoint, IDictionary<string, string> values)
        {
            T model = default;

            try
            {
                var client = _clientFactory.CreateClient();
                var response = await client.PostAsync(endpoint, new FormUrlEncodedContent(values));

                if (response.IsSuccessStatusCode)
                {
                    var responseStr = response.Content.ReadAsStringAsync().Result;
                    model = JsonConvert.DeserializeObject<T>(responseStr);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + " " + ex.StackTrace);
            }

            return model;
        }
    }
}
