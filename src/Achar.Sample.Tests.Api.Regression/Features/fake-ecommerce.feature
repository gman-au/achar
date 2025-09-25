@DEVICE:API
Feature: Ecommerce API

    Scenario: Invalid path
        Given an API request is created against endpoint "/products/error"
        When the request is sent via "GET"
        Then the request should have failed with status code 404
        And the response with path "error" should have a value of "Not Found"

    Scenario: Invalid method
        Given an API request is created against endpoint "/products"
        When the request is sent via "PUT"
        Then the request should have failed with status code 405
        And the response with path "error" should have a value of "Method not allowed"

    Scenario: Get smartphone product
        Given an API request is created against endpoint "/products/1"
        When the request is sent via "GET"
        Then the request should have succeeded
        And the response with path "price" should have a value of "799.99"
        And the response with path "specs.color" should have a value of "black"

    Scenario: Get earbuds product
        Given an API request is created against endpoint "/products/3"
        When the request is sent via "GET"
        Then the request should have succeeded
        And the response with path "specs.waterproof" should have a value of "true"