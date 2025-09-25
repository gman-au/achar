using System.Threading.Tasks;
using Achar.Interfaces.Testing;

namespace Achar.Infrastructure.Screen.Extensions
{
    public static partial class ScreenFluentExtensions
    {
        public static async Task<IScreenInteractionEngine> AssertVisibleAsync(this Task<IScreenInteractionEngine> task)
        {
            var context = await task;

            await
                context
                    .AssertVisibleAsync();

            return context;
        }

        public static async Task<IScreenInteractionEngine> AssertNotVisibleAsync(
            this Task<IScreenInteractionEngine> task)
        {
            var context = await task;

            await
                context
                    .AssertNotVisibleAsync();

            return context;
        }

        public static async Task<IScreenInteractionEngine> AssertClickableAsync(this Task<IScreenInteractionEngine> task)
        {
            var context = await task;

            await
                context
                    .AssertClickableAsync();

            return context;
        }

        public static async Task<IScreenInteractionEngine> AssertNotClickableAsync(this Task<IScreenInteractionEngine> task)
        {
            var context = await task;

            await
                context
                    .AssertNotClickableAsync();

            return context;
        }
    }
}