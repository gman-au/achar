using System;
using System.Net.Http;
using System.Threading.Tasks;
using Achar.Domain.Testing.Exception;
using Newtonsoft.Json.Linq;

namespace Achar.Infrastructure.Api.HttpClient
{
    public partial class ApiHttpClientInteractionEngine
    {
        private HttpResponseMessage _lastResponse;

        public Task AssertResponseSucceededAsync()
        {
            try
            {
                if (_lastResponse == null)
                    throw new HttpRequestException($"No response was received from endpoint {_apiConfigurationOptions.BaseUrl}");

                _lastResponse
                    .EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new ApiRequestFailedException(_lastRequest, ex);
            }

            return
                Task
                    .CompletedTask;
        }

        public Task AssertResponseFailedAsync(int? expectedStatusCode = null)
        {
            if (_lastResponse == null)
                throw new HttpRequestException($"No response was received from endpoint {_apiConfigurationOptions.BaseUrl}");

            var actualStatusCode = (int)_lastResponse.StatusCode;

            if (expectedStatusCode.HasValue)
            {
                if (expectedStatusCode.Value != actualStatusCode)
                    throw new ApiResponseStatusCodeUnexpectedException(expectedStatusCode.Value, actualStatusCode, _lastRequest);
            }
            else
            {
                // throw if success
                try
                {
                    _lastResponse
                        .EnsureSuccessStatusCode();

                    throw new ApiResponseStatusCodeUnexpectedException(null, actualStatusCode, _lastRequest);
                }
                catch (HttpRequestException)
                {
                }
            }

            return
                Task
                    .CompletedTask;
        }

        public async Task AssertJsonTokenPathValueEqualsAsync(
            string jsonTokenPath,
            string expectedValue)
        {
            var jsonBody =
                await
                    _lastResponse?
                        .Content?
                        .ReadAsStringAsync();

            var jObject =
                JObject
                    .Parse(jsonBody);

            var expectedObject =
                jObject
                    .SelectToken(jsonTokenPath);

            var actualValue =
                expectedObject?
                    .Value<string>();

            if (!string.Equals(actualValue, expectedValue, StringComparison.InvariantCultureIgnoreCase))
                throw new ApiResponseValueUnexpectedException(jsonTokenPath, expectedValue, actualValue, _lastRequest);
        }
    }
}