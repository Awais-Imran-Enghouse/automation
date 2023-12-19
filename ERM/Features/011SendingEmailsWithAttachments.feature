@011SendingEmailsWithAttachments  
Feature: 011SendingEmailsWithAttachments

A short summary of the feature

@DeletingRoutingRules @DeletingQueues @DeletingAgent
Scenario: 001 Sending emails with attachments.
#	

#	#adding queue
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

	#adding second queue
	Given I am at VCC login page.
	When I click on CCSupport.
	When I click on Queue module.
	When I clock on Add New Queue button.
	When I enter 'Dummy Queue2'.
	When I click on the profiles tab.
	When I check on the Voxtron Agent checkbox.
	When I click on the Ok button. 

	#1:Creation of agent and assigment of queus.
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
	And I click the permission tab.
	And I check the Enable activity monitor.
	And I check the Enable waiting monitor.
	And I click the OK button on permission tab.
	

	##assigning Routing Rules to queue
	Given I am at VCC login page.
	When I click the ERMSupport.
	And I click on the mailboxes.
	And I click on the edit button of "Support".
	And I click on the Routing Routes.
	And I click on the Add New Rules button.
	And I enter the name of queue.
	And I click the Next button of Add New Rule pop up.
	And I check Apply New Emails.
	And I click the Next button of folder window of pop up.
	And I click on the Add Condition.
	And I select subject in first drop down.
	And I select contains in second drop down.
	And I enter "queue2" in the input bar.
	And I click the ok button of Add Condition page of Add New Rule pop up.
	And I click the Next button on Condition window of Add New Rule pop up.
	And I click add action button.
	And I select Assign to queue in Select Action drop down.
	And I select Dummy Queue2 in Queue drop down.
	And I click the ok button of Add Action window of Add New Rule pop up.
	And I click the Update button of Add New Rule pop up.
#	
	##assigning skills to Agent.
	Given I am at VCC login page.
	When I click on CCSupport.
	And I click on the User module.
	And I click on the edit button of the agent we created.
	And I click on the Skills Tab.
	And I ckeck the Support check box.
	And I click on the Queue Tab.
	And I check the 'selected' option for 'Q2' for Inbound e-mails.
	And I check the change option for Dummy Queue2
	And I check the change option for Dummy Queue1
	And I click on the profile tab.
	And I check the Voxtron Agent radio button.
	And I click the OK button on the profile tab.
##
##	#sending emails
	Given I send email from 'customer@voxtron.lab' to 'support@voxtron.lab' with attachment.
#	
	#logging in to webclient
	Given I am at the Web Client login page.
	When When I enter username.
	And I click on OK button on webclient login page.
	When I checked 'Dummy Queue2'.
	And I click on OK button again on webclient login page.
	Then I click the Accept button.
	And I ensure that email has attachment with it.
	And I click on the Delete button.
	And I enter comments 'Email has been deleted' in the Remarks input bar.
	And I click on commit button to del the email.