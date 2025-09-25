@DEVICE:API
Feature: My test

    Scenario: happy path
        Given an API request is created against endpoint "/lorem/50"
        When the request is sent via "GET"
        Then the request should have succeeded

    Scenario: endpoint not found
        Given an API request is created against endpoint "/notfound"
        When the request is sent via "GET"
        Then the request should have failed with status code 404