using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Achar.Domain.Testing;
using Achar.Domain.Testing.Enum;
using Achar.Domain.Testing.Exception;
using Achar.Infrastructure.Appium.Android.Options;
using Achar.Interfaces.Testing;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;
using ElementNotVisibleException = Achar.Domain.Testing.Exception.ElementNotVisibleException;

namespace Achar.Infrastructure.Appium.Android
{
    public partial class AppiumInteractionEngine : IScreenInteractionEngine
    {
        protected IWebElement Locator;

        public async Task ClickFocussedAsync()
        {
            if (Locator == null)
                throw new ElementNotFoundException(LastInstruction);

            Locator
                .Click();
        }

        public async Task NavigateToHomePageAsync()
        {
            if (_appiumOptions == null)
                throw new MisconfigurationException<AppiumConfigurationOptions>();

            Driver
                .ActivateApp(_appiumOptions.StartPackageName);
        }

        public async Task NavigateToPathAsync(string path)
        {
            if (_appiumOptions == null)
                throw new MisconfigurationException<AppiumConfigurationOptions>();

            var activities =
                _appiumOptions?.ActivityList ??
                new Dictionary<string, string>();

            if (!activities.TryGetValue(path, out var activity))
                throw new PathNotFoundException(path);

            Driver
                .StartActivity(
                    _appiumOptions.StartPackageName,
                    activity
                );
        }

        public async Task SetFocussedWithScrollAsync(LocationInstruction instruction)
        {
            Func<AndroidDriver<AndroidElement>, IReadOnlyCollection<IWebElement>> byPageScroll;
            LastInstruction = instruction;

            var value = instruction.Value;

            switch (instruction.ByEnum)
            {
                case ElementSelectTypeEnum.ById:
                    byPageScroll = o => o.FindElementsByAndroidUIAutomator(
                        "new UiScrollable(new UiSelector().scrollable(true))" +
                        $".scrollIntoView(new UiSelector().resourceIdMatches(\"{_appiumOptions.StartPackageName}:id/{value}\"))");
                    break;
                case ElementSelectTypeEnum.ByText:
                    byPageScroll = o => o.FindElementsByAndroidUIAutomator(
                        "new UiScrollable(new UiSelector().scrollable(true))" +
                        $".scrollIntoView(new UiSelector().textMatches(\"{value}\"))");
                    break;
                default:
                    throw new NotImplementedException();
            }

            Locator =
                byPageScroll(Driver)?.ElementAtOrDefault(instruction.Index.GetValueOrDefault(0));
        }

        public virtual async Task SetFocussedAsync(LocationInstruction instruction)
        {
            Func<AndroidDriver<AndroidElement>, IReadOnlyCollection<IWebElement>> byPage;
            Func<IWebElement, IReadOnlyCollection<IWebElement>> byLocator;

            LastInstruction = instruction;

            var value = instruction.Value;

            switch (instruction.ByEnum)
            {
                case ElementSelectTypeEnum.ByText:
                    byPage = o => o.FindElements(By.XPath($"//*[@text='{value}']"));
                    byLocator = o => o.FindElements(By.XPath($"//*[@text='{value}']"));
                    break;
                case ElementSelectTypeEnum.ByPlaceholder:
                    byPage = o => o.FindElements(By.XPath($"//*[@hint='{value}']"));
                    byLocator = o => o.FindElements(By.XPath($"//*[@hint='{value}']"));
                    break;
                case ElementSelectTypeEnum.ByDataTestId:
                    byPage = o => o.FindElements(By.Id($"{_appiumOptions.StartPackageName}:id/{value}"));
                    byLocator = o => o.FindElements(By.Id($"{_appiumOptions.StartPackageName}:id/{value}"));
                    break;
                case ElementSelectTypeEnum.ByTitle:
                    byPage = o => o.FindElements(By.XPath($"//*[@title='{value}']"));
                    byLocator = o => o.FindElements(By.XPath($"//*[@title='{value}']"));
                    break;
                case ElementSelectTypeEnum.ByName:
                    byPage = o => o.FindElements(By.Name(value));
                    byLocator = o => o.FindElements(By.Name(value));
                    break;
                case ElementSelectTypeEnum.ByValue:
                    byPage = o => o.FindElements(By.XPath($"//*[@value='{value}']"));
                    byLocator = o => o.FindElements(By.XPath($"//*[@value='{value}']"));
                    break;
                case ElementSelectTypeEnum.ByTarget:
                    byPage = o => o.FindElements(By.XPath($"//*[@target='{value}']"));
                    byLocator = o => o.FindElements(By.XPath($"//*[@target='{value}']"));
                    break;
                case ElementSelectTypeEnum.ByClass:
                    byPage = o => o.FindElements(By.XPath($"//*[@class='{value}']"));
                    byLocator = o => o.FindElements(By.XPath($"//*[@class='{value}']"));
                    break;
                case ElementSelectTypeEnum.ById:
                    byPage = o => o.FindElements(By.Id($"{_appiumOptions.StartPackageName}:id/{value}"));
                    byLocator = o => o.FindElements(By.Id($"{_appiumOptions.StartPackageName}:id/{value}"));
                    break;
                default:
                    throw new NotImplementedException();
            }

            Expression<Func<IReadOnlyCollection<IWebElement>, IWebElement>> indexSelector =
                instruction.Index.GetValueOrDefault(0) >= 0
                    ? o => o.ElementAtOrDefault(instruction.Index.GetValueOrDefault(0))
                    : o => o.Last();

            Locator =
                instruction
                    .FromRoot
                    ? indexSelector.Compile().Invoke(byPage(Driver))
                    : indexSelector.Compile().Invoke(byLocator(Locator));
        }

        public async Task SendKeysToFocussedAsync(string text)
        {
            if (Locator == null)
                throw new ElementNotFoundException(LastInstruction);

            foreach (var keyToPress in text)
            {
                var keyValue =
                    KeyboardKeyMapper
                        .ToKeyString(keyToPress);

                var keyCode =
                    Convert
                        .ToInt32(keyValue);

                Driver
                    .PressKeyCode(
                        new KeyEvent()
                            .WithKeyCode(keyCode)
                    );
            }
        }

        public async Task SendKeysToFocussedAsync(params KeyboardKeyEnum[] keys)
        {
            if (Locator == null)
                throw new ElementNotFoundException(LastInstruction);

            foreach (var keyToPress in keys)
            {
                var keyValue =
                    KeyboardKeyMapper
                        .ToKeyString(keyToPress);

                var keyCode =
                    Convert
                        .ToInt32(keyValue);

                Driver
                    .PressKeyCode(
                        new KeyEvent()
                            .WithKeyCode(keyCode)
                    );
            }
        }

        public async Task WaitForFocussedAsync(LocationInstruction instruction)
        {
            var retries = 3;
            while (true)
                try
                {
                    retries--;
                    await
                        SetFocussedAsync(instruction);

                    await
                        AssertVisibleAsync();

                    return;
                }
                catch (ElementNotVisibleException)
                {
                    if (retries <= 0)
                        throw;

                    await
                        Task
                            .Delay(3000);
                }
        }

        public async Task WaitSecondsAsync(int seconds)
        {
            await Task.Delay(1000 * seconds);
        }

        public async Task FlingFocussedAsync(int x, int y)
        {
            if (Locator == null)
                throw new ElementNotFoundException(LastInstruction);

            var location = Locator.Location;
            var touchAction = new TouchAction(Driver)
                .Press(location.X, location.Y)
                .Wait(50)
                .MoveTo(location.X + x, location.Y + y)
                .Release();

            touchAction
                .Perform();
        }
    }
}