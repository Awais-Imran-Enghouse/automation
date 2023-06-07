using ConsoleApp1;
using ERM.supportClasses;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace ERM.StepDefinitions
{
    [Binding]
    public class _003LoginWebClientStepDefinitions
    {
        loginPageObjects loginObjects = new loginPageObjects();
        HomePageObjects homePageObjects = new HomePageObjects();
        CCSuportModuleObjects ccSupportModuleObject = new CCSuportModuleObjects();
        WebClientLoginPageObjects webClientLoginPageObjects = new WebClientLoginPageObjects();
        IWebDriver driver;

        public _003LoginWebClientStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;

        }
        //Scenario 1
        [Given(@"I am at the Web Clinet login page\.")]
        public void GivenIAmAtTheWebClinetLoginPage_()
        {
            driver.Navigate().GoToUrl(webClientLoginPageObjects.url);
            Thread.Sleep(5000);

        }

        [When(@"When I enter username\.")]
        public void WhenWhenIEnterUsername_()
        {
            seleniumSetMethod.EnterText(element:webClientLoginPageObjects.UsernameInputbarId,elementType:ProperType.Id,value:ccSupportModuleObject.Username, driver:driver);
            Thread.Sleep(5000);
        }

        [When(@"I click on OK button on webclient login page\.")]
        public void WhenIClickOnOKButton_()
        {
            seleniumSetMethod.Click(element:webClientLoginPageObjects.OkButtonXpath, elementType:ProperType.X_Path, driver:driver);
            Thread.Sleep(5000);
        }

        [When(@"I click on OK button again on webclient login page\.")]
        public void WhenIClickOnOKButtonAgain_()
        {
            seleniumSetMethod.Click(element: webClientLoginPageObjects.OkButtonOnNextPageXpath, elementType: ProperType.X_Path, driver: driver);
        }


        [Then(@"I get logged in web client\.")]
        public void ThenIGetLoggedInWebClient_()
        {
            try
            {
                seleniumSetMethod.Click(element:webClientLoginPageObjects.NoInteractionYesXpath,ProperType.X_Path, driver:driver);
            }
            catch (Exception ex) { }

            Thread.Sleep(5000);
        }
        //Scenario 2
        [When(@"When I enter ""([^""]*)""\.")]
        public void WhenWhenIEnter_(string p0)
        {
            seleniumSetMethod.EnterText(element: webClientLoginPageObjects.UsernameInputbarId, elementType: ProperType.Id, value: p0, driver: driver);
            Thread.Sleep(3000);
            
        }
        [Then(@"I get text ""([^""]*)""\.")]
        public void ThenIGetText_(string error)
        {
            string Error_Text = seleniumSetMethod.GetText(element: webClientLoginPageObjects.ErrorTextXpath, ProperType.X_Path, driver: driver);
            Assert.AreEqual("Error", Error_Text);
            Console.Write(Error_Text);
        }


    }


}
