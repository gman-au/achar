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

        /// <summary>
        /// Navigates to the home / base page URL.
        /// </summary>
        [Given("a user has navigated to the home page")]
        public async Task GivenAUserHasNavigatedToTheHomePage()
        {
            await
                engine
                    .ActGetContext()
                    .ActNavigateToHomePageAsync();
        }

        /// <summary>
        /// Navigates to a specific path against the base URL.
        /// This is not an interaction step per se, instead, the URL is rewritten directly.
        /// </summary>
        /// <param name="path">The path relative to the base URL e.g. "/products/10".</param>
        [Given(@"a user has navigated to the ""(.*)"" page")]
        public async Task GivenAUserHasNavigatedToThePage(string path)
        {
            await
                engine
                    .ActGetContext()
                    .ActNavigateToPathAsync(path);
        }

        /// <summary>
        /// Attempts to locate a screen element using a defined selector.
        /// After attempting, silently ignores if the element is not visible.
        /// </summary>
        /// <param name="element">The name of the element e.g. "button", "list", "banner". Used only for step clarity.</param>
        /// <param name="selector">The selector through which the value is passed. Can be any entry from the SelectorMappings dictionary e.g. "id", "text", "title".</param>
        /// <param name="value">The value of the selector, e.g. "data-test-id-submit-button" or "AgeTextField".</param>
        [Given($@"{IfPresentPrefix}locates the (.*) with (.*) ""(.*)""")]
        [When($@"{IfPresentPrefix}locates the (.*) with (.*) ""(.*)""")]
        public async Task GivenIfPresentLocatesTheWith(
            string element,
            string selector,
            string value) =>
            await
                GivenLocatesTheWith(element, selector, value)
                    .IgnoreIfNotFound();

        /// <summary>
        /// Attempts to locate a screen element using a defined selector.
        /// After attempting, asserts that it is visible and fails if it is not.
        /// </summary>
        /// <param name="element">The name of the element e.g. "button", "list", "banner". Used only for step clarity.</param>
        /// <param name="selector">The selector through which the value is passed. Can be any entry from the SelectorMappings dictionary e.g. "id", "text", "title".</param>
        /// <param name="value">The value of the selector, e.g. "data-test-id-submit-button" or "AgeTextField".</param>
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

        /// <summary>
        /// Enters a series of characters into a given element, e.g. typing text into a text or number box.
        /// Silently ignores and aborts the command if the element is not visible.
        /// </summary>
        /// <param name="value">The value of the text to be passed to the element.</param>
        /// <param name="element">The name of the element e.g. "button", "list", "banner". Used only for step clarity.</param>
        [Given($@"{IfPresentPrefix}enters ""(.*)"" into that (.*)")]
        [When($@"{IfPresentPrefix}enters ""(.*)"" into that (.*)")]
        public async Task GivenIfPresentEntersIntoThat(
            string value,
            string element) =>
            await
                GivenEntersIntoThat(value, element)
                    .IgnoreIfNotFound();

        /// <summary>
        /// Enters a series of characters into a given element, e.g. typing text into a text box.
        /// </summary>
        /// <param name="value">The value of the text to be passed to the element.</param>
        /// <param name="element">The name of the element e.g. "button", "list", "banner". Used only for step clarity.</param>
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

        /// <summary>
        /// Sends a 'press' or 'click' event to the screen element.
        /// Silently ignores and aborts the command if the element is not visible or clickable.
        /// </summary>
        /// <param name="element">The name of the element e.g. "button", "list", "banner". Used only for step clarity.</param>
        [Given($@"{IfPresentPrefix}clicks on that (.*)")]
        [Given($@"{IfPresentPrefix}taps on that (.*)")]
        [When($@"{IfPresentPrefix}clicks on that (.*)")]
        [When($@"{IfPresentPrefix}taps on that (.*)")]
        public async Task GivenIfPresentClicksOnThat(string element) =>
            await
                GivenClicksOnThat(element)
                    .IgnoreIfNotFound();

        /// <summary>
        /// Sends a 'press' or 'click' event to the screen element.
        /// Asserts that it is clickable and fails if it is not.
        /// </summary>
        /// <param name="element">The name of the element e.g. "button", "list", "banner". Used only for step clarity.</param>
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

        /// <summary>
        /// Attempts to locate a screen element using a defined selector, scrolling the screen downwards if required.
        /// After attempting, asserts that it is visible and fails if it is not.
        /// </summary>
        /// <param name="element">The name of the element e.g. "button", "list", "banner". Used only for step clarity.</param>
        /// <param name="selector">The selector through which the value is passed. Can be any entry from the SelectorMappings dictionary e.g. "id", "text", "title".</param>
        /// <param name="value">The value of the selector, e.g. "data-test-id-submit-button" or "AgeTextField".</param>
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

        /// <summary>
        /// Performs a 'fling' action in the direction as specified.
        /// </summary>
        /// <param name="y">The vertical fling amount, in screen units.</param>
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

        /// <summary>
        /// Attempts to locate a screen element using a defined selector, scrolling the screen downwards if required.
        /// Silently ignores and aborts the command if the element is not visible or clickable after the full timeout period.
        /// </summary>
        /// <param name="element">The name of the element e.g. "button", "list", "banner". Used only for step clarity.</param>
        /// <param name="selector">The selector through which the value is passed. Can be any entry from the SelectorMappings dictionary e.g. "id", "text", "title".</param>
        /// <param name="value">The value of the selector, e.g. "data-test-id-submit-button" or "AgeTextField".</param>
        [Given($@"{IfPresentPrefix}waits for (.*) with (.*) ""(.*)"" to appear")]
        [When($@"{IfPresentPrefix}waits for (.*) with (.*) ""(.*)"" to appear")]
        public async Task GivenIfPresentWaitsForWithToAppear(
            string element,
            string selector,
            string value) =>
            await
                GivenWaitsForWithToAppear(element, selector, value)
                    .IgnoreIfNotFound();

        /// <summary>
        /// Attempts to locate a screen element using a defined selector, waiting the full timeout period if required.
        /// After attempting, asserts that it is visible and fails if it is not.
        /// </summary>
        /// <param name="element">The name of the element e.g. "button", "list", "banner". Used only for step clarity.</param>
        /// <param name="selector">The selector through which the value is passed. Can be any entry from the SelectorMappings dictionary e.g. "id", "text", "title".</param>
        /// <param name="value">The value of the selector, e.g. "data-test-id-submit-button" or "AgeTextField".</param>
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

        /// <summary>
        /// Attempts to locate the (nth) screen element using a defined selector.
        /// After attempting, asserts that it is visible and fails if it is not.
        /// </summary>
        /// <param name="nth">The occurrence of the element you wish to find. The command will understand any value with a number e.g. "5th", "14th", "2002nd".</param>
        /// <param name="element">The name of the element e.g. "button", "list", "banner". Used only for step clarity.</param>
        /// <param name="selector">The selector through which the value is passed. Can be any entry from the SelectorMappings dictionary e.g. "id", "text", "title".</param>
        /// <param name="value">The value of the selector, e.g. "data-test-id-submit-button" or "AgeTextField".</param>
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

        /// <summary>
        /// Checks that the (last located) screen element is not visible.
        /// </summary>
        /// <param name="element">The name of the element e.g. "button", "list", "banner". Used only for step clarity.</param>
        [Then(@"the (.*) should not be visible")]
        public async Task ThenTheShouldNotBeVisible(string element)
        {
            await
                engine
                    .ActGetContext()
                    .AssertNotVisibleAsync();
        }

        /// <summary>
        /// Checks that the (last located) screen element is visible.
        /// </summary>
        /// <param name="element">The name of the element e.g. "button", "list", "banner". Used only for step clarity.</param>
        [Then(@"the (.*) should be visible")]
        public async Task ThenTheShouldBeVisible(string element)
        {
            await
                engine
                    .ActGetContext()
                    .AssertVisibleAsync();
        }

        /// <summary>
        /// Checks that the (last located) screen element is not clickable.
        /// </summary>
        /// <param name="element">The name of the element e.g. "button", "list", "banner". Used only for step clarity.</param>
        [Then(@"the (.*) should not be clickable")]
        public async Task ThenTheShouldNotBeClickable(string element)
        {
            await
                engine
                    .ActGetContext()
                    .AssertNotClickableAsync();
        }

        /// <summary>
        /// Checks that the (last located) screen element is clickable.
        /// </summary>
        /// <param name="element">The name of the element e.g. "button", "list", "banner". Used only for step clarity.</param>
        [Then(@"the (.*) should be clickable")]
        public async Task ThenTheShouldBeClickable(string element)
        {
            await
                engine
                    .ActGetContext()
                    .AssertClickableAsync();
        }

        /// <summary>
        /// Waits a number of seconds before continuing.
        /// </summary>
        /// <param name="seconds">The wait interval, in seconds.</param>
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