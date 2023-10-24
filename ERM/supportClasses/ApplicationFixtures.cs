using ConsoleApp1;
using ERM.StepDefinitions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERM.supportClasses
{
    public class ApplicationFixtures
    {
    
        loginPageObjects loginObjects = new loginPageObjects();
        HomePageObjects homePageObjects = new HomePageObjects();
        CCSuportModuleObjects ccSupportModuleObject = new CCSuportModuleObjects();

        


        public void DeletingRow(string allListFinderElement, IWebDriver driver, string nameSuffixIdPart, string nameToDelRow, string deleteSuffixIdPart, string okButtonXpath, string url)
        {
            driver.Navigate().GoToUrl(url);      
            Thread.Sleep(5000);
            seleniumSetMethod.ExplicitWait(element: allListFinderElement, elementType: ProperType.X_Path, driver: driver);
            string agent = "";
            IList<IWebElement> all = driver.FindElements(By.XPath(allListFinderElement));
            int sum = all.Count + 5;
            Console.WriteLine($"total queues are :  {all.Count}");
            //Console.WriteLine("total agent is : " + all.Count + " " + sum);
            for (int i = 1; i <= all.Count; i++)
            {
                string id = "tblVccGrid_row" + i + nameSuffixIdPart;
                string name;
                string nameToDelRow_ = nameToDelRow;
                name = seleniumSetMethod.GetText(element: id, ProperType.Id, driver: driver);
                Console.WriteLine($" Name to del row {name}");

                if (name == nameToDelRow)
                {
                    string deleteId = "tblVccGrid_row" + i + deleteSuffixIdPart;
                    Console.WriteLine("User name is matched and is about to be deleted" + name);

                    seleniumSetMethod.Click(element: deleteId, ProperType.Id, driver: driver);
                    Thread.Sleep(3000);
                    Console.WriteLine("clicked on del button");
                    seleniumSetMethod.Click(element: okButtonXpath, ProperType.X_Path, driver: driver);
                    Console.WriteLine("clicked on ok button");
                    Thread.Sleep(5000);
                }
            }
        }
        public void EditRow(string allListFinderElement, IWebDriver driver, string nameSuffixIdPart, string nameToEditRow, string editSuffixIdPart, string url)
        {
            driver.Navigate().GoToUrl(url);
            Thread.Sleep(5000);
            string agent = "";
            IList<IWebElement> all = driver.FindElements(By.XPath(allListFinderElement));
            int sum = all.Count + 5;
            Console.WriteLine("Agent name is : " + agent);
            //Console.WriteLine("total agent is : " + all.Count + " " + sum);
            for (int i = 1; i <= all.Count; i++)
            {
                string id = "tblVccGrid_row" + i + nameSuffixIdPart;
                string name;
                string nameToDelRow_ = nameToEditRow;
                name = seleniumSetMethod.GetText(element: id, ProperType.Id, driver: driver);
                Console.WriteLine(name);

                if (name == nameToEditRow)
                {
                    string deleteId = "tblVccGrid_row" + i + editSuffixIdPart;
                    Console.WriteLine("User name is matched and is about to be deleted" + name);

                    seleniumSetMethod.Click(element: deleteId, ProperType.Id, driver: driver);
                    Thread.Sleep(3000);
                    Console.WriteLine("clicked on Edit button");
                    //seleniumSetMethod.Click(element: okButtonXpath, ProperType.X_Path, driver: driver);
                    //Console.WriteLine("clicked on ok button");
                    Thread.Sleep(5000);
                }
            }
        }
    }
}
