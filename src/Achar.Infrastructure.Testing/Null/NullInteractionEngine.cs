using System.Threading.Tasks;
using Achar.Domain.Testing;
using Achar.Domain.Testing.Enum;
using Achar.Interfaces.Testing;

namespace Achar.Infrastructure.Testing.Null
{
    public class NullInteractionEngine : IScreenInteractionEngine, IApiInteractionEngine
    {
        public LocationInstruction LastInstruction { get; set; }

        public Task CreateRequestAsync(string endpoint) => Task.CompletedTask;

        public Task SendRequestAsync(string method) => Task.CompletedTask;

        public Task SetRequestHeaderValueAsync(
            string headerKey,
            string headerValue) => Task.CompletedTask;

        public Task SetRequestBodyValueAsync(
            string jsonTokenPath,
            string value) => Task.CompletedTask;

        public Task AssertResponseSucceededAsync() => Task.CompletedTask;

        public Task AssertResponseFailedAsync(int? expectedStatusCode = null) => Task.CompletedTask;

        public Task AssertJsonTokenPathValueEqualsAsync(
            string jsonTokenPath,
            string expectedValue) => Task.CompletedTask;

        public Task SetupContextAsync() => Task.CompletedTask;

        public Task ResetContextAsync() => Task.CompletedTask;

        public Task TeardownContextAsync() => Task.CompletedTask;

        public Task FlingFocussedAsync(
            int x,
            int y) => Task.CompletedTask;

        public Task InjectAudioFileAsync(string fileReference) => Task.CompletedTask;

        public Task PlayAudioFileAsync() => Task.CompletedTask;

        public bool IsApplicable(RunnerTypeEnum runnerType) => runnerType == RunnerTypeEnum.NotSet;

        public Task AssertClickableAsync() => Task.CompletedTask;

        public Task AssertNotClickableAsync() => Task.CompletedTask;

        public Task AssertVisibleAsync() => Task.CompletedTask;

        public Task AssertNotVisibleAsync() => Task.CompletedTask;

        public Task AssertEqualAsync(string expected) => Task.CompletedTask;

        public Task AssertCurrentPathAsync(string expectedPath) => Task.CompletedTask;

        public Task ClickFocussedAsync() => Task.CompletedTask;

        public Task NavigateToHomePageAsync() => Task.CompletedTask;

        public Task NavigateToPathAsync(string path) => Task.CompletedTask;

        public Task SetFocussedAsync(LocationInstruction instruction) => Task.CompletedTask;

        public Task SetFocussedWithScrollAsync(LocationInstruction instruction) => Task.CompletedTask;

        public Task SendKeysToFocussedAsync(params KeyboardKeyEnum[] keys) => Task.CompletedTask;

        public Task SendKeysToFocussedAsync(string value) => Task.CompletedTask;

        public Task WaitForFocussedAsync(LocationInstruction instruction) => Task.CompletedTask;

        public Task WaitSecondsAsync(int seconds) => Task.CompletedTask;

        public Task StartRecordingAsync() => Task.CompletedTask;

        public Task<string> StopAndGetRecordingAsync() => Task.FromResult<string>(null);

        public Task FillFocussedWithTextAsync(string text) => Task.CompletedTask;
    }
}