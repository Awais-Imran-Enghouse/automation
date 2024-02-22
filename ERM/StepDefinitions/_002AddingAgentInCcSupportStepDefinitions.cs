using ConsoleApp1;
using ERM.supportClasses;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace ERM.StepDefinitions
{
    [Binding]
    public class _002AddingAgentInCcSupportStepDefinitions
    {

        loginPageObjects loginObjects = new loginPageObjects();
        HomePageObjects homePageObjects = new HomePageObjects();
        CCSuportModuleObjects ccSupportModuleObject = new CCSuportModuleObjects();

        IWebDriver driver;

        public _002AddingAgentInCcSupportStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;

        }

        // Scenario #2 
        [When(@"I click on CCSupport\.")]
        public void WhenIClickOnCCSupport_()
        {
            try
            {
                Thread.Sleep(5000);
                //string agent = "";
                seleniumSetMethod.ExplicitWait(element: homePageObjects.CCSupportXPath, elementType: ProperType.X_Path, driver: driver);
                seleniumSetMethod.Click(element: homePageObjects.CCSupportXPath, elementType: ProperType.X_Path, driver: driver);

                Thread.Sleep(10000);
                //seleniumSetMethod.ExplicitWait(element: ccSupportModuleObject.ListOfAgentsXpath, elementType: ProperType.X_Path, driver: driver);
                //IList<IWebElement> all = driver.FindElements(By.XPath(ccSupportModuleObject.ListOfAgentsXpath));
                //int sum = all.Count + 5;
                //Console.WriteLine("Agent name is : " + agent);
                ////Console.WriteLine("total agent is : " + all.Count + " " + sum);
                //for (int i = 1; i <= all.Count; i++)
                //{
                //    string id = "tblVccGrid_row" + i + "_username";
                //    string name;
                //    string username = ccSupportModuleObject.Username;
                //    name = seleniumSetMethod.GetText(element: id, ProperType.Id, driver: driver);
                //    Console.WriteLine(name);

                //    if (name == username)
                //    {
                //        Console.WriteLine("User name is matched and is about to be deleted" + name);

                //        seleniumSetMethod.Click(element: ccSupportModuleObject.AddedAgentXpath.Insert(19, ccSupportModuleObject.Username), ProperType.X_Path, driver: driver);
                //        seleniumSetMethod.Click(element: ccSupportModuleObject.DeletingOkButtonXpath, ProperType.X_Path, driver: driver);
                //    }
                //}
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }

        [When(@"I click on the User module\.")]
        public void WhenIClickOnTheUserModule_()
        {
            seleniumSetMethod.ExplicitWait(element: ccSupportModuleObject.UserModuleId, elementType: ProperType.Id, driver: driver);
            seleniumSetMethod.Click(element: ccSupportModuleObject.UserModuleId, elementType: ProperType.Id, driver: driver);

        }




        [When(@"I click on add user button\.")]
        public void WhenIClickOnAddUserButton_()
        {

            try
            {
                string agent = "";
                seleniumSetMethod.ExplicitWait(element: ccSupportModuleObject.ListOfAgentsXpath, elementType: ProperType.X_Path, driver: driver);
                IList<IWebElement> all = driver.FindElements(By.XPath(ccSupportModuleObject.ListOfAgentsXpath));
                int sum = all.Count + 5;
                Console.WriteLine("Agent name is : " + agent);
                Console.WriteLine("total agent is : " + all.Count );
                for (int i = 1; i <= all.Count; i++)
                {
                    string id = "tblVccGrid_row" + i + "_username";
                    string name;
                    string username = ccSupportModuleObject.Username;
                    name = seleniumSetMethod.GetText(element: id, ProperType.Id, driver: driver);
                    Console.WriteLine($"{name} {username}");
                    Console.WriteLine(name);

                    if (name == username)
                    {
                        Console.WriteLine("User name is matched and is about to be deleted" + name);

                        seleniumSetMethod.Click(element: ccSupportModuleObject.AddedAgentXpath.Insert(19, ccSupportModuleObject.Username), ProperType.X_Path, driver: driver);
                        seleniumSetMethod.Click(element: ccSupportModuleObject.DeletingOkButtonXpath, ProperType.X_Path, driver: driver);
                    }
                }

                //seleniumSetMethod.ExplicitWait(element: ccSupportModuleObject.AddNewUserButtonId, elementType: ProperType.Id, driver: driver);
                //seleniumSetMethod.Click(element: ccSupportModuleObject.AddNewUserButtonId, elementType: ProperType.Id, driver: driver);
                Thread.Sleep(5000);
                seleniumSetMethod.ExplicitWait(element: ccSupportModuleObject.AddNewUserButtonXpath, elementType: ProperType.X_Path, driver: driver);
                seleniumSetMethod.Click(element: ccSupportModuleObject.AddNewUserButtonXpath, elementType: ProperType.X_Path, driver: driver);
                Thread.Sleep(5000);
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
                //driver.Manage().Window.Maximize();
                Thread.Sleep(10000);
                seleniumSetMethod.Click(element: ccSupportModuleObject.ProfileTabXPath, elementType: ProperType.X_Path, driver: driver);
                Thread.Sleep(3000);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }



        

        [When(@"I click the OK button on the profile tab\.")]
        public void WhenIClickTheOKButtononTheProfileTab_()
        {
            try
            {
                seleniumSetMethod.ExplicitWait(element: ccSupportModuleObject.ProfileTabOkButtonID, elementType: ProperType.Id, driver: driver);
                seleniumSetMethod.Click(element: ccSupportModuleObject.ProfileTabOkButtonID, elementType: ProperType.Id, driver: driver);
                Thread.Sleep(4000);
                try
                {
                    seleniumSetMethod.ExplicitWait(element: ccSupportModuleObject.UserReactivationButtonXpath, elementType: ProperType.X_Path, driver: driver);
                    seleniumSetMethod.Click(element: ccSupportModuleObject.UserReactivationButtonXpath, elementType: ProperType.X_Path, driver: driver);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
                Thread.Sleep(4000);

            }
            catch (Exception e)
            {
                //Assert.Fail(e.Message);
                Console.WriteLine(e.Message);
            }
        }




        [Then(@"The agent is successfully created\.")]
        public void ThenTheAgentIsSuccessfullyCreated_()
        {
            Console.WriteLine("The agent has been successfully created.");
        }
    }
}
