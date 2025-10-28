using System;
using System.Threading.Tasks;
using Achar.Domain.Testing;
using Achar.Domain.Testing.Enum;
using Achar.Infrastructure.Appium.Android.Options;
using Achar.Infrastructure.Testing.Extensions;
using Achar.Interfaces.Reporting;
using Achar.Interfaces.Testing;
using Microsoft.Extensions.Options;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;

namespace Achar.Infrastructure.Appium.Android
{
    public partial class AppiumInteractionEngine(
        IDeviceDataBuilder deviceDataBuilder,
        IOptions<AppiumConfigurationOptions> appiumOptionsAccessor,
        IKeyboardKeyMapper keyboardKeyMapper)
        : IScreenInteractionEngine
    {
        private readonly AppiumConfigurationOptions _appiumOptions = appiumOptionsAccessor.Value;
        protected readonly IDeviceDataBuilder DeviceDataBuilder = deviceDataBuilder;
        protected readonly IKeyboardKeyMapper KeyboardKeyMapper = keyboardKeyMapper;
        protected AndroidDriver<AndroidElement> Driver;
        protected LocationInstruction LastInstruction;

        private readonly RecordingConfigurationOptions _recordingOptions =
            appiumOptionsAccessor
                .Value?
                .RecordingConfigurationOptions;

        public bool IsApplicable(RunnerTypeEnum runnerType) => runnerType == RunnerTypeEnum.Mobile;

        public virtual async Task SetupContextAsync(string testName = null)
        {
            var serverUri = new Uri(_appiumOptions.AppiumHost);
            var capabilities =
                new AppiumOptions
                {
                    PlatformName = _appiumOptions.PlatformName,
                };

            capabilities.AddAdditionalCapability("appium:platformVersion", _appiumOptions.PlatformVersion);
            capabilities.AddAdditionalCapability("appium:deviceName", _appiumOptions.DeviceName);
            capabilities.AddAdditionalCapability("appium:automationName", AutomationName.AndroidUIAutomator2);
            capabilities.AddAdditionalCapability("appium:autoGrantPermissions", "true");
            capabilities.AddAdditionalCapability("appium:appProfiling", "true");

            Driver =
                new AndroidDriver<AndroidElement>(
                    serverUri,
                    capabilities,
                    TimeSpan.FromSeconds(300)
                );

            var returnedCapabilities = Driver.Capabilities;

            DeviceDataBuilder
                .CreateDeviceDataBuilder()
                .WithDeviceManufacturer(returnedCapabilities.GetCapability("deviceManufacturer")?.ToString())
                .WithDeviceModel(returnedCapabilities.GetCapability("deviceModel")?.ToString())
                .WithDeviceApiLevel(returnedCapabilities.GetCapability("deviceApiLevel")?.ToString())
                .WithDeviceName(returnedCapabilities.GetCapability("deviceName")?.ToString())
                .WithDeviceId(returnedCapabilities.GetCapability("deviceUDID")?.ToString())
                .WithDeviceScreenSize(returnedCapabilities.GetCapability("deviceScreenSize")?.ToString())
                .WithPlatformName(returnedCapabilities.GetCapability("platformName")?.ToString())
                .WithPlatformVersion(returnedCapabilities.GetCapability("platformVersion")?.ToString())
                .WithPixelRatio(returnedCapabilities.GetCapability("pixelRatio")?.ToString())
                .WithOsName(returnedCapabilities.GetCapability("platform")?.ToString());
        }

        public async Task ResetContextAsync()
        {
            throw new NotImplementedException();
        }

        public async Task StartRecordingAsync()
        {
            if (_recordingOptions?.Enabled ?? false)
            {
                var bitRate = _recordingOptions?.BitRate ?? 4000000;

                var recordingOptions =
                    new AndroidStartScreenRecordingOptions()
                        .WithBitRate(bitRate);

                Driver
                    .StartRecordingScreen(recordingOptions);
            }
        }

        public async Task<string> StopAndGetRecordingAsync(bool? failed = null)
        {
            if (!(_recordingOptions?.Enabled ?? false)) return null;

            var data =
                Driver?
                    .StopRecordingScreen();

            return data;
        }

        public async Task TeardownContextAsync(bool? failed = null)
        {
            Driver
                .TerminateApp(_appiumOptions.StartPackageName);

            Driver
                .Quit();
        }
    }
}