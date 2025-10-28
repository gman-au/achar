using System;
using System.Threading.Tasks;
using Achar.Domain.Testing.Exception;
using Achar.Interfaces.Testing;
using Microsoft.Playwright;

namespace Achar.Infrastructure.Playwright
{
    public partial class PlaywrightEngine : IScreenInteractionEngine
    {
        public async Task AssertNotClickableAsync()
        {
            try
            {
                await
                    Assertions
                        .Expect(_locator)
                        .Not
                        .ToBeEnabledAsync();
            }
            catch (Exception ex)
            {
                throw new ElementNotClickableException(
                    _lastInstruction,
                    ex
                );
            }
        }

        public async Task AssertVisibleAsync()
        {
            try
            {
                await
                    Assertions
                        .Expect(_locator)
                        .ToBeVisibleAsync();
            }
            catch (Exception ex)
            {
                throw new ElementNotVisibleException(
                    _lastInstruction,
                    ex
                );
            }
        }
        public async Task AssertNotVisibleAsync()
        {
            try
            {
                await
                    Assertions
                        .Expect(_locator)
                        .Not
                        .ToBeVisibleAsync();
            }
            catch (Exception ex)
            {
                throw new ElementVisibleException(
                    _lastInstruction,
                    ex
                );
            }
        }

        public async Task AssertClickableAsync()
        {
            try
            {
                await
                    Assertions
                        .Expect(_locator)
                        .ToBeEnabledAsync();
            }
            catch (Exception ex)
            {
                throw new ElementNotClickableException(
                    _lastInstruction,
                    ex
                );
            }
        }

        public async Task AssertEqualAsync(string expected)
        {
            var value =
                await
                    _locator
                        .InnerTextAsync();

            if (value != expected)
                throw new ElementValueUnexpectedException(
                    expected,
                    value,
                    _lastInstruction
                );
        }

        public async Task AssertCurrentPathAsync(string expectedPath)
        {
            await
                _page
                    .WaitForLoadStateAsync(
                        LoadState.NetworkIdle,
                        new PageWaitForLoadStateOptions { Timeout = 3000 }
                    );
            
            var url =
                _page
                    .Url;

            var expectedFullUrl = $"{_options.BaseUrl}{expectedPath}";

            if (!string.Equals(
                    url,
                    expectedFullUrl
                ))
                throw new Exception($"Unexpected URL: [expected: {expectedFullUrl}, actual: {url}]");
        }
    }
}