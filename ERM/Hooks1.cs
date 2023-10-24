using TechTalk.SpecFlow;
//using Allure.Commons;
using BoDi;
using ConsoleApp1;
using ERM.supportClasses;
using NUnit.Allure.Core;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using ERM.StepDefinitions;
using OpenQA.Selenium.Interactions;
using System.Linq.Expressions;
//using OpenQA.Selenium.We

namespace ERM
{
    [Binding]
    //[TestFixture]
    //[AllureNUnit]
    public sealed class Hooks1 
    {
        // taking files in
        loginPageObjects loginObjects = new loginPageObjects();
        HomePageObjects homePageObjects = new HomePageObjects();
        CCSuportModuleObjects ccSupportModuleObject = new CCSuportModuleObjects();
        ErmModuleObjects ermModuleObjects = new ErmModuleObjects();
        ApplicationFixtures applicationFixtures = new ApplicationFixtures();
        // taken
        
        private readonly IObjectContainer _container;
        
        public Hooks1(IObjectContainer container)
        {
            _container = container;
             //driver = _driver;
        }

        //private readonly IWebDriver driver;
        //public Hooks1(IWebDriver driver)
        //{
        //    driver = driver;
        //}

        [AfterScenario("@tag1", Order = 0)]
        public void BeforeScenarioWithTag1()
        {
            // See https://docs.specflow.org/projects/specflow/en/latest/Bindings/Hooks.html?highlight=hooks#tag-scoping
            Console.WriteLine("This is the after scenario tag");
        }


        [BeforeScenario(Order = 0)]
        public void FirstBeforeScenario()
        {
            // Example of ordering the execution of hooks
            // See https://docs.specflow.org/projects/specflow/en/latest/Bindings/Hooks.html?highlight=order#hook-execution-order
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--enable-javascript");

            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());

            IWebDriver driver = new ChromeDriver(options);
            _container.RegisterInstanceAs<IWebDriver>(driver);
            driver.Manage().Window.Maximize();
            


        }




        [AfterScenario("@DeletingAgent", Order = 0)]
        public void DeletingAgent()
        {


            //TODO: implement logic that has to run after executing each scenario
            Console.WriteLine("Deleting the added agent");
            var driver = _container.Resolve<IWebDriver>();
            driver.Navigate().GoToUrl(ccSupportModuleObject.url);
            Thread.Sleep(10000);
            seleniumSetMethod.ExplicitWait(element: ccSupportModuleObject.ListOfAgentsXpath, elementType: ProperType.X_Path, driver: driver);
            IList<IWebElement> all = driver.FindElements(By.XPath(ccSupportModuleObject.ListOfAgentsXpath));


            Console.WriteLine("total agent is : " + all.Count);
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
            Thread.Sleep(10000);

            //Testing
            //new Actions(driver)
            //   .MoveToElement();

        }
        
        [AfterScenario("@DeletingQueues", Order = 1)]
        public void CallingDelRow()
        {
            CCSuportModuleObjects ccSupportModuleObject = new CCSuportModuleObjects();
            ApplicationFixtures applicationFixtures = new ApplicationFixtures();

            //public _005QueueSelectionAndConfigStepDefinitions(IWebDriver driver)
            //{
            //    this.driver = driver;

            //}
            var driver = _container.Resolve<IWebDriver>();
            //var driver = _container.Resolve<IWebDriver>();
            //string url = driver.Url;
            string url = ccSupportModuleObject.QueueModuleUrl;
            foreach (var names in ccSupportModuleObject.QueueNamesList)
            {
                Console.WriteLine($"Into the After Feature scenario{names}");
                try
                {
                    applicationFixtures.DeletingRow(allListFinderElement: ccSupportModuleObject.QueueListXpath, driver: driver, nameSuffixIdPart: "_name", deleteSuffixIdPart: "_delete", nameToDelRow: names, okButtonXpath: ccSupportModuleObject.QueueDelOkButtonXpath, url: url);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        [BeforeScenario("@DeletingQueuesBS", Order = 1)]
        public void CallingDelRowBS()
        {
            CCSuportModuleObjects ccSupportModuleObject = new CCSuportModuleObjects();
            ApplicationFixtures applicationFixtures = new ApplicationFixtures();
            var driver = _container.Resolve<IWebDriver>();

            //try
            //{
            //    //wait for the element to be loaded
            //    driver.Navigate().GoToUrl(loginObjects.url);
            //    seleniumSetMethod.ExplicitWait(element: loginObjects.UsernameInputbarId, elementType: ProperType.Id, driver: driver);
            //    //further automation process
            //    seleniumSetMethod.EnterText(element: loginObjects.UsernameInputbarId, elementType: ProperType.Id, value: loginObjects.Username, driver: driver);
            //    seleniumSetMethod.EnterText(element: loginObjects.PasswordInputbarId, elementType: ProperType.Id, value: loginObjects.Password, driver: driver);
            //    seleniumSetMethod.Click(element: loginObjects.SubmitButtonXpath, elementType: ProperType.X_Path, driver: driver);


            //}
            //catch { }
           
           
            string url = ccSupportModuleObject.QueueModuleUrl;
            foreach (var names in ccSupportModuleObject.QueueNamesList)
            {
                Console.WriteLine($"Into the After Feature scenario{names}");
                try
                {
                    applicationFixtures.DeletingRow(allListFinderElement: ccSupportModuleObject.QueueListXpath, driver: driver, nameSuffixIdPart: "_name", deleteSuffixIdPart: "_delete", nameToDelRow: names, okButtonXpath: ccSupportModuleObject.QueueDelOkButtonXpath, url: url);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            seleniumSetMethod.Click(element: ccSupportModuleObject.LogoutArrowXpath, elementType: ProperType.X_Path, driver: driver);
            seleniumSetMethod.Click(element: ccSupportModuleObject.LogoutXpath, elementType: ProperType.X_Path, driver: driver);

        }

        [BeforeScenario("@DeletingQueuesBeforeScenario", Order = 1)]
        public void CallingDelRowBeforeScenario()
        {
            CCSuportModuleObjects ccSupportModuleObject = new CCSuportModuleObjects();
            ApplicationFixtures applicationFixtures = new ApplicationFixtures();
            var driver = _container.Resolve<IWebDriver>();

            try
            {

                //wait for the element to be loaded
                driver.Navigate().GoToUrl(loginObjects.url);
                seleniumSetMethod.ExplicitWait(element: loginObjects.UsernameInputbarId, elementType: ProperType.Id, driver: driver);
                //further automation process
                seleniumSetMethod.EnterText(element: loginObjects.UsernameInputbarId, elementType: ProperType.Id, value: loginObjects.Username, driver: driver);
                seleniumSetMethod.EnterText(element: loginObjects.PasswordInputbarId, elementType: ProperType.Id, value: loginObjects.Password, driver: driver);
                seleniumSetMethod.Click(element: loginObjects.SubmitButtonXpath, elementType: ProperType.X_Path, driver: driver);

                string url = "http://pkrd-aim-vcc.vcc.bel.rd.eilab.biz/VccWebCenter/?instanceID=76cf08c6-f261-4202-a96b-0c07b4254aca&uc=Queues";
                foreach (var names in ccSupportModuleObject.QueueNamesList)
                {
                    Console.WriteLine($"Into the After Feature scenario{names}");
                    try
                    {
                        applicationFixtures.DeletingRow(allListFinderElement: ccSupportModuleObject.QueueListXpath, driver: driver, nameSuffixIdPart: "_name", deleteSuffixIdPart: "_delete", nameToDelRow: names, okButtonXpath: ccSupportModuleObject.QueueDelOkButtonXpath, url: url);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                seleniumSetMethod.Click(element: ccSupportModuleObject.LogoutArrowXpath, elementType: ProperType.X_Path, driver: driver);
                seleniumSetMethod.Click(element: ccSupportModuleObject.LogoutXpath, elementType: ProperType.X_Path, driver: driver);

            }
            catch (Exception e) { Console.WriteLine(e.ToString()); }
               
            //var driver = _container.Resolve<IWebDriver>();
            //string url = driver.Url;
            //string url = "http://pkrd-aim-vcc.vcc.bel.rd.eilab.biz/VccWebCenter/?instanceID=76cf08c6-f261-4202-a96b-0c07b4254aca&uc=Queues";
            //foreach (var names in ccSupportModuleObject.QueueNamesList)
            //{
            //    Console.WriteLine($"Into the After Feature scenario{names}");
            //    try
            //    {
            //        applicationFixtures.DeletingRow(allListFinderElement: ccSupportModuleObject.QueueListXpath, driver: driver, nameSuffixIdPart: "_username", deleteSuffixIdPart: "_delete", nameToDelRow: names, okButtonXpath: ccSupportModuleObject.QueueDelOkButtonXpath, url: url);
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine(e);
            //    }
            //}
        }


        [AfterScenario("@DeletingRoutingRules",Order = 2)]
        public void DeletingRoutingRules()
        {
            var driver = _container.Resolve<IWebDriver>();
            try
            {
                driver.Navigate().GoToUrl(loginObjects.url);
                Console.WriteLine("Open Url");
                try { 
                
                    //wait for the element to be loaded
                    seleniumSetMethod.ExplicitWait(element: loginObjects.UsernameInputbarId, elementType: ProperType.Id, driver: driver);
                    //further automation process
                    seleniumSetMethod.EnterText(element: loginObjects.UsernameInputbarId, elementType: ProperType.Id, value: loginObjects.Username, driver: driver);
                    seleniumSetMethod.EnterText(element: loginObjects.PasswordInputbarId, elementType: ProperType.Id, value: loginObjects.Password, driver: driver);
                    seleniumSetMethod.Click(element: loginObjects.SubmitButtonXpath, elementType: ProperType.X_Path, driver: driver);

                    seleniumSetMethod.ExplicitWait(element: ermModuleObjects.ErmModuleXpath, elementType: ProperType.X_Path, driver: driver);
                    seleniumSetMethod.Click(element: ermModuleObjects.ErmModuleXpath, elementType: ProperType.X_Path, driver: driver);

                    seleniumSetMethod.ExplicitWait(element: ermModuleObjects.MailBoxesTabId, elementType: ProperType.Id, driver: driver);
                    seleniumSetMethod.Click(element: ermModuleObjects.MailBoxesTabId, elementType: ProperType.Id, driver: driver);
                }
                catch (Exception e)
                { 
                    Console.WriteLine(e.ToString());
                }
                    string url = driver.Url;
                    applicationFixtures.EditRow(allListFinderElement: ccSupportModuleObject.QueueListXpath, driver: driver, nameSuffixIdPart: "_name", nameToEditRow: "Support", editSuffixIdPart: ccSupportModuleObject.AgentEditSuffixIdPart, url: ermModuleObjects.MailBoxUrl);

                    seleniumSetMethod.ExplicitWait(element: ermModuleObjects.RoutingRulesTabId, elementType: ProperType.Id, driver: driver);
                    seleniumSetMethod.Click(element: ermModuleObjects.RoutingRulesTabId, elementType: ProperType.Id, driver: driver);
                    Thread.Sleep(2000);
                    Console.WriteLine("clicked on routing rules");
                //right click
                seleniumSetMethod.ExplicitWait(element: ermModuleObjects.DummyQueueRoutngRuleXpath, elementType: ProperType.X_Path, driver: driver);
                seleniumSetMethod.RightClick(element: ermModuleObjects.DummyQueueRoutngRuleXpath, elementType: ProperType.X_Path, driver: driver);

                // removing
                seleniumSetMethod.ExplicitWait(element: ermModuleObjects.DummyQueueRoutngRuleRemoveXpath, elementType: ProperType.X_Path, driver: driver);
                seleniumSetMethod.Click(element: ermModuleObjects.DummyQueueRoutngRuleRemoveXpath, elementType: ProperType.X_Path, driver: driver);
                //Thread.Sleep(2000);
                seleniumSetMethod.ExplicitWait(element: ermModuleObjects.DummyQueueRuleDletionOkBtnXpath, elementType: ProperType.X_Path, driver: driver);
                seleniumSetMethod.Click(element: ermModuleObjects.DummyQueueRuleDletionOkBtnXpath, elementType: ProperType.X_Path, driver: driver);
                
                seleniumSetMethod.ExplicitWait(element: ermModuleObjects.RoutingRulesOkBtnId, elementType: ProperType.Id, driver: driver);

                seleniumSetMethod.Click(element: ermModuleObjects.RoutingRulesOkBtnId, elementType: ProperType.Id, driver: driver);

                Thread.Sleep(2000);
                Console.WriteLine("Dummy queue rule deleted");

            }
            catch (Exception e)
            {
                //Assert.Fail(e.Message);
                Console.WriteLine("didn't click  on routing rules");
            }
        }

        [AfterScenario(Order = 3)]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
            var driver = _container.Resolve<IWebDriver>();
            if (driver != null)
            {
                Console.WriteLine("Quit the browser");
                driver.Quit();
            }

        }
    }
}