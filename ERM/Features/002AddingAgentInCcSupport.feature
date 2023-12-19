@002AddingAgentInCcSupport
Feature: 002AddingAgentInCcSupport

A short summary of the feature

@DeletingAgent
Scenario: Adding user in CCSupport.
	Given I am at VCC login page.
	When I enter credentials.
	Then I get logged in.
	When I click on CCSupport.
	And I click on the User module.
	When I click on add user button.
	When I enter Username.
	And I enter Email Address.
	And I click on the profile tab.
	And I click the OK button on the profile tab.
	Then The agent is successfully created.
	
