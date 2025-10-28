@DEVICE:Web
Feature: Basic web interactive (https://baconipsum.com/)

    @TEST_WEB_SITE
    Scenario: Play with site and interact
        Given a user has navigated to the home page
        And locates the button with value "Give Me Bacon"
        And clicks on that button
        And waits for radiobox with text "Meat and Filler" to appear
        And clicks on that radiobox
        And locates the textbox with name "paras"
        And enters "10" into that textbox
        And locates the button with value "Give Me Bacon"
        And clicks on that button
        And waits for link with text "Proudly powered by WordPress." to appear
        Then the link should be clickable