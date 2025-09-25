using System.Threading.Tasks;
using Achar.Infrastructure.Testing.Extensions;
using Achar.Interfaces.Testing;
using Reqnroll;

namespace Achar.Infrastructure.ReqnRoll.Steps
{
    [Binding]
    public class InteractionSteps(IInteractionEngine engine)
    {
        [Given(@"(.*) seconds have elapsed")]
        [When(@"(.*) seconds have elapsed")]
        [Then(@"(.*) seconds have elapsed")]
        public async Task GivenSecondsHaveElapsed(int seconds)
        {
            await
                engine
                    .ActGetContext()
                    .ActWaitSecondsAsync(seconds);
        }
    }
}