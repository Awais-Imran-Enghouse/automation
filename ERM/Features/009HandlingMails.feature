Feature: 009HandlingMails

A short summary of the feature

@tag1
Scenario: 001 Verification of Sending and Receiving Emails.
	#adding agent
	Given I am at VCC login page.
	When I enter credentials.
	Then I get logged in.
	When I click on CCSupport.
	When I click on add user button.
	When I enter Username.
	And I enter Email Address.
	And I click on the profile tab.
	And I click the OK button.
	Then The agent is successfully created.
	#adding queue
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
	#......
	Given I am at VCC login page.
	When I enter credentials.
	Then I get logged in.
	When I click on CCSupport.
	When I click on Queue module.
	When I clock on Add New Queue button.
	When I enter 'Dummy Queue2'.
	When I click on the profiles tab.
	When I check on the Voxtron Agent checkbox.
	When I click on the Ok button. 
	#assigning Routing Rules to queue
	Given I am at VCC login page.
	When I click the ERMSupport.
	And I click on the mailboxes.
	And I click on the edit button of support.
	And I click on the Routing Routes.
	And I click on the Add New Rules button.
	And I enter the name of queue.
	And I click the Next button of Add New Rule pop up.
	And I check Apply New Emails.
	And I click the Next button of Add New Rule pop up.
	And I click on the Add Condition.
	And I select subject in first drop down.
	And I select contains in second drop down.
	And I enter "queue2" in the input bar.
	And I click the ok button of Add New Rule pop up.
	And I click the Next button of Add New Rule pop up.
	And I click add action button.
	And I select Assign to queue in Select Action drop down.
	And I select Dummy Queue2 in Queue drop down.
	And I click the ok button of Add New Rule pop up.
	And I click the Update button of Add New Rule pop up.
	#assigning skills to Agent.
	Given I am at VCC login page.
	When I click on CCSupport.
	And I click on the edit button of the agent we created.
	And I click on the Skills Tab.
	And I ckeck the Support check box.
	And I click on the Queue Tab.
	And I check the change option for other queue
	
	#sending emails
	#receiving email
