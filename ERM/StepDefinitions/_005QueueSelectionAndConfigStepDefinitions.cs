using ConsoleApp1;
using ERM.supportClasses;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace ERM.StepDefinitions
{
    [Binding]
    public class _005QueueSelectionAndConfigStepDefinitions
    {
        loginPageObjects loginObjects = new loginPageObjects();
        HomePageObjects homePageObjects = new HomePageObjects();
        CCSuportModuleObjects ccSupportModuleObject = new CCSuportModuleObjects();
        WebClientLoginPageObjects webClientLoginPageObjects = new WebClientLoginPageObjects();
        ApplicationFixtures applicationFixtures = new ApplicationFixtures();

        IWebDriver driver;
        public _005QueueSelectionAndConfigStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;

        }
        [When(@"I click on Queue module\.")]
        public void WhenIClickOnQueueModule_()
        {
            seleniumSetMethod.ExplicitWait(element:ccSupportModuleObject.QueueModuleId,elementType:ProperType.Id,driver:driver);
            seleniumSetMethod.Click(element: ccSupportModuleObject.QueueModuleId, elementType:ProperType.Id, driver:driver);
        }
        [When(@"I clock on Add New Queue button\.")]
        public void WhenIClockOnAddNewQueueButton_()
        {
            string url = driver.Url;
           
            seleniumSetMethod.ExplicitWait(element: ccSupportModuleObject.AddNewQueueButtonXpath, elementType: ProperType.X_Path, driver: driver);
            seleniumSetMethod.Click(element: ccSupportModuleObject.AddNewQueueButtonXpath, elementType: ProperType.X_Path, driver: driver);
            Thread.Sleep(10000);

        }


        [When(@"I enter '([^']*)'\.")]
        public void WhenIEnter_(string QueueName)
        {
            Thread.Sleep(5000);
            seleniumSetMethod.ExplicitWait(element: ccSupportModuleObject.QueueNameInputbarId, elementType: ProperType.Id, driver: driver);
            seleniumSetMethod.EnterText(element: ccSupportModuleObject.QueueNameInputbarId, elementType: ProperType.Id, value: QueueName, driver:driver);
        }

        [When(@"I check the Default checkbox\.")]
        public void WhenICheckTheDefaultCheckbox_()
        {
            driver.Manage().Window.Maximize();
            seleniumSetMethod.ExplicitWait(element: ccSupportModuleObject.DefaultQueueCheckboxXpath, elementType: ProperType.X_Path, driver: driver);
            //seleniumSetMethod.Click(element: ccSupportModuleObject.DefaultQueueCheckboxId, elementType: ProperType.Id, driver: driver);
            seleniumSetMethod.Click(element: ccSupportModuleObject.DefaultQueueCheckboxXpath, elementType: ProperType.X_Path, driver: driver);

        }

        [When(@"I click on the profiles tab\.")]
        public void WhenIClickOnTheProfilesTab_()
        {
            seleniumSetMethod.ExplicitWait(element: ccSupportModuleObject.QueueProfileTabId, elementType: ProperType.Id, driver: driver);
            seleniumSetMethod.Click(element: ccSupportModuleObject.QueueProfileTabId, elementType: ProperType.Id, driver: driver);
        }
        [When(@"I check on the Voxtron Agent checkbox\.")]
        public void WhenICheckOnTheVoxtronAgentCheckbox_()
        {
            seleniumSetMethod.ExplicitWait(element: ccSupportModuleObject.QueueVoxtronAgentCheckBoxXpath, elementType: ProperType.X_Path, driver: driver);
            Thread.Sleep(3000);
            seleniumSetMethod.Click(element: ccSupportModuleObject.QueueVoxtronAgentCheckBoxXpath, elementType: ProperType.X_Path, driver: driver);
            
        }

        [When(@"I click on the Ok button\.")]
        public void WhenIClickOnTheOkButton_()
        {
            
            seleniumSetMethod.ExplicitWait(element: ccSupportModuleObject.QueueProfileOkButtonId, elementType: ProperType.Id, driver: driver);
            seleniumSetMethod.Click(element: ccSupportModuleObject.QueueProfileOkButtonId, elementType: ProperType.Id, driver: driver);
            Thread.Sleep(5000);
            
            try
            {
                seleniumSetMethod.Click(element: ccSupportModuleObject.QueueAlreadyPresentOkXpath, elementType: ProperType.X_Path, driver: driver);
                //applicationfixtures.deletingrow(alllistfinderelement: ccsupportmoduleobject.queuelistxpath, driver: driver, namesuffixidpart: "_name", deletesuffixidpart: "_delete", nametodelrow: ccsupportmoduleobject.queuename1, okbuttonxpath: ccsupportmoduleobject.queuedelokbuttonxpath, url: ccsupportmoduleobject.queueurl);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        [When(@"I click on the edit button of the agent we created\.")]
        public void WhenIClickOnTheEditButtonOfTheAgentWeCreated_()
        {
            
            Thread.Sleep(4000);
            string url = driver.Url;
            //applicationFixtures.EditRow(allListFinderElement:ccSupportModuleObject.QueueListXpath, driver: driver, nameSuffixIdPart: "_username",nameToEditRow:ccSupportModuleObject.Username, editSuffixIdPart:" ");
            applicationFixtures.EditRow(allListFinderElement:ccSupportModuleObject.QueueListXpath, driver:driver,nameSuffixIdPart:ccSupportModuleObject.AgentNameSuffixIdPart, nameToEditRow:ccSupportModuleObject.Username,editSuffixIdPart:ccSupportModuleObject.AgentEditSuffixIdPart, url:url);
        }

        [When(@"I click on the Queue Tab\.")]
        public void WhenIClickOnTheQueueTab_()
        {
            seleniumSetMethod.Click(element:ccSupportModuleObject.QueueTabXPath,elementType:ProperType.X_Path,driver:driver);
            Thread.Sleep(5000);
        }
        [When(@"I check the selected option\.")]
        public void WhenICheckTheSelectedOption_()
        {
            string Xpath_Selected_Row = string.Format(ccSupportModuleObject.QueueSelectedRadioButtonXpath, ccSupportModuleObject.QueueNamesList[0]);
            seleniumSetMethod.Click(element: Xpath_Selected_Row, elementType: ProperType.X_Path, driver: driver);
            
        }

        [When(@"I check the change option for other queue")]
        public void WhenICheckTheChangeOptionForOtherQueue()
        {
            string Xpath_Changed_Row = string.Format(ccSupportModuleObject.QueueChangedRadioButtonXpath, ccSupportModuleObject.QueueNamesList[1]);
            seleniumSetMethod.Click(element: Xpath_Changed_Row, elementType: ProperType.X_Path, driver: driver);
            
        }

        [When(@"I click on the Ok button of Queue page\.")]
        public void WhenIClickOnTheOkButtonOfQueuePage_()
        {
            seleniumSetMethod.Click(element: ccSupportModuleObject.QueuePageOkButtonId, elementType: ProperType.Id, driver: driver);
            Thread.Sleep(10000);
        }


        [When(@"I get the selected queue as well as changed queue\.")]
        public void WhenIGetTheSelectedQueueAsWellAsChangedQueue_()
        {
            Thread.Sleep(5000);
            string selected_queue_xpath = String.Format(webClientLoginPageObjects.QueueSelctedXpath, ccSupportModuleObject.QueueNamesList[0]);
            string selected_queue_name = seleniumSetMethod.GetText(element:selected_queue_xpath,elementType:ProperType.X_Path, driver:driver);
            Thread.Sleep(2000);
            string changed_queue_xpath = String.Format(webClientLoginPageObjects.QueueChangedXpath, ccSupportModuleObject.QueueNamesList[1]);
            Console.WriteLine("_____"+changed_queue_xpath);
            string changed_queue_name = seleniumSetMethod.GetText(element: changed_queue_xpath, elementType: ProperType.X_Path, driver: driver);
            
            Console.WriteLine(selected_queue_xpath +" " + selected_queue_name);
            Console.WriteLine(changed_queue_xpath + " " + changed_queue_name );
            Thread.Sleep(2000);
            Assert.AreEqual(selected_queue_name, ccSupportModuleObject.QueueNamesList[0]);
            Assert.AreEqual(changed_queue_name, ccSupportModuleObject.QueueNamesList[1]);
        }


    }
}
