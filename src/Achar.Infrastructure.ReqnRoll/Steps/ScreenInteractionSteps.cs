using System.Threading.Tasks;
using Achar.Infrastructure.ReqnRoll.Extensions;
using Achar.Infrastructure.Screen.Extensions;
using Achar.Infrastructure.Testing.Extensions;
using Achar.Interfaces.Testing;
using Reqnroll;

namespace Achar.Infrastructure.ReqnRoll.Steps
{
    [Binding]
    public class ScreenInteractionSteps(IScreenInteractionEngine engine)
    {
        private const string IfPresentPrefix = "if present, ";

        [Given("a user has navigated to the home page")]
        public async Task GivenAUserHasNavigatedToTheHomePage()
        {
            await
                engine
                    .ActGetContext()
                    .ActNavigateToHomePageAsync();
        }

        [Given(@"a user has navigated to the ""(.*)"" page")]
        public async Task GivenAUserHasNavigatedToThePage(string path)
        {
            await
                engine
                    .ActGetContext()
                    .ActNavigateToPathAsync(path);
        }

        [Given($@"{IfPresentPrefix}locates the (.*) with (.*) ""(.*)""")]
        [When($@"{IfPresentPrefix}locates the (.*) with (.*) ""(.*)""")]
        public async Task GivenIfPresentLocatesTheWith(
            string element,
            string selector,
            string value) =>
            await
                GivenLocatesTheWith(element, selector, value)
                    .IgnoreIfNotFound();

        [Given(@"locates the (.*) with (.*) ""(.*)""")]
        [When(@"locates the (.*) with (.*) ""(.*)""")]
        public async Task GivenLocatesTheWith(
            string element,
            string selector,
            string value)
        {
            await
                engine
                    .ActGetContext()
                    .ActSetFocussedBySelectorAsync(
                        selector,
                        value
                    )
                    .AssertVisibleAsync();
        }

        [Given($@"{IfPresentPrefix}enters ""(.*)"" into that (.*)")]
        [When($@"{IfPresentPrefix}enters ""(.*)"" into that (.*)")]
        public async Task GivenIfPresentEntersIntoThat(
            string value,
            string element) =>
            await
                GivenEntersIntoThat(value, element)
                    .IgnoreIfNotFound();

        [Given(@"enters ""(.*)"" into that (.*)")]
        [When(@"enters ""(.*)"" into that (.*)")]
        public async Task GivenEntersIntoThat(
            string value,
            string element)
        {
            await
                engine
                    .ActGetContext()
                    .ActSendKeysToFocussedAsync(value);
        }

        [Given($@"{IfPresentPrefix}clicks on that (.*)")]
        [Given($@"{IfPresentPrefix}taps on that (.*)")]
        [When($@"{IfPresentPrefix}clicks on that (.*)")]
        [When($@"{IfPresentPrefix}taps on that (.*)")]
        public async Task GivenIfPresentClicksOnThat(string element) =>
            await
                GivenClicksOnThat(element)
                    .IgnoreIfNotFound();

        [Given("clicks on that (.*)")]
        [Given("taps on that (.*)")]
        [When("clicks on that (.*)")]
        [When("taps on that (.*)")]
        public async Task GivenClicksOnThat(string element)
        {
            await
                engine
                    .ActGetContext()
                    .ActClickFocussedAsync();
        }

        [Given(@"scrolls the (.*) with (.*) ""(.*)"" into view")]
        [When(@"scrolls the (.*) with (.*) ""(.*)"" into view")]
        public async Task GivenScrollsTheWithIntoView(
            string element,
            string selector,
            string value)
        {
            await
                engine
                    .ActGetContext()
                    .ActSetFocussedBySelectorWithScrollAsync(
                        selector,
                        value
                    )
                    .AssertVisibleAsync();
        }

        [Given(@"flings down (.*)")]
        [When(@"flings down (.*)")]
        public async Task GivenFlingsDown(int y)
        {
            await
                engine
                    .ActGetContext()
                    .ActFlingFocussedAsync(
                        0,
                        y
                    )
                    .AssertVisibleAsync();
        }

        [Given($@"{IfPresentPrefix}waits for (.*) with (.*) ""(.*)"" to appear")]
        [When($@"{IfPresentPrefix}waits for (.*) with (.*) ""(.*)"" to appear")]
        public async Task GivenIfPresentWaitsForWithToAppear(
            string element,
            string selector,
            string value) =>
            await
                GivenWaitsForWithToAppear(element, selector, value)
                    .IgnoreIfNotFound();

        [Given(@"waits for (.*) with (.*) ""(.*)"" to appear")]
        [When(@"waits for (.*) with (.*) ""(.*)"" to appear")]
        public async Task GivenWaitsForWithToAppear(
            string element,
            string selector,
            string value)
        {
            await
                engine
                    .ActGetContext()
                    .ActWaitForFocussedAsync(
                        selector,
                        value
                    );
        }

        [Given(@"finds the (.*) (.*) with (.*) ""(.*)""")]
        [When(@"finds the (.*) (.*) with (.*) ""(.*)""")]
        public async Task GivenFindsTheWith(
            string nth,
            string element,
            string selector,
            string value)
        {
            var index =
                nth
                    .ExtractZeroBasedIndex();

            await
                engine
                    .ActGetContext()
                    .ActSetFocussedBySelectorAsync(
                        selector,
                        value,
                        index
                    )
                    .AssertVisibleAsync();
        }

        [Given(@"injects an audio file with reference ""(.*)""")]
        [When(@"injects an audio file with reference ""(.*)""")]
        public async Task GivenInjectsAnAudioFileWithReference(string reference)
        {
            await
                engine
                    .ActGetContext()
                    .ActInjectAudioFileAsync(reference);
        }

        [Given(@"plays the injected audio")]
        [When(@"plays the injected audio")]
        public async Task GivenPlaysTheInjectedAudio()
        {
            await
                engine
                    .ActGetContext()
                    .ActPlayAudioFileAsync();
        }

        [Then(@"the (.*) should not be visible")]
        public async Task ThenTheShouldNotBeVisible(string element)
        {
            await
                engine
                    .ActGetContext()
                    .AssertNotVisibleAsync();
        }

        [Then(@"the (.*) should be visible")]
        public async Task ThenTheShouldBeVisible(string element)
        {
            await
                engine
                    .ActGetContext()
                    .AssertVisibleAsync();
        }

        [Then(@"the (.*) should not be clickable")]
        public async Task ThenTheShouldNotBeClickable(string element)
        {
            await
                engine
                    .ActGetContext()
                    .AssertNotClickableAsync();
        }

        [Then(@"the (.*) should be clickable")]
        public async Task ThenTheShouldBeClickable(string element)
        {
            await
                engine
                    .ActGetContext()
                    .AssertClickableAsync();
        }

        [Given(@"waits (.*) seconds")]
        [When(@"waits (.*) seconds")]
        public async Task GivenWaitsSeconds(int seconds)
        {
            await
                engine
                    .ActGetContext()
                    .ActWaitSecondsAsync(seconds);
        }
    }
}