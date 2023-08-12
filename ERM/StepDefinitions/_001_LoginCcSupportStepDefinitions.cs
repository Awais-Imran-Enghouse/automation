using ConsoleApp1;
using ERM.supportClasses;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace ERM.StepDefinitions
{
    [Binding]
    public class _001_LoginCcSupportStepDefinitions
    {
        loginPageObjects loginObjects = new loginPageObjects();
        HomePageObjects homePageObjects = new HomePageObjects();
        CCSuportModuleObjects ccSupportModuleObject = new CCSuportModuleObjects();

        IWebDriver driver;

        public _001_LoginCcSupportStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;

        }

        // Scenario #1 
        [Given(@"I am at VCC login page\.")]
        public void GivenIAmAtVCCLoginPage_()
        {
            try
            {
                driver.Navigate().GoToUrl(loginObjects.url);
                Console.WriteLine("Open Url");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }



        [When(@"I enter credentials\.")]
        public void WhenIEnterCredentials_()
        {
            Thread.Sleep(5000);

            try
            {   //wait for the element to be loaded
                seleniumSetMethod.ExplicitWait(element: loginObjects.UsernameInputbarId, elementType: ProperType.Id, driver: driver);
                //further automation process
                seleniumSetMethod.EnterText(element: loginObjects.UsernameInputbarId, elementType: ProperType.Id, value: loginObjects.Username, driver: driver);
                seleniumSetMethod.EnterText(element: loginObjects.PasswordInputbarId, elementType: ProperType.Id, value: loginObjects.Password, driver: driver);
                seleniumSetMethod.Click(element: loginObjects.SubmitButtonXpath, elementType: ProperType.X_Path, driver: driver);
                Console.WriteLine(" 2ND  is DONE : ");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }




        [Then(@"I get logged in\.")]
        public void ThenIGetLoggedIn_()
        {
            try
            {
                string username = "no name";
                //Thread.Sleep(10000);
                seleniumSetMethod.ExplicitWait(element: homePageObjects.UsernameId, elementType: ProperType.Id, driver: driver);
                username = seleniumSetMethod.GetText(element: homePageObjects.UsernameId, elementType: ProperType.Id, driver: driver);

                Console.WriteLine(" Username is  : " + username + ". Expected :" + homePageObjects.UsernameToBe);
                // "Super Admin"
                Assert.AreEqual(homePageObjects.UsernameToBe, username);
                //Assert.AreEqual("super", username);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }

        //ScenarioBlock #2
        [When(@"I enter wrong credentials\.")]
        public void WhenIEnterWrongCredentials_()
        {
            try
            {   //wait for the element to be loaded
                seleniumSetMethod.ExplicitWait(element: loginObjects.UsernameInputbarId, elementType: ProperType.Id, driver: driver);
                //further automation process
                seleniumSetMethod.EnterText(element: loginObjects.UsernameInputbarId, elementType: ProperType.Id, value: loginObjects.Username, driver: driver);
                seleniumSetMethod.EnterText(element: loginObjects.PasswordInputbarId, elementType: ProperType.Id, value: loginObjects.WrongPassword, driver: driver);
                seleniumSetMethod.Click(element: loginObjects.SubmitButtonXpath, elementType: ProperType.X_Path, driver: driver);
                Thread.Sleep(5000);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Then(@"I get '([^']*)' message\.")]
        public void ThenIGetMessage_(string error)
        {
            try
            {

                string Error_Msg;
                Error_Msg = seleniumSetMethod.GetText(element: loginObjects.ErrorMsgId, elementType: ProperType.Id, driver: driver);
                Console.WriteLine(" Error is  : " + error + ". Expected :" + Error_Msg);
                Assert.AreEqual(error, Error_Msg);

            }
            catch (Exception e) { Assert.Fail(e.Message); }
        }

    }
}
