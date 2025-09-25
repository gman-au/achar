using System.Threading.Tasks;
using Achar.Infrastructure.Testing.Extensions;
using Achar.Interfaces.Testing;

namespace Achar.Infrastructure.Api.Extensions
{
    public static partial class ApiFluentExtensions
    {
        public static async Task<IApiInteractionEngine> ActCreateRequestAsync(
            this Task<IApiInteractionEngine> task,
            string endpoint)
        {
            var context = await task;

            await
                context
                    .CreateRequestAsync(endpoint);

            return context;
        }

        public static async Task<string> ActLoadValueFromConfigAsync<T>(
            this T configuration,
            string configExpression)
        {
            var expression =
                ExpressionUtil
                    .GenerateMemberExpression<T>(configExpression);

            var configValue =
                expression
                    .Compile()
                    .Invoke(configuration);

            return
                configValue
                    .ToString();
        }

        public static async Task<IApiInteractionEngine> ActSendRequestAsync(
            this Task<IApiInteractionEngine> task,
            string method)
        {
            var context = await task;

            await
                context
                    .SendRequestAsync(method);

            return context;
        }

        public static async Task<IApiInteractionEngine> ActSetRequestHeaderValueAsync(
            this Task<IApiInteractionEngine> task,
            string headerKey,
            string headerValue)
        {
            var context = await task;

            await
                context
                    .SetRequestHeaderValueAsync(headerKey, headerValue);

            return context;
        }

        public static async Task<IApiInteractionEngine> ActSetRequestBodyValueAsync(
            this Task<IApiInteractionEngine> task,
            string jsonTokenPath,
            string value)
        {
            var context = await task;

            await
                context
                    .SetRequestBodyValueAsync(jsonTokenPath, value);

            return context;
        }
    }
}