@003LoginWebClient
Feature: 003LoginWebClient

A short summary of the feature


Scenario: Adding user in CCSupport.
	Given I am at VCC login page.
	When I enter credentials.
	Then I get logged in.
	When I click on CCSupport.
	When I click on add user button.
	When I enter Username.
	And I enter Email Address.
	And I click on the profile tab.
	And I click the OK button on the profile tab.
	Then The agent is successfully created.


#@DeletingAgent
Scenario: Login to the Web client with correct credentials
	Given I am at the Web Client login page.
	When When I enter username.
	And I click on OK button on webclient login page.
	And I click on OK button again on webclient login page.
	Then I get logged in web client.


Scenario: Login to the Web client with wrong credentials
	Given I am at the Web Client login page.
	When When I enter "wrong username".
	And I click on OK button on webclient login page.
	Then I get text "Error".