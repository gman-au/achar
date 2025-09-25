using System.Threading.Tasks;
using Achar.Domain.Testing.Enum;
using Achar.Infrastructure.Api.HttpClient.Options;
using Achar.Infrastructure.ReqnRoll.Extensions;
using Achar.Infrastructure.Screen.Extensions;
using Achar.Infrastructure.Testing.Extensions;
using Achar.Interfaces.Testing;
using Microsoft.Extensions.Options;
using Reqnroll;

namespace Achar.Infrastructure.ReqnRoll.Steps.HighLevel
{
    [Binding]
    public class LoginSteps(
        IScreenInteractionEngine engine,
        IOptions<ApiConfigurationOptions> options
    )
    {
        [Given(@"a user navigates and logs into the app")]
        public async Task GivenAUserNavigatesAndLogsIntoTheApp()
        {
            await
                engine
                    .ActGetContext()
                    .ActNavigateToHomePageAsync();
            await
                engine
                    .ActGetContext()
                    .ActWaitForFocussedAsync(ElementSelectTypeEnum.ById, "rlUserImageView")
                    .IgnoreIfNotFound();
            await
                engine
                    .ActGetContext()
                    .ActClickFocussedAsync()
                    .IgnoreIfNotFound();
            await
                engine
                    .ActGetContext()
                    .ActWaitForFocussedAsync(ElementSelectTypeEnum.ById, "tvLogin")
                    .IgnoreIfNotFound();
            await
                engine
                    .ActGetContext()
                    .ActClickFocussedAsync()
                    .IgnoreIfNotFound();
            await
                engine
                    .ActGetContext()
                    .ActWaitForFocussedAsync(ElementSelectTypeEnum.ByText, "Enter phone no")
                    .IgnoreIfNotFound();
            await
                engine
                    .ActGetContext()
                    .ActClickFocussedAsync()
                    .IgnoreIfNotFound();
            await
                engine
                    .ActGetContext()
                    .ActSendKeysToFocussedAsync("0400000000")
                    .IgnoreIfNotFound();
            await
                engine
                    .ActGetContext()
                    .ActSetFocussedBySelectorAsync(ElementSelectTypeEnum.ByText, "Send code")
                    .IgnoreIfNotFound();
            await
                engine
                    .ActGetContext()
                    .ActClickFocussedAsync()
                    .IgnoreIfNotFound();
            await
                engine
                    .ActGetContext()
                    .ActWaitForFocussedAsync(ElementSelectTypeEnum.ById, "otp1")
                    .IgnoreIfNotFound();
            await
                engine
                    .ActGetContext()
                    .ActClickFocussedAsync()
                    .IgnoreIfNotFound();
            await
                engine
                    .ActGetContext()
                    .ActSendKeysToFocussedAsync("111111")
                    .IgnoreIfNotFound();
            await
                engine
                    .ActGetContext()
                    .ActWaitForFocussedAsync(ElementSelectTypeEnum.ByText, "Preferred name")
                    .IgnoreIfNotFound();
            await
                engine
                    .ActGetContext()
                    .ActClickFocussedAsync()
                    .IgnoreIfNotFound();
            await
                engine
                    .ActGetContext()
                    .ActSendKeysToFocussedAsync("Doug Anthony")
                    .IgnoreIfNotFound();
            await
                engine
                    .ActGetContext()
                    .ActSetFocussedBySelectorAsync(ElementSelectTypeEnum.ByText, "Done")
                    .IgnoreIfNotFound();
            await
                engine
                    .ActGetContext()
                    .ActClickFocussedAsync()
                    .IgnoreIfNotFound();
            await
                engine
                    .ActGetContext()
                    .ActSetFocussedBySelectorAsync(ElementSelectTypeEnum.ById, "ivBack")
                    .IgnoreIfNotFound();
            await
                engine
                    .ActGetContext()
                    .ActClickFocussedAsync().IgnoreIfNotFound();
            await
                engine
                    .ActGetContext()
                    .ActWaitForFocussedAsync(ElementSelectTypeEnum.ByText, "Ok")
                    .IgnoreIfNotFound();
            await
                engine
                    .ActGetContext()
                    .ActClickFocussedAsync()
                    .IgnoreIfNotFound();
        }
    }
}