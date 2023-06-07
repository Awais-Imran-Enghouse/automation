using ConsoleApp1;
using ERM.supportClasses;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace ERM.StepDefinitions
{
    [Binding]
    public class _004SettingFunctionalityStepDefinitions
    {
        loginPageObjects loginObjects = new loginPageObjects();
        HomePageObjects homePageObjects = new HomePageObjects();
        CCSuportModuleObjects ccSupportModuleObject = new CCSuportModuleObjects();
        WebClientLoginPageObjects webClientLoginPageObjects = new WebClientLoginPageObjects();

        IWebDriver driver;
        public _004SettingFunctionalityStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;

        }

        [When(@"I click on the setting icon\.")]
        public void WhenIClickOnTheSettingIcon_()
        {
            seleniumSetMethod.Click(element:webClientLoginPageObjects.SettingId, elementType:ProperType.Id, driver:driver); 
            Thread.Sleep(2000);
        }

        [Then(@"A new Iframe with heading ""([^""]*)"" is appeared\.")]
        public void ThenANewIframeWithHeadingIsAppeared_(string settings)
        {
            string text = seleniumSetMethod.GetText(element:webClientLoginPageObjects.SettingHeadingId,elementType:ProperType.Id,driver:driver);
            Assert.AreEqual(settings, text);
            Console.Write(text);
        }

        [When(@"I select (.*) from drop down\.")]
        public void WhenISelectArabicFromDropDown_(string language)
        {
            string LanguageXpathMaker = String.Format(webClientLoginPageObjects.LanguageDropDownXpath, language);
            Console.WriteLine(LanguageXpathMaker);
            seleniumSetMethod.Click(element: webClientLoginPageObjects.LanguageTableXpath, elementType: ProperType.X_Path, driver: driver);
            seleniumSetMethod.Click(element: LanguageXpathMaker, elementType: ProperType.X_Path, driver: driver);
            //Thread.Sleep(5000);
            seleniumSetMethod.Click(element:webClientLoginPageObjects.LanguageDropDownOkButtonId,elementType:ProperType.Id, driver:driver); 
            
        }

        [Then(@"I get (.*) in (.*) language\.")]
        public void ThenIGetHeadingInArabicLanguage_(string Username_Text, string language)
        {
            
            seleniumSetMethod.ExplicitWait(element: webClientLoginPageObjects.UsernameTextXpath, elementType: ProperType.X_Path, driver: driver);
            Thread.Sleep(2000);
            //string text = seleniumSetMethod.GetText(element: webClientLoginPageObjects.HomePageHeadingId, elementType: ProperType.Id, driver: driver);
            string text = seleniumSetMethod.GetText(element: webClientLoginPageObjects.UsernameTextXpath, elementType: ProperType.X_Path, driver: driver);
            Console.Write(Username_Text + "___");
            Console.Write("text" + text + " " + "heading "+Username_Text + "___");
            Assert.AreEqual(Username_Text, text);
        }



    }
}
