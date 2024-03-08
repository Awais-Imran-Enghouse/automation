using ConsoleApp1;
using ERM.supportClasses;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace ERM.StepDefinitions
{
    [Binding]
    public class _008WaitingMonitorActivityMonitorStepDefinitions
    {
        loginPageObjects loginObjects = new loginPageObjects();
        HomePageObjects homePageObjects = new HomePageObjects();
        CCSuportModuleObjects ccSupportModuleObject = new CCSuportModuleObjects();
        WebClientLoginPageObjects webClientLoginPageObjects = new WebClientLoginPageObjects();
        ApplicationFixtures applicationFixtures = new ApplicationFixtures();

        IWebDriver driver;
        public _008WaitingMonitorActivityMonitorStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }
        [When(@"I click the permission tab\.")]
        public void WhenIClickThePermissionTab_()
        {
            seleniumSetMethod.Click(element: ccSupportModuleObject.PermissionTabId, elementType: ProperType.Id, driver: driver);
        }

        [When(@"I check the Enable activity monitor\.")]
        public void WhenICheckTheEnableActivityMonitor_()
        {
            
            bool sel = seleniumSetMethod.SelectOrNot(element: ccSupportModuleObject.ActivityMoniorIsSelectOrNotXpath, elementType: ProperType.X_Path, driver: driver);
            Console.WriteLine(sel);
            if (sel == false)
            {
                //Thread.Sleep(10000);
                seleniumSetMethod.ExplicitWait(element: ccSupportModuleObject.ActivityMonitorChkBoxXpath, elementType: ProperType.X_Path, driver: driver);
                seleniumSetMethod.Click(element: ccSupportModuleObject.ActivityMonitorChkBoxXpath, elementType: ProperType.X_Path, driver: driver);
                //Thread.Sleep(10000);
                bool after_click = seleniumSetMethod.SelectOrNot(element: "//input[@id=\"Permission2\"]", elementType: ProperType.X_Path, driver: driver);
                Console.WriteLine(after_click);
            }
            

        }

        [When(@"I click the OK button on permission tab\.")]
        public void WhenIClickTheOKButtonOnPermissionTab_()
        {
            Thread.Sleep(10000);
            seleniumSetMethod.Click(element: ccSupportModuleObject.PermissionTabOkButtonId, elementType: ProperType.Id, driver: driver);
            
        }

        [When(@"I click on the Activity Monitor button in webclient\.")]
        public void WhenIClickOnTheActivityMonitorButtonInWebclient_()
        {
            seleniumSetMethod.ExplicitWait(element: webClientLoginPageObjects.ActivityyMonitorBtnId, elementType: ProperType.Id, driver: driver);
            seleniumSetMethod.Click(element: webClientLoginPageObjects.ActivityyMonitorBtnId, elementType: ProperType.Id, driver: driver);
        }


        [When(@"I close the Activity Monitor tab\.")]
        public void WhenICloseTheActivityMonitorTab_()
        {
            seleniumSetMethod.ExplicitWait(element: webClientLoginPageObjects.ActivityMonitorCloseBtnXpath, elementType: ProperType.X_Path, driver: driver);
            seleniumSetMethod.Click(element: webClientLoginPageObjects.ActivityMonitorCloseBtnXpath, elementType: ProperType.X_Path, driver: driver);
        }


        [When(@"I check the Enable waiting monitor\.")]
        public void WhenICheckTheEnableWaitingMonitor_()
        {
            bool sel = seleniumSetMethod.SelectOrNot(element: ccSupportModuleObject.WaitingMoniorIsSelectOrNotXpath, elementType: ProperType.X_Path, driver: driver);
            Console.WriteLine(sel);
            if (sel == false)
            {
                //Thread.Sleep(5000);
                seleniumSetMethod.ExplicitWait(element: ccSupportModuleObject.WaitingMonitorChkBoxXpath, elementType: ProperType.X_Path, driver: driver);
                seleniumSetMethod.Click(element: ccSupportModuleObject.WaitingMonitorChkBoxXpath, elementType: ProperType.X_Path, driver: driver);
                //Thread.Sleep(5000);

            }
        }

        [When(@"I click on the Waiting Monitor button\.")]
        public void WhenIClickOnTheWaitingMonitorButton_()
        {
            seleniumSetMethod.ExplicitWait(element: webClientLoginPageObjects.WaitingMonittorBtnId, elementType: ProperType.Id, driver: driver);
            seleniumSetMethod.Click(element: webClientLoginPageObjects.WaitingMonittorBtnId, elementType: ProperType.Id, driver: driver);
        }

        [When(@"I close the Waiting Monitor tab\.")]
        public void WhenICloseTheWaitingMonitorTab_()
        {
            seleniumSetMethod.ExplicitWait(element: webClientLoginPageObjects.WaitingMonitorCloseBtnXpath, elementType: ProperType.X_Path, driver: driver);
            seleniumSetMethod.Click(element: webClientLoginPageObjects.WaitingMonitorCloseBtnXpath, elementType: ProperType.X_Path, driver: driver);
        }
    }
}
