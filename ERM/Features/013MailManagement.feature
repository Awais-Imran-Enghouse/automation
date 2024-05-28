@MailManagement
Feature: 013MailManagement

A short summary of the feature

@tag1
Scenario: 001 Mail Box has 16 folders in it.
	Given I am at VCC login page.
	When I enter credentials.
	Then I get logged in.
	When I click the ERMSupport.
	And I click the MailBox Management.
	And I click the desired mail box and 16 folders will appear.

Scenario: 002 Number of emails in Waiting folder.
	Given I am at VCC login page.
	When I enter credentials.
	Then I get logged in.
	When I click the ERMSupport.
	And I click the MailBox Management.
	And I click the desired mail box and 16 folders will appear.
	And I noted the number of emails present in Waiting folder.
	Given I send email from customer to client.
	Then I noticed that toal number of emails in Waiting folder is increased by 1.

Scenario: 003 Searching email using the Filter input bar, verifying the searched result and finding that query under the Search Query list.
	Given I am at VCC login page.
	When I enter credentials.
	Then I get logged in.
	When I click the ERMSupport.
	And I click the MailBox Management.
	And I search 'subject = "queue"' in Filter input bar.
	And I find that the first searched email has 'queue' in its subject
	#And I found the searched query in the Search Query list.


Scenario: 004 Total 10 queries can be added in the Search Query list.
	Given I am at VCC login page.
	When I enter credentials.
	Then I get logged in.
	When I click the ERMSupport.
	And I click the MailBox Management.
	And I search 'subject = "queue"' in Filter input bar for 11 times.
	And I find that there are total 10 queries in the list.

Scenario: 005 Pinned query will not be removed even when overflowing.
	Given I am at VCC login page.
	When I enter credentials.
	Then I get logged in.
	When I click the ERMSupport.
	And I click the MailBox Management.
	And I search 'subject = "queue"' in Filter input bar.
	And I pinned one of the queries.
	And I search 'subject = "queue"' in Filter input bar for 11 times.
	And I find that the pinned query is not removed.
	And I find that there are total 10 queries in the list.

	#keep it on pending untill the issue resolved
Scenario: 007 Moving email from waiting folder to other folders.
	Given I am at VCC login page.
	When I enter credentials.
	Then I get logged in.
	When I click the ERMSupport.
	And I click the MailBox Management.
	And I click on the Waiting folder.
	And I right click on the email.
	And I hover over and move to handled/deleted/span folder.
	And I check in the handled/deleted/span folder that moved email is in the folder.

Scenario: 006 Moving the next coming email to New folder using Routing Rules.
	##assigning Routing Rules to queue
	Given I am at VCC login page.
	When I click the ERMSupport.
	And I click on the mailboxes.
	#And I click on the edit button of "Support".
	And I click on the edit button of mailbox.
	And I click on the Routing Routes.
	And I click on the Add New Rules button.
	And I enter the name of queue with a new name.
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
	And I select Move to Folder in Select Action drop down.
	And I select new in Folder drop down.
	And I click the ok button of Add Action window of Add New Rule pop up.
	And I click the Update button of Add New Rule pop up.
	Given I send email from customer to client.
	And I find the sent email in the new folder.
	