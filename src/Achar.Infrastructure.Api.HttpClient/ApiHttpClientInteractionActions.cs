using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Achar.Domain.Testing;
using Achar.Domain.Testing.Exception;
using Achar.Infrastructure.Api.HttpClient.Extensions;
using Achar.Infrastructure.Api.HttpClient.Options;
using Achar.Infrastructure.Testing.Extensions;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;

namespace Achar.Infrastructure.Api.HttpClient
{
    public partial class ApiHttpClientInteractionEngine(
        IOptions<ApiConfigurationOptions> apiConfigurationOptionsAccessor
    )
    {
        private readonly ApiConfigurationOptions _apiConfigurationOptions = apiConfigurationOptionsAccessor.Value;

        private readonly IList<Tuple<string, string>> _requestHeaders = new List<Tuple<string, string>>();
        private JObject _requestBody = new();

        public async Task WaitSecondsAsync(int seconds)
        {
            await Task.Delay(1000 * seconds);
        }

        public Task CreateRequestAsync(string endpoint)
        {
            _requestBody = new JObject();
            _requestHeaders.Clear();

            _lastRequest = new ApiRequest
            {
                Endpoint = endpoint,
                Data = () => _requestBody.ToString()
            };

            return
                Task
                    .CompletedTask;
        }

        public Task SetRequestHeaderValueAsync(
            string headerKey,
            string headerValue)
        {
            _requestHeaders
                .Add(new Tuple<string, string>(headerKey, headerValue));

            return
                Task
                    .CompletedTask;
        }

        public Task SetRequestBodyValueAsync(
            string jsonTokenPath,
            string value)
        {
            _requestBody
                .SetJObject(jsonTokenPath, value);

            return
                Task
                    .CompletedTask;
        }

        public async Task SendRequestAsync(string method)
        {
            using var httpClient = new System.Net.Http.HttpClient();

            try
            {
                httpClient.BaseAddress = new Uri(_apiConfigurationOptions.BaseUrl);

                _lastRequest.Method = method;

                var httpRequestMessage =
                    new HttpRequestMessage(
                        method.ToHttpMethod(),
                        _lastRequest.Endpoint
                    );

                var jsonBody = _requestBody.ToString();

                if (_requestBody.HasValues)
                    httpRequestMessage.Content =
                        new StringContent(
                            jsonBody,
                            Encoding.UTF8,
                            "application/json"
                        );

                if (_requestHeaders.Any())
                {
                    httpRequestMessage
                        .Headers
                        .Clear();

                    foreach (var header in _requestHeaders)
                        httpRequestMessage
                            .Headers
                            .Add(header.Item1, header.Item2);
                }

                _lastResponse =
                    await
                        httpClient
                            .SendAsync(httpRequestMessage);
            }
            catch (HttpRequestException ex)
            {
                throw new ApiRequestFailedException(_lastRequest, ex);
            }
        }
    }
}