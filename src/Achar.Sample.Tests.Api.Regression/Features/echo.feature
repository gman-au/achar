@DEVICE:API
Feature: Echo API (https://echo.zuplo.io)

    @TEST_PRODUCT
    Scenario: Set nested Post data
        Given test is skipped
        Given an API request is created against endpoint ""
        And the request body element "sub-body.child.age" has value "32"
        And the request body element "sub-body.child.height" has value "175"
        And the request body element "sub-body.parent.age" has value "65"
        When the request is sent via "POST"
        Then the request should have succeeded
        And the response with path "body.sub-body.child.age" should have a value of "32"