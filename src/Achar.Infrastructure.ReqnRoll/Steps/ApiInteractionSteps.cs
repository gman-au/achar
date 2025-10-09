using System.Threading.Tasks;
using Achar.Infrastructure.Api.Extensions;
using Achar.Infrastructure.Api.HttpClient.Options;
using Achar.Infrastructure.Testing.Extensions;
using Achar.Interfaces.Testing;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using Reqnroll;

namespace Achar.Infrastructure.ReqnRoll.Steps
{
    [Binding]
    public class ApiInteractionSteps(
        IApiInteractionEngine engine,
        IOptions<ApiConfigurationOptions> options
    )
    {
        /// <summary>
        /// Builds a new API request against the API endpoint.
        /// Ensure that in your appsettings / configuration that an ApiConfigurationOptions
        /// section is defined with a BaseUrl value.
        /// </summary>
        /// <param name="endpoint">The endpoint for this API request. The full URI will be (BaseUrl) + (endpoint).</param>
        [Given(@"an API request is created against endpoint ""(.*)""")]
        public async Task GivenAnApiRequestIsCreatedAgainstEndpoint(string endpoint)
        {
            await
                engine
                    .ActGetContext()
                    .ActCreateRequestAsync(endpoint);
        }

        /// <summary>
        /// Sets the HTTP header for the current API request to a set value.
        /// </summary>
        /// <param name="headerKey">The header key, e.g. "content-type".</param>
        /// <param name="headerValue">The header value, e.g. "application/json".</param>
        [Given(@"the request header element ""(.*)"" has value ""(.*)""")]
        public async Task GivenTheRequestHeaderElementHasValue(
            string headerKey,
            string headerValue)
        {
            await
                engine
                    .ActGetContext()
                    .ActSetRequestHeaderValueAsync(headerKey, headerValue);
        }

        /// <summary>
        /// Sets the HTTP header for the current API request to a configuration value.
        /// </summary>
        /// <param name="headerKey">The header key, e.g. "content-type".</param>
        /// <param name="configurationReference">The configuration path (e.g. in appsettings.json) to retrieve the value e.g. "ApiSettings.DefaultContentType".</param>
        [Given(@"the request header element ""(.*)"" has configuration value ""(.*)""")]
        public async Task GivenTheRequestHeaderElementHasConfigurationValue(
            string headerKey,
            string configurationReference)
        {
            var configValue =
                await
                    options
                        .Value
                        .ActLoadValueFromConfigAsync(configurationReference);
            await
                engine
                    .ActGetContext()
                    .ActSetRequestHeaderValueAsync(
                        headerKey,
                        configValue);
        }

        /// <summary>
        /// Sets a value of the request body (JSON only) to a set value.
        /// If the token path is a nested value e.g. Parent.Child.Something, then the token tree will be created all the way down.
        /// </summary>
        /// <param name="jsonTokenPath">The JSON token path e.g. "person.age".</param>
        /// <param name="value">The value to set the body property e.g. "18".</param>
        [Given(@"the request body element ""(.*)"" has value ""(.*)""")]
        public async Task GivenTheRequestBodyElementHasValue(
            string jsonTokenPath,
            string value)
        {
            await
                engine
                    .ActGetContext()
                    .ActSetRequestBodyValueAsync(jsonTokenPath, value);
        }

        /// <summary>
        /// Sets a value of the request body (JSON only) to a configuration value.
        /// If the token path is a nested value e.g. Parent.Child.Something, then the token tree will be created all the way down.
        /// </summary>
        /// <param name="jsonTokenPath">The JSON token path e.g. "person.age".</param>
        /// <param name="configurationReference">The configuration path (e.g. in appsettings.json) to retrieve the value e.g. "ApiSettings.DefaultPerson.Age".</param>
        [Given(@"the request body element ""(.*)"" has configuration value ""(.*)""")]
        public async Task GivenTheRequestBodyElementHasConfigurationValue(
            string jsonTokenPath,
            string configurationReference)
        {
            var configValue =
                await
                    options
                        .Value
                        .ActLoadValueFromConfigAsync(configurationReference);
            await
                engine
                    .ActGetContext()
                    .ActSetRequestBodyValueAsync(
                        jsonTokenPath,
                        configValue);
        }

        /// <summary>
        /// Sends the API request to the configured endpoint via the specified method.
        /// </summary>
        /// <param name="method">The HTTP method (i.e. "GET", "POST", "PUT", etc.).</param>
        [When(@"the request is sent via ""(.*)""")]
        public async Task WhenTheRequestIsSentVia(string method)
        {
            await
                engine
                    .ActGetContext()
                    .ActSendRequestAsync(method);
        }

        /// <summary>
        /// Checks that the API response is not a HTTP error status.
        /// </summary>
        [Then(@"the request should have succeeded")]
        public async Task ThenTheRequestShouldHaveSucceeded()
        {
            await
                engine
                    .ActGetContext()
                    .AssertResponseSucceededAsync();
        }

        /// <summary>
        /// Checks that the API response IS a HTTP error status.
        /// </summary>
        [Then(@"the request should have failed")]
        public async Task ThenTheRequestShouldHaveFailed()
        {
            await
                engine
                    .ActGetContext()
                    .AssertResponseFailedAsync();
        }

        /// <summary>
        /// Checks that the API response IS a HTTP error status, with a specific status code.
        /// </summary>
        /// <param name="expectedStatusCode">The expected HTTP status code e.g. 404.</param>
        [Then(@"the request should have failed with status code (.*)")]
        public async Task ThenTheRequestShouldHaveFailedWithStatusCode(int expectedStatusCode)
        {
            await
                engine
                    .ActGetContext()
                    .AssertResponseFailedAsync(expectedStatusCode);
        }

        /// <summary>
        /// Checks that a particular (JSON) token path has an expected value as defined.
        /// </summary>
        /// <param name="path">The JSON token path e.g. "person.age"</param>
        /// <param name="expectedValue">The expected value e.g. "18".</param>
        [Then(@"the response with path ""(.*)"" should have a value of ""(.*)""")]
        public async Task ThenTheResponseWithPathShouldHaveAValueOf(
            string path,
            string expectedValue)
        {
            await
                engine
                    .ActGetContext()
                    .AssertJsonTokenPathValueEqualsAsync(path, expectedValue);
        }

        /// <summary>
        /// Skips the test.
        /// </summary>
        [Given(@"test is skipped")]
        [When(@"test is skipped")]
        [Then(@"test is skipped")]
        public async Task GivenTestIsSkipped()
        {
            Assert
                .Ignore("Test has been skipped");
        }
    }
}