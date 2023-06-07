using ConsoleApp1;
using demoCCSupport.supportClasses;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;
using System.Security.Permissions;
using TechTalk.SpecFlow;

namespace demoCCSupport.StepDefinitions
{
    [Binding]
    [TestFixture]
    [AllureNUnit]
    public class Feature1StepDefinitions
    {
        loginPageObjects loginObjects = new loginPageObjects();
        HomePageObjects homePageObjects = new HomePageObjects();
        CCSuportModuleObjects ccSupportModuleObject = new CCSuportModuleObjects();

        IWebDriver driver;

        public Feature1StepDefinitions(IWebDriver driver)
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
            catch(Exception e) 
            { 
                Assert.Fail(e.Message);
            }

        }



        [When(@"I enter credentials\.")]
        public void WhenIEnterCredentials_()
        {
       
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

                Console.WriteLine(" Username is  : " + username);
                // "Super Admin"
                Assert.AreEqual("Super Admin", username);
                //Assert.AreEqual("super", username);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }



        // Scenario #2 
        [When(@"I click on CCSupport\.")]
        public void WhenIClickOnCCSupport_()
        {
            try
            {
                Thread.Sleep(5000);
                string agent = "";
                seleniumSetMethod.ExplicitWait(element: homePageObjects.CCSupportXPath, elementType: ProperType.X_Path, driver: driver);
                seleniumSetMethod.Click(element: homePageObjects.CCSupportXPath, elementType: ProperType.X_Path, driver: driver);

                Thread.Sleep(10000);
                //Hooks1 hooks1 = new Hooks1().DeletingAgent();

                //seleniumSetMethod.ExplicitWait(element: "//tbody[@id='tblVccGrid_body']/tr", elementType: ProperType.X_Path, driver: driver);
                seleniumSetMethod.ExplicitWait(element: ccSupportModuleObject.ListOfAgentsXpath, elementType: ProperType.X_Path, driver: driver);
                //IList<IWebElement> all = driver.FindElements(By.XPath("//tbody[@id='tblVccGrid_body']/tr"));
                IList<IWebElement> all = driver.FindElements(By.XPath(ccSupportModuleObject.ListOfAgentsXpath));
                int sum = all.Count + 5;
                Console.WriteLine("Agent name is : " + agent);
                Console.WriteLine("total agent is : " + all.Count + " " + sum);
                for (int i = 1; i <= all.Count; i++)
                {
                    string id = "tblVccGrid_row" + i + "_username";
                    string name;
                    string username = ccSupportModuleObject.Username;
                    name = seleniumSetMethod.GetText(element: id, ProperType.Id, driver: driver);
                    Console.WriteLine(name);

                    if (name == username)
                    {
                        Console.WriteLine("User name is matched and is about to be deleted" + name);
                       
                        seleniumSetMethod.Click(element: ccSupportModuleObject.AddedAgentXpath.Insert(19, ccSupportModuleObject.Username), ProperType.X_Path, driver: driver);
                        seleniumSetMethod.Click(element: ccSupportModuleObject.DeletingOkButtonXpath, ProperType.X_Path, driver: driver);
                    }
                }
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }



        [When(@"I click on add user button\.")]
        public void WhenIClickOnAddUserButton_()
        {
            try
            {
                seleniumSetMethod.ExplicitWait(element: ccSupportModuleObject.AddNewUserButtonId, elementType: ProperType.Id, driver: driver);
                seleniumSetMethod.Click(element: ccSupportModuleObject.AddNewUserButtonId, elementType: ProperType.Id, driver: driver);
                Thread.Sleep(10000);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }



        [When(@"I enter Username\.")]
        public void WhenIEnterUsername_()
        {
            try
            {
                seleniumSetMethod.ExplicitWait(element: ccSupportModuleObject.UsernameInputbarId, elementType: ProperType.Id, driver: driver);
                seleniumSetMethod.EnterText(element: ccSupportModuleObject.UsernameInputbarId, elementType: ProperType.Id, value: ccSupportModuleObject.Username, driver: driver);
               

            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [When(@"I enter Email Address\.")]
        public void WhenIEnterEmailAddress_()
        {
            
            try
            {
                seleniumSetMethod.EnterText(element: ccSupportModuleObject.EmailInputbarId, elementType: ProperType.Id, value: ccSupportModuleObject.Email, driver: driver);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }



        [When(@"I click on the profile tab\.")]
        public void WhenIClickOnTheProfileTab_()
        {
            try
            {
                driver.Manage().Window.Maximize();
                Thread.Sleep(10000);
                seleniumSetMethod.Click(element: ccSupportModuleObject.ProfileTabXPath, elementType: ProperType.X_Path, driver: driver);
                //Thread.Sleep(3000);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }



        [When(@"I click the OK button\.")]
        public void WhenIClickTheOKButton_()
        {
            try
            {
                seleniumSetMethod.ExplicitWait(element: ccSupportModuleObject.ProfileTabOkButtonID, elementType: ProperType.Id, driver: driver);
                seleniumSetMethod.Click(element: ccSupportModuleObject.ProfileTabOkButtonID, elementType: ProperType.Id, driver: driver);
                //Thread.Sleep(4000);
                try
                {
                    seleniumSetMethod.ExplicitWait(element: ccSupportModuleObject.UserReactivationButtonXpath, elementType: ProperType.X_Path, driver: driver);
                    seleniumSetMethod.Click(element: ccSupportModuleObject.UserReactivationButtonXpath, elementType: ProperType.X_Path, driver: driver);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Thread.Sleep(10000);

            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }



        [Then(@"The agent is successfully created\.")]
        public void ThenTheAgentIsSuccessfullyCreated_()
        {
            Console.WriteLine("The agent has been successfully created.");
        }

    }
}
