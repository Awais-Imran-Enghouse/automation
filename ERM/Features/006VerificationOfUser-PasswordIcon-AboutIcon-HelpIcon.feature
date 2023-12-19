@006VerificationOfUser-PasswordIcon-AboutIcon-HelpIcon
Feature: 006VerificationOfUser-PasswordIcon-AboutIcon-HelpIcon
ANF
A short summary of the feature

@DeletingAgent
Scenario: 001 Verification of logged-in username, About Icon and Help Icon .
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
	#performing main scenario
	Given I am at the Web Client login page.
	When When I enter username.
	And I click on OK button on webclient login page.
	And I click on OK button again on webclient login page.
	Then The name of agent should be same as username.
	When I click on About Icon.
	Then I get the version of voxtron.
	When I close the pop up.
	And I click on the help icon.
	Then A new tab is opened up and link includes 'vcc.bel.rd.eilab.biz/VccWebCenter/Files/Help/en/frames_client.html'.
	
@DeletingAgent
Scenario: 002 Checking the changing Password feature.
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

	#Configuring Security
	Given I am at VCC login page.
	When I click on CCSupport.
	And I click on the Configuration.
	And I click on the security.
	And I click on the URL.
	And I enter the URL of Webcenter.
	And I click on the Ok button of Config-Security Page.
	Then I get a message that changes are successfully saved.
	
	#changing password.
	Given I am at the Web Client login page.
	When When I enter username.
	And I click on OK button on webclient login page.
	And I click on OK button again on webclient login page.
	Then I get logged in web client.
	When I click on the change password Icon.
	Then I shifted to the change password page.
	When I enter username.
	And I enter New Password.
	And I enter Confirm Password.
	And I click on the Ok button to change password.
	Then I get pop up with message 'Password successfully changed.'.

	#logging in with password.
	Given I am at the Web Client login page.
	When When I enter username.
	And I enter password in Webclient login page.
	And I click on OK button on webclient login page.
	And I click on OK button again on webclient login page.
	Then I get logged in web client.



 
