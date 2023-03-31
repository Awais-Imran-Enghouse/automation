using Allure.Commons;
using BoDi;
using ConsoleApp1;
using NUnit.Allure.Core;
using NUnit.Framework;
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

        [BeforeScenario("@tag1")]
        public void BeforeScenarioWithTag()
        {
            // Example of filtering hooks using tags. (in this case, this 'before scenario' hook will execute if the feature/scenario contains the tag '@tag1')
            // See https://docs.specflow.org/projects/specflow/en/latest/Bindings/Hooks.html?highlight=hooks#tag-scoping

            //TODO: implement logic that has to run before executing each scenario

        }

        [BeforeScenario(Order = 0)]
        public void FirstBeforeScenario()
        {
            // Example of ordering the execution of hooks
            // See https://docs.specflow.org/projects/specflow/en/latest/Bindings/Hooks.html?highlight=order#hook-execution-order

            //TODO: implement logic that has to run before executing each scenario

            //propertiesCollection.driver = new ChromeDriver();
            //Console.WriteLine("Open browser");

            IWebDriver driver = new ChromeDriver();
            _container.RegisterInstanceAs<IWebDriver>(driver);

        }

        [AfterScenario]
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