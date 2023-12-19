using ConsoleApp1;
using ERM.supportClasses;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using TechTalk.SpecFlow;

namespace ERM.StepDefinitions
{
    [Binding]
    public class _010WaitingMonitorActivityMonitorWithEmailsStepDefinitions
    {
        loginPageObjects loginObjects = new loginPageObjects();
        HomePageObjects homePageObjects = new HomePageObjects();
        CCSuportModuleObjects ccSupportModuleObject = new CCSuportModuleObjects();
        WebClientLoginPageObjects webClientLoginPageObjects = new WebClientLoginPageObjects();
        ErmModuleObjects ermModuleObjects = new ErmModuleObjects();
        ApplicationFixtures applicationFixtures = new ApplicationFixtures();
        IWebDriver driver;

        public _010WaitingMonitorActivityMonitorWithEmailsStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }
        [When(@"I ensure that '([^']*)' has status '([^']*)'\.")]
        public void WhenIEnsureThatHasStatus_(string username, string transferring)
        {
            //lblContactProperties
            if (transferring != "Free")
            {
                string getting_transfer_text_xpath = String.Format(webClientLoginPageObjects.ActivityMonitorStatusColumnWRTUsernameXpath, username);
                seleniumSetMethod.ExplicitWait(element: getting_transfer_text_xpath, elementType: ProperType.X_Path, driver: driver);
                //string text = seleniumSetMethod.GetText(element: "//td[contains(text(),\"Dummy Agent1\")]", elementType: ProperType.X_Path, driver: driver);
                string text2 = seleniumSetMethod.GetText(element: getting_transfer_text_xpath, elementType: ProperType.X_Path, driver: driver);

                Assert.IsTrue(text2 == transferring);
                //Console.WriteLine(text);
                Console.WriteLine(text2);
            }
            else if (transferring == "Free")
            {
                Thread.Sleep(3000);
                Boolean check_ =true;
                // Waiting utill the information tab as well as wrapped status in activity monitor is removed.
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                wait.Until(driver => driver.FindElements(By.XPath("//span[contains(text(),\"Information\")]")).Count == 0);
                
                //As wrapped status is dispaeared. Now, clicking on the activity monitor to check the Free status.
                seleniumSetMethod.Click(element: webClientLoginPageObjects.ActivityyMonitorBtnId, elementType: ProperType.Id, driver: driver);

                //performing the actions o ensure the status
                string getting_transfer_text_xpath = String.Format(webClientLoginPageObjects.ActivityMonitorStatusColumnWRTUsernameXpath, username);
                seleniumSetMethod.ExplicitWait(element: getting_transfer_text_xpath, elementType: ProperType.X_Path, driver: driver);
                //string text = seleniumSetMethod.GetText(element: "//td[contains(text(),\"Dummy Agent1\")]", elementType: ProperType.X_Path, driver: driver);
                string text2 = seleniumSetMethod.GetText(element: getting_transfer_text_xpath, elementType: ProperType.X_Path, driver: driver);
                Assert.IsTrue(text2 == transferring);
                //Console.WriteLine(text);
                Console.WriteLine(text2);

                
            }

        }
    }
}
