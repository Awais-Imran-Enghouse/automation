@001_loginCcSupport
Feature: 001_loginCcSupport

A short summary of the feature


Scenario: Login to VCC application
	Given I am at VCC login page.
	When I enter credentials.
	Then I get logged in.

Scenario: Login with wrong credentials
	Given I am at VCC login page.
	When I enter wrong credentials.
	Then I get 'Error' message.

