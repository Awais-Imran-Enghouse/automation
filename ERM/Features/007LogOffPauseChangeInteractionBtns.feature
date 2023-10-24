Feature: 007LogOffPauseChangeInteractionBtns

A short summary of the feature

@DeletingQueues @DeletingAgent
Scenario: 001 Verification of Log Off button and pause button.
	
	# creating ist queu:
	Given I am at VCC login page.
	When I enter credentials.
	Then I get logged in.
	When I click on CCSupport.
	When I click on Queue module.
	When I clock on Add New Queue button.
	When I enter 'Dummy Queue1'.
	#When I check the Default checkbox.
	When I click on the profiles tab.
	When I check on the Voxtron Agent checkbox.
	When I click on the Ok button. 

	##creating second queue:
	Given I am at VCC login page.
	#When I enter credentials.
	#Then I get logged in.
	When I click on CCSupport.
	When I click on Queue module.
	When I clock on Add New Queue button.
	When I enter 'Dummy Queue2'.
	When I click on the profiles tab.
	When I check on the Voxtron Agent checkbox.
	When I click on the Ok button. 
	
	#3:Creation of agent and assigment of queus.
	Given I am at VCC login page.
	When I click on CCSupport.
	And I click on the User module.
	When I click on add user button.
	When I enter Username.
	And I enter Email Address.
	And I click on the profile tab.
	And I click the OK button on the profile tab.
	Then The agent is successfully created.
	When I click on the edit button of the agent we created.
	When I click on the Queue Tab.
	And I check the change option for Dummy Queue2
	And I check the change option for Dummy Queue1
	And I click on the Ok button of Queue page.
	
#	#Allowing logoff for queue 1.

	When I click on Queue module.
	And I click on the edit button of 'Dummy Queue1'.
	And I click on the Agent Settings.
	And I check the Logging out of last agent.
	And I check the Pause of last agent.
	And I click on the Ok button of Agent Setting tab.
	
#	
#	#logging into web client for Dummy queue1 which is given last agent logout functionality.
	Given I am at the Web Client login page.
	When When I enter username.
	And I click on OK button on webclient login page.
	##to code
	And I checked 'Dummy Queue1'.
#	#
	And I click on OK button again on webclient login page.
	Then I get logged in web client.
	##to code
	When I click the Pause button.
	Then It is successfully paused.
	When I click on the logoff button.
	Then I get logged off. 
	#

	#logging into web client for Dummy Agent2, which is not given last agent logout functionality.
	Given I am at the Web Client login page.
	When When I enter username.
	And I click on OK button on webclient login page.
	And I checked 'Dummy Queue2'.
	And I click on OK button again on webclient login page.
	Then I get logged in web client.
	And The pause button is disabled.
#	And The log off button is also disabled.
#
#	
#	#checking Change Interaction button
	Given I am at the Web Client login page.
	When When I enter username.
	And I click on OK button on webclient login page.
	And I click on OK button again on webclient login page.
	Then I get logged in web client.
	When I click on Change Interaction button.
	And I unchecked 'Dummy Queue1' on Change Interaction popup.
	And I click on the ok button of Change Interaction pop up.
	And I click on Change Interaction button.
	And I unchecked 'Dummy Queue2' on Change Interaction popup.
	And I click on the ok button of Change Interaction pop up.
	Then I get the warning message.

	
