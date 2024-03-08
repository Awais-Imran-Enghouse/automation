
@005QueueSelectionAndConfig
Feature: 005QueueSelectionAndConfig

A short summary of the feature

@DeletingQueues @DeletingAgent
Scenario: Creating queues, configuring them and then ensuring their presence at Web Client login page
	Given I am at VCC login page.
	When I enter credentials.
	Then I get logged in.
	When I click on CCSupport.
	When I click on Queue module.
	When I clock on Add New Queue button.
	When I enter 'Dummy Queue1'.
	When I click on the profiles tab.
	When I check on the Voxtron Agent checkbox.
	When I click on the Ok button. 


	Given I am at VCC login page.
	When I click on CCSupport.
	When I click on Queue module.
	When I clock on Add New Queue button.
	When I enter 'Dummy Queue2'.
	When I click on the profiles tab.
	When I check on the Voxtron Agent checkbox.
	When I click on the Ok button. 


	Given I am at VCC login page.
	When I click on CCSupport.
	And I click on the User module.
	And I click on add user button.
	And I enter Username.
	And I enter Email Address.
	And I click on the profile tab.
	And I click the OK button on the profile tab.
	Then The agent is successfully created.
	When I click on the edit button of the agent we created.
	And I click on the Queue Tab.
	And I check the selected option.
	And I check the change option for Dummy Queue2
	And I click on the Ok button of Queue page.

	Given I am at the Web Client login page.
	When When I enter username.
	And I click on OK button on webclient login page.
	And I get the selected queue as well as changed queue.