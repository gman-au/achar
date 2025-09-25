using System.Threading.Tasks;
using Achar.Domain.Testing.Enum;
using Achar.Infrastructure.Api.Options;
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
                Utils.IfPresentPerformAction(
                    engine
                        .ActGetContext()
                        .ActWaitForFocussedAsync(ElementSelectTypeEnum.ById, "rlUserImageView"));
            await
                Utils.IfPresentPerformAction(
                    engine
                        .ActGetContext()
                        .ActClickFocussedAsync());
            await
                Utils.IfPresentPerformAction(
                    engine
                        .ActGetContext()
                        .ActWaitForFocussedAsync(ElementSelectTypeEnum.ById, "tvLogin"));
            await
                Utils.IfPresentPerformAction(
                    engine
                        .ActGetContext()
                        .ActClickFocussedAsync());
            await
                Utils.IfPresentPerformAction(
                    engine
                        .ActGetContext()
                        .ActWaitForFocussedAsync(ElementSelectTypeEnum.ByText, "Enter phone no"));
            await
                Utils.IfPresentPerformAction(
                    engine
                        .ActGetContext()
                        .ActClickFocussedAsync());
            await
                Utils.IfPresentPerformAction(
                    engine
                        .ActGetContext()
                        .ActSendKeysToFocussedAsync("0400000000"));
            await
                Utils.IfPresentPerformAction(
                    engine
                        .ActGetContext()
                        .ActSetFocussedBySelectorAsync(ElementSelectTypeEnum.ByText, "Send code"));
            await
                Utils.IfPresentPerformAction(
                    engine
                        .ActGetContext()
                        .ActClickFocussedAsync());
            await
                Utils.IfPresentPerformAction(
                    engine
                        .ActGetContext()
                        .ActWaitForFocussedAsync(ElementSelectTypeEnum.ById, "otp1"));
            await
                Utils.IfPresentPerformAction(
                    engine
                        .ActGetContext()
                        .ActClickFocussedAsync());
            await
                Utils.IfPresentPerformAction(
                    engine
                        .ActGetContext()
                        .ActSendKeysToFocussedAsync("111111"));
            await
                Utils.IfPresentPerformAction(
                    engine
                        .ActGetContext()
                        .ActWaitForFocussedAsync(ElementSelectTypeEnum.ByText, "Preferred name"));
            await
                Utils.IfPresentPerformAction(
                    engine
                        .ActGetContext()
                        .ActClickFocussedAsync());
            await
                Utils.IfPresentPerformAction(
                    engine
                        .ActGetContext()
                        .ActSendKeysToFocussedAsync("Doug Anthony"));
            await
                Utils.IfPresentPerformAction(
                    engine
                        .ActGetContext()
                        .ActSetFocussedBySelectorAsync(ElementSelectTypeEnum.ByText, "Done"));
            await
                Utils.IfPresentPerformAction(
                    engine
                        .ActGetContext()
                        .ActClickFocussedAsync());
            await
                Utils.IfPresentPerformAction(
                    engine
                        .ActGetContext()
                        .ActSetFocussedBySelectorAsync(ElementSelectTypeEnum.ById, "ivBack"));
            await
                Utils.IfPresentPerformAction(
                    engine
                        .ActGetContext()
                        .ActClickFocussedAsync());
            await
                Utils.IfPresentPerformAction(
                    engine
                        .ActGetContext()
                        .ActWaitForFocussedAsync(ElementSelectTypeEnum.ByText, "Ok"));
            await
                Utils.IfPresentPerformAction(
                    engine
                        .ActGetContext()
                        .ActClickFocussedAsync());
        }
    }
}