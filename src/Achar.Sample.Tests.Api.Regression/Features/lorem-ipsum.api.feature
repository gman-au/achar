@DEVICE:API
Feature: Lorem Ipsum API

    @TEST_WORDS
    Scenario: Get 50 words
        Given an API request is created against endpoint "/lorem/50"
        When the request is sent via "GET"
        Then the request should have succeeded

    @TEST_ERROR
    Scenario: Invalid endpoint
        Given an API request is created against endpoint "/notfound"
        When the request is sent via "GET"
        Then the request should have failed with status code 404