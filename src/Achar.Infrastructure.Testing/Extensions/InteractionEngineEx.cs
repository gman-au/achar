using System.Threading.Tasks;
using Achar.Interfaces.Testing;

namespace Achar.Infrastructure.Testing.Extensions
{
    public static class InteractionEngineEx
    {
        public static Task<T> ActGetContext<T>(this T engine) => Task.FromResult(engine);

        public static async Task<IInteractionEngine> ActWaitSecondsAsync(
            this Task<IInteractionEngine> task,
            int seconds)
        {
            var context = await task;

            await
                context
                    .WaitSecondsAsync(seconds);

            return context;
        }
    }
}