using System.Threading.Tasks;
using Achar.Interfaces.Testing;

namespace Achar.Infrastructure.Api.Extensions
{
    public static partial class ApiFluentExtensions
    {
        public static async Task<IApiInteractionEngine> AssertResponseSucceededAsync(this Task<IApiInteractionEngine> task)
        {
            var context = await task;

            await
                context
                    .AssertResponseSucceededAsync();

            return context;
        }

        public static async Task<IApiInteractionEngine> AssertResponseFailedAsync(
            this Task<IApiInteractionEngine> task,
            int? expectedStatusCode = null)
        {
            var context = await task;

            await
                context
                    .AssertResponseFailedAsync(expectedStatusCode);

            return context;
        }

        public static async Task<IApiInteractionEngine> AssertJsonTokenPathValueEqualsAsync(
            this Task<IApiInteractionEngine> task,
            string jsonTokenPath,
            string expectedValue)
        {
            var context = await task;

            await
                context
                    .AssertJsonTokenPathValueEqualsAsync(jsonTokenPath, expectedValue);

            return context;
        }
    }
}