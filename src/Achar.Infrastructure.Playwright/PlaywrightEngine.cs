using System.IO;
using System.Threading.Tasks;
using Achar.Domain.Testing;
using Achar.Domain.Testing.Enum;
using Achar.Infrastructure.Playwright.Options;
using Achar.Interfaces.Testing;
using Microsoft.Extensions.Options;
using Microsoft.Playwright;

namespace Achar.Infrastructure.Playwright
{
    public partial class PlaywrightEngine : IScreenInteractionEngine
    {
        private readonly IPlaywright _playwright;

        private readonly WebDriverConfigurationOptions _options;
        private readonly IKeyboardKeyMapper _keyboardKeyMapper;

        private LocationInstruction _lastInstruction;

        private IBrowserContext _browserContext;
        private IPage _page;
        private string _testName;

        public bool IsApplicable(RunnerTypeEnum runnerType) => runnerType == RunnerTypeEnum.Web;

        public PlaywrightEngine(
            IKeyboardKeyMapper keyboardKeyMapper,
            IOptions<WebDriverConfigurationOptions> optionsAccessor
        )
        {
            _keyboardKeyMapper = keyboardKeyMapper;
            _options = optionsAccessor.Value;

            _playwright =
                Microsoft.Playwright.Playwright
                    .CreateAsync()
                    .Result;
        }

        public async Task ResetContextAsync()
        {
            if (!(_page?.IsClosed).GetValueOrDefault(true))
            {
                await
                    _page
                        .CloseAsync();
            }
            
            await 
                CreateNewBrowserContextAsync();
        }

        public async Task TeardownContextAsync(bool? failed)
        {
            if (_browserContext != null && !string.IsNullOrEmpty(_options.ArtifactOutputPath))
            {
                if (_page != null)
                {
                    await
                        _page
                            .CloseAsync();
                }
            }
        }
        
        private async Task CreateNewBrowserContextAsync()
        {
            var browser =
                await
                    _playwright
                        .Chromium
                        .LaunchAsync(
                            new BrowserTypeLaunchOptions
                            {
                                Headless = _options.Headless,
                                ExecutablePath = _options.CustomBrowserExecutablePath
                            }
                        );
            
            _browserContext =
                await
                    browser
                        .NewContextAsync(
                            new BrowserNewContextOptions
                            {
                                IgnoreHTTPSErrors = _options.IgnoreHttpsErrors
                            }
                        );

            _page =
                await
                    _browserContext
                        .NewPageAsync();
            
            _page
                .SetDefaultTimeout(_options.LocatorTimeout);
        }

        public async Task StartRecordingAsync()
        {
            if (!string.IsNullOrEmpty(_options.ArtifactOutputPath))
            {
                await
                    _browserContext
                        .Tracing
                        .StartAsync(
                            new TracingStartOptions
                            {
                                Screenshots = true,
                                Snapshots = true,
                                Sources = true
                            }
                        );
            }
        }

        public async Task<string> StopAndGetRecordingAsync(bool? failed = null)
        {
            if (_browserContext != null && !string.IsNullOrEmpty(_options.ArtifactOutputPath))
            {
                await
                    _browserContext
                        .Tracing
                        .StopAsync(
                            new TracingStopOptions
                            {
                                Path =
                                    failed.GetValueOrDefault(false) || !_options.ArtifactsOnFailureOnly
                                        ? Path
                                            .Combine(
                                                _options.ArtifactOutputPath,
                                                $"{_testName}.zip"
                                            )
                                        : null
                            }
                        );

                if (_page != null)
                {
                    await
                        _page
                            .CloseAsync();
                }
            }

            return null;
        }

        public async Task SetupContextAsync(string testName = null)
        {
            _testName = testName;

            await
                CreateNewBrowserContextAsync();
        }
    }
}