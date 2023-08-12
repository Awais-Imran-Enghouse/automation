using ConsoleApp1;
using ERM.supportClasses;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace ERM.StepDefinitions
{
    [Binding]
    public class _006VerificationOfUser_PasswordIcon_AboutIcon_HelpIconStepDefinitions
    {
        loginPageObjects loginObjects = new loginPageObjects();
        HomePageObjects homePageObjects = new HomePageObjects();
        CCSuportModuleObjects ccSupportModuleObject = new CCSuportModuleObjects();
        WebClientLoginPageObjects webClientLoginPageObjects = new WebClientLoginPageObjects();
        ApplicationFixtures applicationFixtures = new ApplicationFixtures();

        IWebDriver driver;
        public _006VerificationOfUser_PasswordIcon_AboutIcon_HelpIconStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;

        }
        [Then(@"The name of agent should be same as username\.")]
        public void ThenTheNameOfAgentShouldBeSameToUsername_()
        {   
            seleniumSetMethod.ExplicitWait(element: webClientLoginPageObjects.WebClientAgentNameXpath, elementType: ProperType.X_Path, driver: driver);
            Thread.Sleep(3000);
            string agent_name = seleniumSetMethod.GetText(element: webClientLoginPageObjects.WebClientAgentNameXpath, elementType: ProperType.X_Path, driver: driver);
            Console.WriteLine("The name of agent is : " + agent_name);
            agent_name.Contains(ccSupportModuleObject.Username);
            Assert.IsTrue(agent_name.Contains(ccSupportModuleObject.Username));
            
        }

        [When(@"I click on About Icon\.")]
        public void WhenIClickOnAboutIcon_()
        {
            seleniumSetMethod.Click(element:webClientLoginPageObjects.WebClientAboutId,elementType:ProperType.Id, driver:driver);
        }

        [Then(@"I get the version of voxtron\.")]
        public void ThenIGetTheVersionOfVoxtron_()
        {
           string version =  seleniumSetMethod.GetText(element:webClientLoginPageObjects.VersionId, elementType:ProperType.Id, driver:driver);
            Console.WriteLine(version);
        }
        [When(@"I close the pop up\.")]
        public void WhenICloseThePopUp_()
        {
            seleniumSetMethod.Click(element: webClientLoginPageObjects.AboutPopupCloseXpath, elementType: ProperType.X_Path, driver: driver);
        }


        [When(@"I click on the help icon\.")]
        public void WhenIClickOnTheHelpIcon_()
        {
            seleniumSetMethod.Click(element: webClientLoginPageObjects.WebClientHelpId, elementType: ProperType.Id, driver: driver);
        }

        [Then(@"A new tab is opened up and link includes '([^']*)'\.")]
        public void ThenANewTabIsOpenedUpAndLinkIncludes_(string p0)
        {
            Thread.Sleep(10000);
            //string url = driver.CurrentWindowHandle.ToString();
            driver.SwitchTo().Window(driver.WindowHandles[0]).Close(); // close the tab
            Thread.Sleep(10000);
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            string url = driver.Url;
            Console.WriteLine(url);
            Assert.IsTrue(url.Contains(p0));
        }

        [When(@"I click on the Configuration\.")]
        public void WhenIClockOnTheConfiguration_()
        {
            Thread.Sleep(3000);
            seleniumSetMethod.Click(element:ccSupportModuleObject.ConfigurationId, elementType: ProperType.Id, driver: driver);
        }

        [When(@"I click on the security\.")]
        public void WhenIClickOnTheSecurity_()
        {
            Thread.Sleep(3000);
            seleniumSetMethod.Click(element: ccSupportModuleObject.SecurityId, elementType: ProperType.Id, driver: driver);
        }

        [When(@"I click on the URL\.")]
        public void WhenIClickOnTheURL_()
        {
            Thread.Sleep(3000);
            seleniumSetMethod.Click(element: ccSupportModuleObject.ConfigSecurityUrlId, elementType:ProperType.Id, driver: driver);
        }

        [When(@"I enter the URL of Webcenter\.")]
        public void WhenIEnterTheURLOfWebcenter_()
        {
            Thread.Sleep(3000);
            seleniumSetMethod.EnterText(element: ccSupportModuleObject.ChangePwInputId, elementType: ProperType.Id,value:loginObjects.url ,driver: driver);
        }

        [When(@"I click on the Ok button of Config-Security Page\.")]
        public void WhenIClickOnTheOkButtonOfConfig_SecurityPage_()
        {

            Thread.Sleep(3000);
            seleniumSetMethod.Click(element: ccSupportModuleObject.ConfigSecurityOkBtnId, elementType: ProperType.Id, driver: driver);
        }

        [Then(@"I get a message that changes are successfully saved\.")]
        public void ThenIGetAMessageThatChangesAreSuccessfullySaved_()
        {
            Thread.Sleep(3000);
            //seleniumSetMethod.ExplicitWait(element:ccSupportModuleObject.PwSuccessTextXpath, elementType:ProperType.Id,driver:driver);
            string success_text = seleniumSetMethod.GetText(element:ccSupportModuleObject.PwSuccessTextXpath, elementType:ProperType.X_Path, driver: driver);
           Console.WriteLine(success_text);
        }

        [When(@"I click on the change password Icon\.")]
        public void WhenIClickOnTheChangePasswordIcon_()
        {
            seleniumSetMethod.ExplicitWait(element: webClientLoginPageObjects.ChangePWIconId, elementType: ProperType.Id, driver: driver);
            Thread.Sleep(3000);
            seleniumSetMethod.Click(element: webClientLoginPageObjects.ChangePWIconId, elementType: ProperType.Id, driver: driver);

        }

        [Then(@"I shifted to the change password page\.")]
        public void ThenIShiftedToTheChangePasswordPage_()
        {
            Thread.Sleep(3000);
            driver.SwitchTo().Window(driver.WindowHandles[0]).Close();
            //driver.Title();
            Thread.Sleep(5000);
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            string url = driver.Url;
            Console.WriteLine(url);
        }

        [When(@"I enter username\.")]
        public void WhenIEnterUsername_()
        {
            seleniumSetMethod.ExplicitWait(element: webClientLoginPageObjects.ChangePWUsernameId, elementType: ProperType.Id, driver: driver);
            Thread.Sleep(5000);
            seleniumSetMethod.EnterText(element: webClientLoginPageObjects.ChangePWUsernameId, elementType: ProperType.Id, value: ccSupportModuleObject.Username, driver: driver);
        }

        [When(@"I enter New Password\.")]
        public void WhenIEnterNewPassword_()
        {
            seleniumSetMethod.ExplicitWait(element: webClientLoginPageObjects.NewPwId, elementType: ProperType.Id, driver: driver);
            Thread.Sleep(3000);
            seleniumSetMethod.EnterText(element: webClientLoginPageObjects.NewPwId, elementType: ProperType.Id, value: webClientLoginPageObjects.NewPW, driver: driver);

        }

        [When(@"I enter Confirm Password\.")]
        public void WhenIEnterConfirmPassword_()
        {
            seleniumSetMethod.ExplicitWait(element: webClientLoginPageObjects.ConfirmPwId, elementType: ProperType.Id, driver: driver);
            Thread.Sleep(3000);
            seleniumSetMethod.EnterText(element: webClientLoginPageObjects.ConfirmPwId, elementType: ProperType.Id, value: webClientLoginPageObjects.NewPW, driver: driver);

        }

        [When(@"I click on the Ok button to change password\.")]
        public void WhenIClickOnTheOkButtonToChangePassword_()
        {
            seleniumSetMethod.ExplicitWait(element: webClientLoginPageObjects.ChangePWPageOkBtnId, elementType: ProperType.Id, driver: driver);
            Thread.Sleep(3000);
            seleniumSetMethod.Click(element: webClientLoginPageObjects.ChangePWPageOkBtnId, elementType: ProperType.Id, driver: driver);

        }

        [Then(@"I get pop up with message '([^']*)'\.")]
        public void ThenIGetPopUpWithMessage_(string p0)
        {
            //seleniumSetMethod.ExplicitWait(element: webClientLoginPageObjects.ChangePwSuccessMsgId, elementType: ProperType.X_Path, driver: driver);
            Thread.Sleep(3000);
            string SucessMsg = seleniumSetMethod.GetText(element: webClientLoginPageObjects.ChangePwSuccessMsgId, elementType: ProperType.Id, driver: driver);
            Console.WriteLine("The name of agent is : " + SucessMsg);

        }

        [When(@"I enter password in Webclient login page\.")]
        public void WhenIEnterPasswordInWebclientLoginPage_()
        {
            seleniumSetMethod.EnterText(element: webClientLoginPageObjects.PasswordId, elementType: ProperType.Id, value: webClientLoginPageObjects.NewPW, driver: driver);
        }




    }
}
