using AngleSharp.Dom;
using ConsoleApp1;
using ERM.supportClasses;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace ERM.StepDefinitions
{
    [Binding]
    public class _007LogOffPauseChangeInteractionBtnsStepDefinitions
    {
        loginPageObjects loginObjects = new loginPageObjects();
        HomePageObjects homePageObjects = new HomePageObjects();
        CCSuportModuleObjects ccSupportModuleObject = new CCSuportModuleObjects();
        WebClientLoginPageObjects webClientLoginPageObjects = new WebClientLoginPageObjects();
        ApplicationFixtures applicationFixtures = new ApplicationFixtures();

        IWebDriver driver;
        public _007LogOffPauseChangeInteractionBtnsStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }

        [When(@"I check the change option for Dummy Queue1")]
        public void WhenICheckTheChangeOptionForDummyQueue_()
        {
            //Taking value of for element
            string add_dummy_agent = string.Format(ccSupportModuleObject.QueueChangedForElemenetTakerXpath, ccSupportModuleObject.QueueNamesList[0]);
            string for_value_finder = driver.FindElement(By.XPath(add_dummy_agent)).GetAttribute("for");
            Console.WriteLine("For value: " + for_value_finder);
            //adjusting values of for and dummy agent name
            string Xpath_Changed_Row = string.Format(ccSupportModuleObject.QueueChangedRadioButtonXpath, ccSupportModuleObject.QueueNamesList[0], for_value_finder);
            Console.WriteLine("Xpath for Dummy agent 1 : "+Xpath_Changed_Row);
            seleniumSetMethod.Click(element: Xpath_Changed_Row, elementType: ProperType.X_Path, driver: driver);
            Thread.Sleep(3000);
        }
        [When(@"I click on the edit button of '([^']*)'\.")]
        public void WhenIClickOnTheEditButtonOf_(string p0)
        {
            string url = driver.Url;
            applicationFixtures.EditRow(allListFinderElement: ccSupportModuleObject.QueueListXpath, driver: driver, nameSuffixIdPart: "_name", nameToEditRow: p0, editSuffixIdPart: ccSupportModuleObject.AgentEditSuffixIdPart, url: url);
        }

        [When(@"I click on the Agent Settings\.")]
        public void WhenIClickOnTheAgentSettings_()
        {
            seleniumSetMethod.Click(element:ccSupportModuleObject.QueueAgentSettingTabId, elementType:ProperType.Id, driver:driver);
        }

        [When(@"I check the Logging out of last agent\.")]
        public void WhenICheckTheLoggingOutOfLastAgent_()
        {
            seleniumSetMethod.Click(element:ccSupportModuleObject.LoggingOutLastAgentCheckBoxXpath, elementType:ProperType.X_Path, driver:driver);
            Thread.Sleep(3000);
        }

        [When(@"I check the Pause of last agent\.")]
        public void WhenICheckThePauseOfLastAgent_()
        {
            seleniumSetMethod.Click(element: ccSupportModuleObject.PauseLastAgentCheckBoxXpath, elementType: ProperType.X_Path, driver: driver);
        }

        [When(@"I click on the Ok button of Agent Setting tab\.")]
        public void WhenIClickOnTheOkButtonOfAgentSettingTab_()
        {
            seleniumSetMethod.Click(element: ccSupportModuleObject.QueueAgentSettingOkBtnId, elementType: ProperType.Id, driver: driver);
            Thread.Sleep(5000);
        }

        [When(@"I checked '([^']*)'\.")]
        public void WhenIChecked_(string p0)
        {
            if (p0 == "Dummy Queue1")
            {
                Thread.Sleep(3000);
                seleniumSetMethod.Click(element: webClientLoginPageObjects.DummyQueue1Xpath, elementType: ProperType.X_Path, driver: driver);
            }
            if (p0 == "Dummy Queue2")
            {
                Thread.Sleep(5000);
                //seleniumSetMethod.Click(element: webClientLoginPageObjects.DummyQueue2Xpath, elementType: ProperType.X_Path, driver: driver);
                //seleniumSetMethod.CheckRadioBtn(element: webClientLoginPageObjects.DummyQueue2Xpath, elementType: ProperType.X_Path, driver: driver);
                //seleniumSetMethod.CheckRadioBtn(element: "//*[@id=\"chkQueue8\"]", elementType: ProperType.X_Path, driver: driver);
                //bool checked_ = driver.FindElement(By.XPath("//*[@id=\"chkQueue8\"]")).Selected;
                //bool checked_ = seleniumSetMethod.SelectOrNot(element: "//*[@id=\"chkQueue8\"]", elementType: ProperType.X_Path, driver: driver);
                bool checked_ = seleniumSetMethod.SelectOrNot(element: webClientLoginPageObjects.DummyQueue2XpathSelectChk, elementType: ProperType.X_Path, driver: driver);
                if (!checked_)
                //if (true)
                {
                    Console.WriteLine("Is it selected? ", !checked_);
                    Console.WriteLine(!checked_);
                    //driver.FindElement(By.XPath("//div[@class=\"checkbox\"]/label[@for=\"chkQueue8\"]")).Click();
                    seleniumSetMethod.Click(element: webClientLoginPageObjects.DummyQueue2Xpath, elementType: ProperType.X_Path, driver: driver);

                }
                Thread.Sleep(5000);
            }

        }

        [When(@"I click the Pause button\.")]
        public void WhenIClickThePauseButton_()
        {
            seleniumSetMethod.Click(element:webClientLoginPageObjects.PauseBtnId, elementType:ProperType.Id, driver:driver);    
        }

        [Then(@"It is successfully paused\.")]
        public void ThenItIsSuccessfullyPaused_()
        {
            Thread.Sleep(2000);
            string actualu_element_value = webClientLoginPageObjects.ElementValuesDic.ElementAt(0).Value;
            Console.WriteLine("actual value" + " " + actualu_element_value);

            string found_element_value = seleniumSetMethod.GetAttributeValue(element: webClientLoginPageObjects.PauseBtnId, elementType: ProperType.Id, driver: driver, element_to_find_value: webClientLoginPageObjects.ElementValuesDic.ElementAt(0).Key);
            Console.WriteLine("found value" + found_element_value );
            Assert.AreEqual(actualu_element_value, found_element_value);
        }

        [When(@"I click on the logoff button\.")]
        public void WhenIClickOnTheLogoffButton_()
        {
            seleniumSetMethod.Click(element:webClientLoginPageObjects.LogOffId, elementType:ProperType.Id, driver:driver);
        }

        [Then(@"I get logged off\.")]
        public void ThenIGetLoggedOff_()
        {
            Thread.Sleep(7000);

            seleniumSetMethod.ExplicitWait(element:webClientLoginPageObjects.LoginTextId, elementType:ProperType.Id, driver:driver);
            string login_text = seleniumSetMethod.GetText(element:webClientLoginPageObjects.LoginTextId, elementType:ProperType.Id,driver:driver);
            Console.WriteLine(login_text + " " + webClientLoginPageObjects.LoginText);
            Assert.AreEqual(login_text, webClientLoginPageObjects.LoginText);
        }

        [Then(@"The pause button is disabled\.")]
        public void ThenThePauseButtonIsDisabled_()
        {
            seleniumSetMethod.ExplicitWait(element: webClientLoginPageObjects.PauseBtnId, elementType: ProperType.Id, driver: driver);
            Thread.Sleep(2000);
            string PauseBtnDisabled = seleniumSetMethod.GetAttributeValue(element: webClientLoginPageObjects.PauseBtnId, elementType: ProperType.Id, driver: driver, element_to_find_value: webClientLoginPageObjects.ElementValuesDic.ElementAt(1).Key);
            Console.WriteLine(PauseBtnDisabled + " " + webClientLoginPageObjects.TrueVal);
            Assert.AreEqual(PauseBtnDisabled, webClientLoginPageObjects.TrueVal);

        }

        [Then(@"The log off button is also disabled\.")]
        public void ThenTheLogOffButtonIsAlsoDisabled_()
        {
            seleniumSetMethod.ExplicitWait(element: webClientLoginPageObjects.LogOffId, elementType: ProperType.Id, driver: driver);
            Thread.Sleep(2000);
            string PauseBtnDisabled = seleniumSetMethod.GetAttributeValue(element: webClientLoginPageObjects.LogOffId, elementType: ProperType.Id, driver: driver, element_to_find_value: webClientLoginPageObjects.ElementValuesDic.ElementAt(1).Key);
            Console.WriteLine(PauseBtnDisabled + " " + webClientLoginPageObjects.TrueVal);
            Assert.AreEqual(PauseBtnDisabled, webClientLoginPageObjects.TrueVal);
        }

        [When(@"I click on Change Interaction button\.")]
        public void WhenIClickOnChangeInteractionButton_()
        {
            seleniumSetMethod.ExplicitWait(element: webClientLoginPageObjects.ChangeInteractionBtnId, elementType: ProperType.Id, driver: driver);
            seleniumSetMethod.Click(element: webClientLoginPageObjects.ChangeInteractionBtnId, elementType: ProperType.Id, driver: driver);
        }

        [When(@"I unchecked '([^']*)' on Change Interaction popup\.")]
        public void WhenIUnchecked_(string p0)
        {
            if (p0 == "Dummy Queue1")
            {
                seleniumSetMethod.ExplicitWait(element: webClientLoginPageObjects.ChangeInteractionDummyQu1Xpath, elementType: ProperType.X_Path, driver: driver);
                seleniumSetMethod.Click(element: webClientLoginPageObjects.ChangeInteractionDummyQu1Xpath, elementType: ProperType.X_Path, driver: driver);
            }
            if (p0 == "Dummy Queue2")
            {
                seleniumSetMethod.ExplicitWait(element: webClientLoginPageObjects.ChangeInteractionDummyQu2Xpath, elementType: ProperType.X_Path, driver: driver);
                seleniumSetMethod.Click(element: webClientLoginPageObjects.ChangeInteractionDummyQu2Xpath, elementType: ProperType.X_Path, driver: driver);
            }
        }
        
        


        [When(@"I click on the ok button of Change Interaction pop up\.")]
        public void WhenIClickOnTheOkButtonOfChangeInteractionPopUp_()
        {
            Thread.Sleep(3000);
            seleniumSetMethod.Click(element: webClientLoginPageObjects.ChangeInteractionOkButtonXpath, elementType: ProperType.X_Path, driver: driver);
        }

        [Then(@"I get the warning message\.")]
        public void ThenIGetTheWarningMessage_()
        {
            Thread.Sleep(5000);
            seleniumSetMethod.ExplicitWait(element: webClientLoginPageObjects.ChangeIntWarningMsgId, elementType: ProperType.Id, driver: driver);
            string Warning_Text = seleniumSetMethod.GetText(element: webClientLoginPageObjects.ChangeIntWarningMsgId, elementType: ProperType.Id, driver: driver);
            Console.WriteLine(Warning_Text);
            Assert.AreEqual(Warning_Text, webClientLoginPageObjects.ChangeIntWarningMsg);
        }




    }
}
