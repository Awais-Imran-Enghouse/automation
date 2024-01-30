using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using ERM.supportClasses;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using FluentAssertions;
using SeleniumExtras.WaitHelpers;
using System.Reflection.Metadata.Ecma335;
using FluentAssertions.Execution;
using NUnit.Framework;
using AngleSharp.Dom;
using OpenQA.Selenium.Interactions;

namespace ConsoleApp1

{
    [Binding]
    internal class seleniumSetMethod
    {
        public static object SeleniumExtras { get; private set; }
        public static object ExpectedConditions { get; private set; }

        /* 
        This method sends/types string in the input field.
        arguments:
        driver  : it will take the current running state of browser.
        element : it take the element that could be either, id, name or X_path.
        elementType : It takes the type of element such as id, name or x-path.
        */




        public static void EnterText(string element, ProperType elementType, string value, IWebDriver driver)
        {
            /*
             This method enters the value/text in the input bar.
             */
            if (elementType == ProperType.Id)
            {
                driver.FindElement(By.Id(element)).Clear();
                driver.FindElement(By.Id(element)).SendKeys(value);

            }
            if (elementType == ProperType.Name)
            {
                driver.FindElement(By.Name(element)).Clear();
                driver.FindElement(By.Name(element)).SendKeys(value);
            }
            if (elementType == ProperType.X_Path)
            {
                driver.FindElement(By.XPath(element)).Clear();
                driver.FindElement(By.XPath(element)).SendKeys(value);
            }
        }

        public static void Click(string element, ProperType elementType, IWebDriver driver)
        {
            /*
             This method clicks any clickable element.
             */

            if (elementType == ProperType.Id)
            {
                driver.FindElement(By.Id(element)).Click();
            }
            if (elementType == ProperType.Name)
            {
                driver.FindElement(By.Name(element)).Click();
            }
            if (elementType == ProperType.X_Path)
            {
                driver.FindElement(By.XPath(element)).Click();
            }

        }

        public static void RightClick(string element, ProperType elementType, IWebDriver driver)
        {
            /*
             This method clicks any clickable element.
             */

            if (elementType == ProperType.Id)
            {
                IWebElement element_ = driver.FindElement(By.Id(element));
                Actions action = new Actions(driver);
                action.ContextClick(element_).Build().Perform();
                
            }
            if (elementType == ProperType.Name)
            {
                IWebElement element_ = driver.FindElement(By.Name(element));
                Actions action = new Actions(driver);
                action.ContextClick(element_).Build().Perform();
                
            }
            if (elementType == ProperType.X_Path)
            {
                IWebElement element_ = driver.FindElement(By.XPath(element));
                Actions action = new Actions(driver);
                action.ContextClick(element_).Build().Perform();
                
            }

        }



        public static string GetText(string element, ProperType elementType, IWebDriver driver)
        {
            /*
             This method gets the text.
             */

            if (elementType == ProperType.Id)
            {
                IWebElement Text_WE = driver.FindElement(By.Id(element));
                string text = Text_WE.Text;
                return text;
            }
            else if (elementType == ProperType.Name)
            {
                //return driver.FindElement(By.Name(element)).Text;
                IWebElement Text_WE = driver.FindElement(By.Name(element));
                string text = Text_WE.Text;
                return text;
            }
            else if (elementType == ProperType.X_Path)
            {
                //return driver.FindElement(By.XPath(element)).Text;
                IWebElement Text_WE = driver.FindElement(By.XPath(element));
                string text = Text_WE.Text;
                return text;
            }

            else
            {
                return "Wrong Property Type";
            }

        }
        public static string GetAttributeValue(string element, ProperType elementType, IWebDriver driver, string element_to_find_value)
        {
            if (elementType == ProperType.Id)
            {
                string element_value = driver.FindElement(By.Id(element)).GetAttribute(element_to_find_value);
                return element_value;
            }
            if (elementType == ProperType.X_Path) 
            {
                string element_value = driver.FindElement(By.XPath(element)).GetAttribute(element_to_find_value);
                return element_value;
            }
            if (elementType == ProperType.Name) 
            {
                string element_value = driver.FindElement(By.Name(element)).GetAttribute(element_to_find_value);
                return element_value;
            }
            else
            {
                return "wrong element or unable to find value";
            }
        }
        public static void ExplicitWait(string element, ProperType elementType, IWebDriver driver)
        {
            if (elementType == ProperType.X_Path)
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                IWebElement firstResult = wait.Until(driver => driver.FindElement(By.XPath(element)));
            }
            if (elementType == ProperType.Id)
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                IWebElement firstResult = wait.Until(driver => driver.FindElement(By.Id(element)));
            }
            if (elementType == ProperType.Name)
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                IWebElement firstResult = wait.Until(driver => driver.FindElement(By.Name(element)));
            }
        }

        public static void CheckRadioBtn(string element, ProperType elementType, IWebDriver driver)
        {
            /*
             This method clicks any clickable element.
             */
            
            if (elementType == ProperType.Id && !driver.FindElement(By.Id(element)).Selected)
            {
                driver.FindElement(By.Id(element)).Click();
                Console.WriteLine("check method 1");
                //SelectElement dropDown = new SelectElement(driver.FindElement(By.Id(element)));
                //dropDown.SelectByText(element);

            }
            else if (elementType == ProperType.Name && !driver.FindElement(By.Name(element)).Selected)
            {
                driver.FindElement(By.Name(element)).Click();
                Console.WriteLine("check method 2");

            }
            else if (elementType == ProperType.X_Path && !(driver.FindElement(By.XPath(element)).Selected))
            {
                bool checked_ = driver.FindElement(By.XPath(element)).Selected;
                bool chk = !checked_;
                Console.WriteLine("Testing");
                Console.WriteLine(" ... "+ driver.FindElement(By.XPath(element)).Selected);
                //Console.WriteLine(" ... " + driver.FindElement(By.XPath("//input[@id=\"Permission2\"]")).Selected);

                
                //Console.WriteLine("check "+checked_);
                //Console.WriteLine("check" + chk);


                driver.FindElement(By.XPath(element)).Click();
                

            }
            else
            {
                //Assert.Fail();
                Console.WriteLine("Already checked");
            }

        }

        public static bool SelectOrNot(string element, ProperType elementType, IWebDriver driver)
        {
            /*
             This method clicks any clickable element.
             */

            if (elementType == ProperType.Id)
            {
                bool checked_ = driver.FindElement(By.Id(element)).Selected;
                
                //SelectElement dropDown = new SelectElement(driver.FindElement(By.Id(element)));
                //dropDown.SelectByText(element);
                return checked_;

            }
            else if (elementType == ProperType.Name )
            {
                bool checked_ = driver.FindElement(By.Name(element)).Selected;
                
                //SelectElement dropDown = new SelectElement(driver.FindElement(By.Id(element)));
                //dropDown.SelectByText(element);
                return checked_;

            }
            else if (elementType == ProperType.X_Path)
            {
                bool checked_ = driver.FindElement(By.XPath(element)).Selected;
                
                //SelectElement dropDown = new SelectElement(driver.FindElement(By.Id(element)));
                //dropDown.SelectByText(element);
                return checked_; 
            }
            else
            {
                Assert.Fail();
                return false;
            }

        }

        public static void UncheckRadioBtn(string element, ProperType elementType, IWebDriver driver)
        {
            /*
             This method clicks any clickable element.
             */
            Console.WriteLine("uncheck method");
            //Console.WriteLine(driver.FindElement(By.Id(element)).Selected);

            if (elementType == ProperType.Id && !(driver.FindElement(By.Id(element)).Selected))
            {
                driver.FindElement(By.Id(element)).Click();
            }
            else if (elementType == ProperType.Name && !(driver.FindElement(By.Name(element)).Selected))
            {
                driver.FindElement(By.Name(element)).Click();
            }
            else if (elementType == ProperType.X_Path && !(driver.FindElement(By.XPath(element)).Selected))
            {
                driver.FindElement(By.XPath(element)).Click();
            }
            else
            {
                Assert.Fail();
                
            }

        }




        public static void SelectDropDown( string element, ProperType elementType, IWebDriver driver, string dropDownText)
        {
            /*
                This method select the drop down.

                Here, you will find a bit different approach. SelectElement (which is OpenQA.Selenium.Support.UI supported)
                actually takes in IWebElement. And, driver.FindElement(By.Id(element)) actually returns IWebElement.
                
             */

            if (elementType == ProperType.Id)
            {
                SelectElement dropDown = new SelectElement(driver.FindElement(By.Id(element)));
                dropDown.SelectByText(dropDownText);
            }
            if (elementType == ProperType.Name)
            {
                SelectElement dropDown = new SelectElement(driver.FindElement(By.Name(element)));
                dropDown.SelectByText(dropDownText);
            }
        
            if (elementType == ProperType.X_Path)
            {
                SelectElement dropDown = new SelectElement(driver.FindElement(By.XPath(element)));
                dropDown.SelectByText(dropDownText);

            }

        }

    }
}
