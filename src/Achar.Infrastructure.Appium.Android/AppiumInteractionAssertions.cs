using System;
using System.Threading.Tasks;
using Achar.Domain.Testing.Exception;
using Achar.Interfaces.Testing;

namespace Achar.Infrastructure.Appium.Android
{
    public partial class AppiumInteractionEngine : IScreenInteractionEngine
    {
        public async Task AssertClickableAsync()
        {
            if (!(Locator?.Enabled ?? false))
                throw new ElementNotClickableException(
                    LastInstruction
                );
        }

        public async Task AssertNotClickableAsync()
        {
            if (Locator.Enabled)
                throw new ElementClickableException(
                    LastInstruction
                );
        }

        public async Task AssertVisibleAsync()
        {
            if (!(Locator?.Displayed ?? false))
                throw new ElementNotVisibleException(
                    LastInstruction
                );
        }

        public async Task AssertNotVisibleAsync()
        {
            if (Locator.Displayed)
                throw new ElementVisibleException(
                    LastInstruction
                );
        }

        public Task AssertEqualAsync(string expected)
        {
            throw new NotImplementedException();
        }

        public Task AssertCurrentPathAsync(string expectedPath)
        {
            throw new NotImplementedException();
        }
    }
}