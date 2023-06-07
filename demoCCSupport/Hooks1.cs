using Allure.Commons;
using BoDi;
using ConsoleApp1;
using demoCCSupport.supportClasses;
using NUnit.Allure.Core;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace demoCCSupport
{
    [Binding]
    [TestFixture]
    [AllureNUnit]
    public sealed class Hooks1
    {
        // taking files in
        loginPageObjects loginObjects = new loginPageObjects();
        HomePageObjects homePageObjects = new HomePageObjects();
        CCSuportModuleObjects ccSupportModuleObject = new CCSuportModuleObjects();
        // taken


        public static AllureLifecycle allure = AllureLifecycle.Instance;

        private readonly IObjectContainer _container;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            allure.CleanupResultDirectory();
            
        }


        public void Init()
        {
           
            Environment.CurrentDirectory = Path.GetDirectoryName(GetType().Assembly.Location);
        }



        public Hooks1(IObjectContainer container) 
        { 
            _container = container; 
        }

        [AfterScenario("@tag1", Order=0)]
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

            IWebDriver driver = new ChromeDriver();
            _container.RegisterInstanceAs<IWebDriver>(driver);

        }



        
        [AfterScenario("@DeletingAgent", Order = 0)]
        public void DeletingAgent()
        {


            //TODO: implement logic that has to run after executing each scenario
            Console.WriteLine("Deleting the added agent");
            var driver = _container.Resolve<IWebDriver>();
            //driver.Navigate().GoToUrl(ccSupportModuleObject.url);
            //Thread.Sleep(10000);
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
    



    [AfterScenario(Order =1)]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
            var driver = _container.Resolve<IWebDriver>();
            if(driver != null)
            {
                Console.WriteLine("Quit the browser");
                driver.Quit();
            }
            
        }
    }
}