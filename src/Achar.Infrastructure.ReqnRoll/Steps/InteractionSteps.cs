using System.Threading.Tasks;
using Achar.Infrastructure.Testing.Extensions;
using Achar.Interfaces.Testing;
using Reqnroll;

namespace Achar.Infrastructure.ReqnRoll.Steps
{
    [Binding]
    public class InteractionSteps(IInteractionEngine engine)
    {
        /// <summary>
        /// Waits a number of seconds before continuing.
        /// </summary>
        /// <param name="seconds">The wait interval, in seconds.</param>
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