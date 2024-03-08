@008WaitingMonitorActivityMonitor
Feature: 008WaitingMonitorActivityMonitor

A short summary of the feature

@DeletingAgent
Scenario: 001 Verification of Activity Monitor feature.
	#1:Creation of agent and assigment of queus.
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
	When I click on the edit button of the agent we created.
	And I click the permission tab.
	And I check the Enable activity monitor.
	And I click the OK button on permission tab.
	Given I am at the Web Client login page.
	When When I enter username.
	And I click on OK button on webclient login page.
	And I click on OK button again on webclient login page.
	Then I get logged in web client.
	When I click on the Activity Monitor button in webclient.
	And I close the Activity Monitor tab.

@DeletingAgent
Scenario: 002 Verification of Waiting Monitor feature.
	#1:Creation of agent and assigment of queus.
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
	When I click on the edit button of the agent we created.
	And I click the permission tab.
	And I check the Enable waiting monitor.
	And I click the OK button on permission tab.
	Given I am at the Web Client login page.
	When When I enter username.
	And I click on OK button on webclient login page.
	And I click on OK button again on webclient login page.
	Then I get logged in web client.
	When I click on the Waiting Monitor button.
	And I close the Waiting Monitor tab.

	


