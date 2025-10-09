<h1>
ApiInteractionSteps
</h1>
<h3>
<code>Given an API request is created against endpoint "(.*)"</code>
</h3>
Builds a new API request against the API endpoint.
            Ensure that in your appsettings / configuration that an ApiConfigurationOptions
            section is defined with a BaseUrl value.
<table>
<tr><th>Parameter</th><th>Type</th>
</tr>
<tr>
<td>
<code>endpoint</code></td>
<td>
<b>
String
</b>
<br/>The endpoint for this API request. The full URI will be (BaseUrl) + (endpoint).
</td>
</tr>
</table>
<h3>
<code>Given the request header element "(.*)" has value "(.*)"</code>
</h3>
Sets the HTTP header for the current API request to a set value.
<table>
<tr><th>Parameter</th><th>Type</th>
</tr>
<tr>
<td>
<code>headerKey</code></td>
<td>
<b>
String
</b>
<br/>The header key, e.g. "content-type".
</td>
</tr>
<tr>
<td>
<code>headerValue</code></td>
<td>
<b>
String
</b>
<br/>The header value, e.g. "application/json".
</td>
</tr>
</table>
<h3>
<code>Given the request header element "(.*)" has configuration value "(.*)"</code>
</h3>
Sets the HTTP header for the current API request to a configuration value.
<table>
<tr><th>Parameter</th><th>Type</th>
</tr>
<tr>
<td>
<code>headerKey</code></td>
<td>
<b>
String
</b>
<br/>The header key, e.g. "content-type".
</td>
</tr>
<tr>
<td>
<code>configurationReference</code></td>
<td>
<b>
String
</b>
<br/>The configuration path (e.g. in appsettings.json) to retrieve the value e.g. "ApiSettings.DefaultContentType".
</td>
</tr>
</table>
<h3>
<code>Given the request body element "(.*)" has value "(.*)"</code>
</h3>
Sets a value of the request body (JSON only) to a set value.
            If the token path is a nested value e.g. Parent.Child.Something, then the token tree will be created all the way down.
<table>
<tr><th>Parameter</th><th>Type</th>
</tr>
<tr>
<td>
<code>jsonTokenPath</code></td>
<td>
<b>
String
</b>
<br/>The JSON token path e.g. "person.age".
</td>
</tr>
<tr>
<td>
<code>value</code></td>
<td>
<b>
String
</b>
<br/>The value to set the body property e.g. "18".
</td>
</tr>
</table>
<h3>
<code>Given the request body element "(.*)" has configuration value "(.*)"</code>
</h3>
Sets a value of the request body (JSON only) to a configuration value.
            If the token path is a nested value e.g. Parent.Child.Something, then the token tree will be created all the way down.
<table>
<tr><th>Parameter</th><th>Type</th>
</tr>
<tr>
<td>
<code>jsonTokenPath</code></td>
<td>
<b>
String
</b>
<br/>The JSON token path e.g. "person.age".
</td>
</tr>
<tr>
<td>
<code>configurationReference</code></td>
<td>
<b>
String
</b>
<br/>The configuration path (e.g. in appsettings.json) to retrieve the value e.g. "ApiSettings.DefaultPerson.Age".
</td>
</tr>
</table>
<h3>
<code>Given test is skipped</code>
</h3>
Skips the test.
<h3>
<code>When the request is sent via "(.*)"</code>
</h3>
Sends the API request to the configured endpoint via the specified method.
<table>
<tr><th>Parameter</th><th>Type</th>
</tr>
<tr>
<td>
<code>method</code></td>
<td>
<b>
String
</b>
<br/>The HTTP method (i.e. "GET", "POST", "PUT", etc.).
</td>
</tr>
</table>
<h3>
<code>Then the request should have succeeded</code>
</h3>
Checks that the API response is not a HTTP error status.
<h3>
<code>Then the request should have failed</code>
</h3>
Checks that the API response IS a HTTP error status.
<h3>
<code>Then the request should have failed with status code (.*)</code>
</h3>
Checks that the API response IS a HTTP error status, with a specific status code.
<table>
<tr><th>Parameter</th><th>Type</th>
</tr>
<tr>
<td>
<code>expectedStatusCode</code></td>
<td>
<b>
Int32
</b>
<br/>The expected HTTP status code e.g. 404.
</td>
</tr>
</table>
<h3>
<code>Then the response with path "(.*)" should have a value of "(.*)"</code>
</h3>
Checks that a particular (JSON) token path has an expected value as defined.
<table>
<tr><th>Parameter</th><th>Type</th>
</tr>
<tr>
<td>
<code>path</code></td>
<td>
<b>
String
</b>
<br/>The JSON token path e.g. "person.age"
</td>
</tr>
<tr>
<td>
<code>expectedValue</code></td>
<td>
<b>
String
</b>
<br/>The expected value e.g. "18".
</td>
</tr>
</table>
<h1>
InteractionSteps
</h1>
<h3>
<code>Given (.*) seconds have elapsed</code>
</h3>
Waits a number of seconds before continuing.
<table>
<tr><th>Parameter</th><th>Type</th>
</tr>
<tr>
<td>
<code>seconds</code></td>
<td>
<b>
Int32
</b>
<br/>The wait interval, in seconds.
</td>
</tr>
</table>
<h1>
ScreenInteractionSteps
</h1>
<h3>
<code>Given a user has navigated to the home page</code>
</h3>
Navigates to the home / base page URL.
<h3>
<code>Given a user has navigated to the "(.*)" page</code>
</h3>
Navigates to a specific path against the base URL.
            This is not an interaction step per se, instead, the URL is rewritten directly.
<table>
<tr><th>Parameter</th><th>Type</th>
</tr>
<tr>
<td>
<code>path</code></td>
<td>
<b>
String
</b>
<br/>The path relative to the base URL e.g. "/products/10".
</td>
</tr>
</table>
<h3>
<code>Given if present, locates the (.*) with (.*) "(.*)"</code>
</h3>
Attempts to locate a screen element using a defined selector.
            After attempting, silently ignores if the element is not visible.
<table>
<tr><th>Parameter</th><th>Type</th>
</tr>
<tr>
<td>
<code>element</code></td>
<td>
<b>
String
</b>
<br/>The name of the element e.g. "button", "list", "banner". Used only for step clarity.
</td>
</tr>
<tr>
<td>
<code>selector</code></td>
<td>
<b>
String
</b>
<br/>The selector through which the value is passed. Can be any entry from the SelectorMappings dictionary e.g. "id", "text", "title".
</td>
</tr>
<tr>
<td>
<code>value</code></td>
<td>
<b>
String
</b>
<br/>The value of the selector, e.g. "data-test-id-submit-button" or "AgeTextField".
</td>
</tr>
</table>
<h3>
<code>Given locates the (.*) with (.*) "(.*)"</code>
</h3>
Attempts to locate a screen element using a defined selector.
            After attempting, asserts that it is visible and fails if it is not.
<table>
<tr><th>Parameter</th><th>Type</th>
</tr>
<tr>
<td>
<code>element</code></td>
<td>
<b>
String
</b>
<br/>The name of the element e.g. "button", "list", "banner". Used only for step clarity.
</td>
</tr>
<tr>
<td>
<code>selector</code></td>
<td>
<b>
String
</b>
<br/>The selector through which the value is passed. Can be any entry from the SelectorMappings dictionary e.g. "id", "text", "title".
</td>
</tr>
<tr>
<td>
<code>value</code></td>
<td>
<b>
String
</b>
<br/>The value of the selector, e.g. "data-test-id-submit-button" or "AgeTextField".
</td>
</tr>
</table>
<h3>
<code>Given if present, enters "(.*)" into that (.*)</code>
</h3>
Enters a series of characters into a given element, e.g. typing text into a text or number box.
            Silently ignores and aborts the command if the element is not visible.
<table>
<tr><th>Parameter</th><th>Type</th>
</tr>
<tr>
<td>
<code>value</code></td>
<td>
<b>
String
</b>
<br/>The value of the text to be passed to the element.
</td>
</tr>
<tr>
<td>
<code>element</code></td>
<td>
<b>
String
</b>
<br/>The name of the element e.g. "button", "list", "banner". Used only for step clarity.
</td>
</tr>
</table>
<h3>
<code>Given enters "(.*)" into that (.*)</code>
</h3>
Enters a series of characters into a given element, e.g. typing text into a text box.
<table>
<tr><th>Parameter</th><th>Type</th>
</tr>
<tr>
<td>
<code>value</code></td>
<td>
<b>
String
</b>
<br/>The value of the text to be passed to the element.
</td>
</tr>
<tr>
<td>
<code>element</code></td>
<td>
<b>
String
</b>
<br/>The name of the element e.g. "button", "list", "banner". Used only for step clarity.
</td>
</tr>
</table>
<h3>
<code>Given if present, clicks on that (.*)</code>
</h3>
Sends a 'press' or 'click' event to the screen element.
            Silently ignores and aborts the command if the element is not visible or clickable.
<table>
<tr><th>Parameter</th><th>Type</th>
</tr>
<tr>
<td>
<code>element</code></td>
<td>
<b>
String
</b>
<br/>The name of the element e.g. "button", "list", "banner". Used only for step clarity.
</td>
</tr>
</table>
<h3>
<code>Given clicks on that (.*)</code>
</h3>
Sends a 'press' or 'click' event to the screen element.
            Asserts that it is clickable and fails if it is not.
<table>
<tr><th>Parameter</th><th>Type</th>
</tr>
<tr>
<td>
<code>element</code></td>
<td>
<b>
String
</b>
<br/>The name of the element e.g. "button", "list", "banner". Used only for step clarity.
</td>
</tr>
</table>
<h3>
<code>Given scrolls the (.*) with (.*) "(.*)" into view</code>
</h3>
Attempts to locate a screen element using a defined selector, scrolling the screen downwards if required.
            After attempting, asserts that it is visible and fails if it is not.
<table>
<tr><th>Parameter</th><th>Type</th>
</tr>
<tr>
<td>
<code>element</code></td>
<td>
<b>
String
</b>
<br/>The name of the element e.g. "button", "list", "banner". Used only for step clarity.
</td>
</tr>
<tr>
<td>
<code>selector</code></td>
<td>
<b>
String
</b>
<br/>The selector through which the value is passed. Can be any entry from the SelectorMappings dictionary e.g. "id", "text", "title".
</td>
</tr>
<tr>
<td>
<code>value</code></td>
<td>
<b>
String
</b>
<br/>The value of the selector, e.g. "data-test-id-submit-button" or "AgeTextField".
</td>
</tr>
</table>
<h3>
<code>Given flings down (.*)</code>
</h3>
Performs a 'fling' action in the direction as specified.
<table>
<tr><th>Parameter</th><th>Type</th>
</tr>
<tr>
<td>
<code>y</code></td>
<td>
<b>
Int32
</b>
<br/>The vertical fling amount, in screen units.
</td>
</tr>
</table>
<h3>
<code>Given if present, waits for (.*) with (.*) "(.*)" to appear</code>
</h3>
Attempts to locate a screen element using a defined selector, scrolling the screen downwards if required.
            Silently ignores and aborts the command if the element is not visible or clickable after the full timeout period.
<table>
<tr><th>Parameter</th><th>Type</th>
</tr>
<tr>
<td>
<code>element</code></td>
<td>
<b>
String
</b>
<br/>The name of the element e.g. "button", "list", "banner". Used only for step clarity.
</td>
</tr>
<tr>
<td>
<code>selector</code></td>
<td>
<b>
String
</b>
<br/>The selector through which the value is passed. Can be any entry from the SelectorMappings dictionary e.g. "id", "text", "title".
</td>
</tr>
<tr>
<td>
<code>value</code></td>
<td>
<b>
String
</b>
<br/>The value of the selector, e.g. "data-test-id-submit-button" or "AgeTextField".
</td>
</tr>
</table>
<h3>
<code>Given waits for (.*) with (.*) "(.*)" to appear</code>
</h3>
Attempts to locate a screen element using a defined selector, waiting the full timeout period if required.
            After attempting, asserts that it is visible and fails if it is not.
<table>
<tr><th>Parameter</th><th>Type</th>
</tr>
<tr>
<td>
<code>element</code></td>
<td>
<b>
String
</b>
<br/>The name of the element e.g. "button", "list", "banner". Used only for step clarity.
</td>
</tr>
<tr>
<td>
<code>selector</code></td>
<td>
<b>
String
</b>
<br/>The selector through which the value is passed. Can be any entry from the SelectorMappings dictionary e.g. "id", "text", "title".
</td>
</tr>
<tr>
<td>
<code>value</code></td>
<td>
<b>
String
</b>
<br/>The value of the selector, e.g. "data-test-id-submit-button" or "AgeTextField".
</td>
</tr>
</table>
<h3>
<code>Given finds the (.*) (.*) with (.*) "(.*)"</code>
</h3>
Attempts to locate the (nth) screen element using a defined selector.
            After attempting, asserts that it is visible and fails if it is not.
<table>
<tr><th>Parameter</th><th>Type</th>
</tr>
<tr>
<td>
<code>nth</code></td>
<td>
<b>
String
</b>
<br/>The occurrence of the element you wish to find. The command will understand any value with a number e.g. "5th", "14th", "2002nd".
</td>
</tr>
<tr>
<td>
<code>element</code></td>
<td>
<b>
String
</b>
<br/>The name of the element e.g. "button", "list", "banner". Used only for step clarity.
</td>
</tr>
<tr>
<td>
<code>selector</code></td>
<td>
<b>
String
</b>
<br/>The selector through which the value is passed. Can be any entry from the SelectorMappings dictionary e.g. "id", "text", "title".
</td>
</tr>
<tr>
<td>
<code>value</code></td>
<td>
<b>
String
</b>
<br/>The value of the selector, e.g. "data-test-id-submit-button" or "AgeTextField".
</td>
</tr>
</table>
<h3>
<code>Given waits (.*) seconds</code>
</h3>
Waits a number of seconds before continuing.
<table>
<tr><th>Parameter</th><th>Type</th>
</tr>
<tr>
<td>
<code>seconds</code></td>
<td>
<b>
Int32
</b>
<br/>The wait interval, in seconds.
</td>
</tr>
</table>
<h3>
<code>Then the (.*) should not be visible</code>
</h3>
Checks that the (last located) screen element is not visible.
<table>
<tr><th>Parameter</th><th>Type</th>
</tr>
<tr>
<td>
<code>element</code></td>
<td>
<b>
String
</b>
<br/>The name of the element e.g. "button", "list", "banner". Used only for step clarity.
</td>
</tr>
</table>
<h3>
<code>Then the (.*) should be visible</code>
</h3>
Checks that the (last located) screen element is visible.
<table>
<tr><th>Parameter</th><th>Type</th>
</tr>
<tr>
<td>
<code>element</code></td>
<td>
<b>
String
</b>
<br/>The name of the element e.g. "button", "list", "banner". Used only for step clarity.
</td>
</tr>
</table>
<h3>
<code>Then the (.*) should not be clickable</code>
</h3>
Checks that the (last located) screen element is not clickable.
<table>
<tr><th>Parameter</th><th>Type</th>
</tr>
<tr>
<td>
<code>element</code></td>
<td>
<b>
String
</b>
<br/>The name of the element e.g. "button", "list", "banner". Used only for step clarity.
</td>
</tr>
</table>
<h3>
<code>Then the (.*) should be clickable</code>
</h3>
Checks that the (last located) screen element is clickable.
<table>
<tr><th>Parameter</th><th>Type</th>
</tr>
<tr>
<td>
<code>element</code></td>
<td>
<b>
String
</b>
<br/>The name of the element e.g. "button", "list", "banner". Used only for step clarity.
</td>
</tr>
</table>
