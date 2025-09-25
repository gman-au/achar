using System.Threading.Tasks;
using Achar.Interfaces.Testing;
using Reqnroll;

namespace Achar.Infrastructure.ReqnRoll.Hooks
{
    [Binding]
    public class ScreenInteractionEngineHook
    {
        [Before(Order = 2)]
        public static async Task OpenAsync(IScopedTestingContextManager contextManager)
        {
            var engine =
                contextManager
                    .GetScreenInteractionEngine();

            await
                engine
                    .SetupContextAsync();
        }

        [After(Order = 999)]
        public static async Task CloseBrowserAsync(IScopedTestingContextManager contextManager)
        {
            var engine =
                contextManager
                    .GetScreenInteractionEngine();

            await
                engine
                    .TeardownContextAsync();
        }
    }
}