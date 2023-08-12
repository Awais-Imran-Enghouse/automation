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

        }
        //[BeforeScenario("@DeletingQueues")]
        //[AfterFeature("@DeletingQueues")]
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

        [BeforeScenario("@DeletingQueuesBeforeScenario", Order = 1)]
        public void CallingDelRowBeforeScenario()
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
            string url = "http://pkrd-aim-vcc.vcc.bel.rd.eilab.biz/VccWebCenter/?instanceID=76cf08c6-f261-4202-a96b-0c07b4254aca&uc=Queues";
            foreach (var names in ccSupportModuleObject.QueueNamesList)
            {
                Console.WriteLine($"Into the After Feature scenario{names}");
                try
                {
                    applicationFixtures.DeletingRow(allListFinderElement: ccSupportModuleObject.QueueListXpath, driver: driver, nameSuffixIdPart: "_username", deleteSuffixIdPart: "_delete", nameToDelRow: names, okButtonXpath: ccSupportModuleObject.QueueDelOkButtonXpath, url: url);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }




        [AfterScenario(Order = 2)]
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