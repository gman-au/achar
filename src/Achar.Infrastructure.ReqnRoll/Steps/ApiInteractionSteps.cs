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
        [Given(@"an API request is created against endpoint ""(.*)""")]
        public async Task GivenAnApiRequestIsCreatedAgainstEndpoint(string endpoint)
        {
            await
                engine
                    .ActGetContext()
                    .ActCreateRequestAsync(endpoint);
        }

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

        [When(@"the request is sent via ""(.*)""")]
        public async Task WhenTheRequestIsSentVia(string method)
        {
            await
                engine
                    .ActGetContext()
                    .ActSendRequestAsync(method);
        }

        [Then(@"the request should have succeeded")]
        public async Task ThenTheRequestShouldHaveSucceeded()
        {
            await
                engine
                    .ActGetContext()
                    .AssertResponseSucceededAsync();
        }

        [Then(@"the request should have failed")]
        public async Task ThenTheRequestShouldHaveFailed()
        {
            await
                engine
                    .ActGetContext()
                    .AssertResponseFailedAsync();
        }

        [Then(@"the request should have failed with status code (.*)")]
        public async Task ThenTheRequestShouldHaveFailedWithStatusCode(int expectedStatusCode)
        {
            await
                engine
                    .ActGetContext()
                    .AssertResponseFailedAsync(expectedStatusCode);
        }

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