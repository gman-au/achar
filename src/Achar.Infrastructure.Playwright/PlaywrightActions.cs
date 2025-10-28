using System;
using System.Threading.Tasks;
using Achar.Domain.Testing;
using Achar.Domain.Testing.Enum;
using Achar.Domain.Testing.Exception;
using Achar.Interfaces.Testing;
using Microsoft.Playwright;

namespace Achar.Infrastructure.Playwright
{
    public partial class PlaywrightEngine : IScreenInteractionEngine
    {
        private ILocator _locator;

        public async Task NavigateToHomePageAsync()
        {
            if (_page != null)
            {
                await
                    _page
                        .GotoAsync(_options.BaseUrl);
            }
        }

        public async Task NavigateToPathAsync(string path)
        {
            if (_page != null)
            {
                await
                    _page
                        .GotoAsync(_options.BaseUrl + path);
            }
        }

        public async Task SetFocussedAsync(LocationInstruction instruction)
        {
            Func<IPage, ILocator> byPage;
            Func<ILocator, ILocator> byLocator;

            _lastInstruction = instruction;

            var value = instruction.Value;

            switch (instruction.ByEnum)
            {
                case ElementSelectTypeEnum.ByText:
                    byPage = o => o.GetByText(value);
                    byLocator = o => o.GetByText(value);
                    break;
                case ElementSelectTypeEnum.ByPlaceholder:
                    byPage = o => o.GetByPlaceholder(value);
                    byLocator = o => o.GetByPlaceholder(value);
                    break;
                case ElementSelectTypeEnum.ByDataTestId:
                    byPage = o => o.GetByTestId(value);
                    byLocator = o => o.GetByTestId(value);
                    break;
                case ElementSelectTypeEnum.ByTitle:
                    byPage = o => o.Locator($"[title='{value}']");
                    byLocator = o => o.Locator($"[title='{value}']");
                    break;
                case ElementSelectTypeEnum.ByName:
                    byPage = o => o.Locator($"[name='{value}']");
                    byLocator = o => o.Locator($"[name='{value}']");
                    break;
                case ElementSelectTypeEnum.ByValue:
                    byPage = o => o.Locator($"[value='{value}']");
                    byLocator = o => o.Locator($"[value='{value}']");
                    break;
                case ElementSelectTypeEnum.ByTarget:
                    byPage = o => o.Locator($"[target='{value}']");
                    byLocator = o => o.Locator($"[target='{value}']");
                    break;
                case ElementSelectTypeEnum.ByClass:
                    byPage = o => o.Locator($"[class='{value}']");
                    byLocator = o => o.Locator($"[class='{value}']");
                    break;
                case ElementSelectTypeEnum.ById:
                    byPage = o => o.Locator($"[id='{value}']");
                    byLocator = o => o.Locator($"[id='{value}']");
                    break;
                default:
                    throw new NotImplementedException();
            }

            _locator =
                instruction
                    .FromRoot
                    ? byPage(_page)?.Nth(instruction.Index.GetValueOrDefault(0))
                    : byLocator(_locator)?.Nth(instruction.Index.GetValueOrDefault(0));
        }

        public async Task WaitForFocussedAsync(LocationInstruction instruction)
        {
            var retries = 3;
            while (retries > 0)
            {
                try
                {
                    await
                        SetFocussedAsync(instruction);

                    await
                        AssertVisibleAsync();

                    return;
                }
                catch (ElementNotVisibleException)
                {
                    await
                        Task
                            .Delay(3000);
                }
                finally
                {
                    retries--;

                    await
                        _page
                            .WaitForLoadStateAsync(
                                LoadState.NetworkIdle,
                                new PageWaitForLoadStateOptions { Timeout = 3000 }
                            );
                }
            }
        }

        public async Task SendKeysToFocussedAsync(params KeyboardKeyEnum[] keys)
        {
            foreach (var keyToPress in keys)
            {
                var keyValue =
                    _keyboardKeyMapper
                        .ToKeyString(keyToPress);

                await
                    _page
                        .Keyboard
                        .PressAsync(
                            keyValue,
                            new KeyboardPressOptions { Delay = 500 }
                        );
            }
        }

        public async Task ClickFocussedAsync() => await _locator.ClickAsync();

        public async Task WaitSecondsAsync(int seconds) => await _page.WaitForTimeoutAsync(1000 * seconds);


        public Task SetFocussedWithScrollAsync(LocationInstruction instruction) => throw new NotImplementedException();

        public async Task SendKeysToFocussedAsync(string value)
        {
            await
                _locator
                    .PressSequentiallyAsync(
                        value,
                        new LocatorPressSequentiallyOptions { Delay = 10 }
                    );
        }

        public Task FlingFocussedAsync(
            int x,
            int y) =>
            throw new NotImplementedException();
    }
}