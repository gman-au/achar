using System.Threading.Tasks;
using Achar.Domain.Testing;
using Achar.Domain.Testing.Enum;
using Achar.Infrastructure.Testing.Extensions;
using Achar.Interfaces.Testing;

namespace Achar.Infrastructure.Screen.Extensions
{
    public static partial class ScreenFluentExtensions
    {
        public static async Task<IScreenInteractionEngine> ActWaitSecondsAsync(
            this Task<IScreenInteractionEngine> task,
            int seconds)
        {
            var context = await task;

            await
                context
                    .WaitSecondsAsync(seconds);

            return context;
        }

        public static async Task<IScreenInteractionEngine> ActNavigateToHomePageAsync(
            this Task<IScreenInteractionEngine> task)
        {
            var context = await task;

            await
                context
                    .NavigateToHomePageAsync();

            return context;
        }

        public static async Task<IScreenInteractionEngine> ActNavigateToPathAsync(
            this Task<IScreenInteractionEngine> task,
            string path)
        {
            var context = await task;

            await
                context
                    .NavigateToPathAsync(path);

            return context;
        }

        public static async Task<IScreenInteractionEngine> ActSetFocussedBySelectorWithScrollAsync(
            this Task<IScreenInteractionEngine> task,
            ElementSelectTypeEnum byEnum,
            string value,
            int? index = null,
            bool fromRoot = true
        )
        {
            var context = await task;

            var instruction =
                new LocationInstruction
                {
                    ByEnum = byEnum,
                    Value = value,
                    FromRoot = fromRoot,
                    Index = index
                };

            await
                context
                    .SetFocussedWithScrollAsync(instruction);

            return context;
        }

        public static async Task<IScreenInteractionEngine> ActSetFocussedBySelectorWithScrollAsync(
            this Task<IScreenInteractionEngine> task,
            string byString,
            string value,
            int? index = null,
            bool fromRoot = true
        ) =>
            await ActSetFocussedBySelectorWithScrollAsync(
                task,
                byString.ToEnum(),
                value,
                index,
                fromRoot
            );

        public static async Task<IScreenInteractionEngine> ActSetFocussedBySelectorAsync(
            this Task<IScreenInteractionEngine> task,
            ElementSelectTypeEnum byEnum,
            string value,
            int? index = null,
            bool fromRoot = true
        )
        {
            var context = await task;

            var instruction =
                new LocationInstruction
                {
                    ByEnum = byEnum,
                    Value = value,
                    FromRoot = fromRoot,
                    Index = index
                };

            await
                context
                    .SetFocussedAsync(instruction);

            return context;
        }

        public static async Task<IScreenInteractionEngine> ActSetFocussedBySelectorAsync(
            this Task<IScreenInteractionEngine> task,
            string byString,
            string value,
            int? index = null,
            bool fromRoot = true
        ) =>
            await ActSetFocussedBySelectorAsync(
                task,
                byString.ToEnum(),
                value,
                index,
                fromRoot
            );

        public static async Task<IScreenInteractionEngine> ActSendKeysToFocussedAsync(
            this Task<IScreenInteractionEngine> task,
            params KeyboardKeyEnum[] keys
        )
        {
            var context = await task;

            await
                context
                    .SendKeysToFocussedAsync(keys);

            return context;
        }

        public static async Task<IScreenInteractionEngine> ActSendKeysToFocussedAsync(
            this Task<IScreenInteractionEngine> task,
            string value
        )
        {
            var context = await task;

            await
                context
                    .SendKeysToFocussedAsync(value);

            return context;
        }

        public static async Task<IScreenInteractionEngine> ActFlingFocussedAsync(
            this Task<IScreenInteractionEngine> task,
            int x,
            int y)
        {
            var context = await task;

            await
                context
                    .FlingFocussedAsync(x, y);

            return context;
        }

        public static async Task<IScreenInteractionEngine> ActClickFocussedAsync(this Task<IScreenInteractionEngine> task)
        {
            var context = await task;

            await
                context
                    .ClickFocussedAsync();

            return context;
        }

        public static async Task<IScreenInteractionEngine> ActWaitForFocussedAsync(
            this Task<IScreenInteractionEngine> task,
            ElementSelectTypeEnum byEnum,
            string value,
            int? index = null,
            bool fromRoot = true
        )
        {
            var context = await task;

            var instruction =
                new LocationInstruction
                {
                    ByEnum = byEnum,
                    Value = value,
                    FromRoot = fromRoot,
                    Index = index
                };

            await
                context
                    .WaitForFocussedAsync(instruction);

            return context;
        }

        public static async Task<IScreenInteractionEngine> ActWaitForFocussedAsync(
            this Task<IScreenInteractionEngine> task,
            string byString,
            string value,
            int? index = null,
            bool fromRoot = true
        ) => await ActWaitForFocussedAsync(
            task,
            byString.ToEnum(),
            value,
            index,
            fromRoot
        );    }
}