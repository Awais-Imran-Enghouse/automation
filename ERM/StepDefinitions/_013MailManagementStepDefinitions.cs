using ConsoleApp1;
using ERM.supportClasses;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.IO;
using System.Security.AccessControl;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace ERM.StepDefinitions
{
    [Binding]
    public class _013MailManagementStepDefinitions
    {
        loginPageObjects loginObjects = new loginPageObjects();
        HomePageObjects homePageObjects = new HomePageObjects();
        CCSuportModuleObjects ccSupportModuleObject = new CCSuportModuleObjects();
        WebClientLoginPageObjects webClientLoginPageObjects = new WebClientLoginPageObjects();
        ErmModuleObjects ermModuleObjects = new ErmModuleObjects();
        ApplicationFixtures applicationFixtures = new ApplicationFixtures();
        MailManagementObjects mailManagementObjects = new MailManagementObjects();
        private int NumberofEmails;
        public int numberofEmails{
            get { return NumberofEmails; }
            set { NumberofEmails = value; }
        }

        private string PinnedQueryText;
        public string pinnedQueryText
        {
            get { return PinnedQueryText; }
            set { PinnedQueryText = value; }
        }

        IWebDriver driver;
        public _013MailManagementStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }

        [When(@"I click the MailBox Management\.")]
        public void WhenIClickTheMailBoxManagement_()
        {
            Console.WriteLine(mailManagementObjects.MailBoxName_);

            seleniumSetMethod.ExplicitWait(element: mailManagementObjects.MailManagementXpath, elementType: ProperType.X_Path, driver: driver);
            seleniumSetMethod.Click(element: mailManagementObjects.MailManagementXpath, elementType: ProperType.X_Path, driver: driver);
        }

        [When(@"I click the desired mail box and (.*) folders will appear\.")]
        public void WhenIClickTheDesiredMailBoxAndFoldersWillAppear_(int p0)
        {
            driver.SwitchTo().Frame(0);
            Console.WriteLine(mailManagementObjects.MailBoxXpath);
            seleniumSetMethod.ExplicitWait(element: mailManagementObjects.MailBoxXpath, elementType: ProperType.X_Path, driver: driver);
            seleniumSetMethod.Click(element: mailManagementObjects.MailBoxXpath, elementType: ProperType.X_Path, driver: driver);
            //int elements = driver.FindElements(By.XPath(mailManagementObjects.AllMailBoxesXpath)).Count;
            int elements = seleniumSetMethod.CountMatching(element: mailManagementObjects.AllMailBoxesXpath, elementType: ProperType.X_Path, driver: driver);
            Console.WriteLine(elements);
            Assert.AreEqual(p0, elements);
            driver.SwitchTo().DefaultContent();
        }

        [When(@"I noted the number of emails present in Waiting folder\.")]
        public void WhenINotedTheNumberOfEmailsPresentInWaitingFolder_()
        {
            driver.SwitchTo().Frame(0);
            seleniumSetMethod.ExplicitWait(element: mailManagementObjects.WaitingFolderXpath, elementType: ProperType.X_Path, driver: driver);
            seleniumSetMethod.Click(element: mailManagementObjects.WaitingFolderXpath, elementType: ProperType.X_Path, driver: driver);
            Thread.Sleep(5000);
          

            string waiting_folder_txt_ = seleniumSetMethod.GetText(element: mailManagementObjects.WaitingFolderXpath, elementType: ProperType.X_Path, driver: driver);
            
            // regex method to Find integers matches
            string pattern = @"\d+";
           
            MatchCollection matches = Regex.Matches(waiting_folder_txt_, pattern);
            
            // Print the matches
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
                numberofEmails = int.Parse(match.Value);

            }
            Console.WriteLine(numberofEmails);
            Console.WriteLine(NumberofEmails);
            driver.SwitchTo().DefaultContent();

            
        }

        [Then(@"I noticed that toal number of emails in Waiting folder is increased by (.*)\.")]
        public void ThenINoticedThatToalNumberOfEmailsInWaitingFolderIsIncreasedBy_(int p0)
        {
            //clicking on waiting folder x path
            driver.SwitchTo().Frame(0);
            seleniumSetMethod.ExplicitWait(element: mailManagementObjects.WaitingFolderXpath, elementType: ProperType.X_Path, driver: driver);
            seleniumSetMethod.Click(element: mailManagementObjects.WaitingFolderXpath, elementType: ProperType.X_Path, driver: driver);
            Thread.Sleep(12000);

            //refreshing the page, 
            driver.Navigate().Refresh();
            //clicking the mail box
            driver.SwitchTo().Frame(0);
            seleniumSetMethod.ExplicitWait(element: mailManagementObjects.MailBoxXpath, elementType: ProperType.X_Path, driver: driver);
            seleniumSetMethod.Click(element: mailManagementObjects.MailBoxXpath, elementType: ProperType.X_Path, driver: driver);
            Thread.Sleep(10000);

            //waiting till the count increased by 1 
            int NextEmailCount = NumberofEmails + 1; 
            string completeWaitingFolderXpath = String.Format(mailManagementObjects.CompleteWaitingFolderXpath, NextEmailCount.ToString());
            Console.WriteLine(completeWaitingFolderXpath);
            seleniumSetMethod.ExplicitWait(element: completeWaitingFolderXpath, elementType: ProperType.X_Path, driver: driver);



            string waiting_folder_txt_ = seleniumSetMethod.GetText(element: completeWaitingFolderXpath, elementType: ProperType.X_Path, driver: driver);
            string pattern = @"\d+";

            // Find matches
            MatchCollection matches = Regex.Matches(waiting_folder_txt_, pattern);
            int new_email_count= 0;
            // Print the matches
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
                new_email_count = int.Parse(match.Value);

            }
            Console.WriteLine(new_email_count);
            Console.WriteLine(NumberofEmails);
            Assert.AreEqual(NumberofEmails + 1, new_email_count);
            driver.SwitchTo().DefaultContent();
        }

        [When(@"I search '([^']*)' in Filter input bar\.")]
        public void WhenISearchInFilterInputBar_(string p0)
        {
            driver.SwitchTo().Frame(0);
            Console.WriteLine(p0);
            Thread.Sleep(15000);
            seleniumSetMethod.ExplicitWait(element: mailManagementObjects.InputQuerySearchBarXpath, elementType: ProperType.X_Path, driver: driver);
            seleniumSetMethod.EnterText(element: mailManagementObjects.InputQuerySearchBarXpath, elementType: ProperType.X_Path, driver: driver, value: p0);
            //string InputValue = "";
            //bool StringMentioned = true;

            //while (StringMentioned)
            //{
                
            //        seleniumSetMethod.ExplicitWait(element: mailManagementObjects.InputQuerySearchBarXpath, elementType: ProperType.X_Path, driver: driver);
            //        seleniumSetMethod.EnterText(element: mailManagementObjects.InputQuerySearchBarXpath, elementType: ProperType.X_Path, driver: driver, value: p0);
            //        InputValue = driver.FindElement(By.XPath(mailManagementObjects.InputQuerySearchBarXpath)).GetAttribute("value");
            //        Console.WriteLine($"Attribute value is {InputValue}");
            //        if (InputValue==p0) { StringMentioned = false; }

            //}
           

            bool ErrorOccured = true;
            while (ErrorOccured)
            {
                try 
                {
                    seleniumSetMethod.ExplicitWait(element: mailManagementObjects.SearchButtonXpath, elementType: ProperType.X_Path, driver: driver);
                    seleniumSetMethod.Click(element: mailManagementObjects.SearchButtonXpath, elementType: ProperType.X_Path, driver: driver);
                    ErrorOccured = false;
                }

                catch(Exception ex)  
                {
                    Console.WriteLine($"Error Occured {ex.Message}");
                }
            }
            
            Thread.Sleep(5000);
            driver.SwitchTo().DefaultContent() ;
        }

        [When(@"I find that the first searched email has '([^']*)' in its subject")]
        public void WhenIFindThatTheFirstSearchedEmailHasInItsSubject(string queue)
        {
            driver.SwitchTo().Frame(0);
            seleniumSetMethod.ExplicitWait(element: mailManagementObjects.EmailSubjectStringXpath, elementType: ProperType.X_Path, driver: driver);
            string text = seleniumSetMethod.GetText(element: mailManagementObjects.EmailSubjectStringXpath, elementType: ProperType.X_Path, driver: driver);
            Console.WriteLine(text);
            Assert.That(text, Does.Contain(queue));
            driver.SwitchTo().DefaultContent();

        }

        //[When(@"I found the searched query in the Search Query list\.")]
        //public void WhenIFoundTheSearchedQueryInTheSearchQueryList_()
        //{
        //    throw new PendingStepException();
        //}

        [When(@"I search '([^']*)' in Filter input bar for (.*) times\.")]
        public void WhenISearchInFilterInputBarForTimes_(string p0, int p1)
        {
            for (int i = 0; i <= p1; i++)
            {
                driver.SwitchTo().Frame(0);
                Console.WriteLine(p0);
                if (i < 1)
                {
                    Thread.Sleep(15000);
                }
                seleniumSetMethod.ExplicitWait(element: mailManagementObjects.InputQuerySearchBarXpath, elementType: ProperType.X_Path, driver: driver);
                seleniumSetMethod.EnterText(element: mailManagementObjects.InputQuerySearchBarXpath, elementType: ProperType.X_Path, driver: driver, value: p0);
                //string InputValue = "";
                //bool StringMentioned = true;

                //while (StringMentioned)
                //{

                //        seleniumSetMethod.ExplicitWait(element: mailManagementObjects.InputQuerySearchBarXpath, elementType: ProperType.X_Path, driver: driver);
                //        seleniumSetMethod.EnterText(element: mailManagementObjects.InputQuerySearchBarXpath, elementType: ProperType.X_Path, driver: driver, value: p0);
                //        InputValue = driver.FindElement(By.XPath(mailManagementObjects.InputQuerySearchBarXpath)).GetAttribute("value");
                //        Console.WriteLine($"Attribute value is {InputValue}");
                //        if (InputValue==p0) { StringMentioned = false; }

                //}


                bool ErrorOccured = true;
                while (ErrorOccured)
                {
                    try
                    {
                        seleniumSetMethod.ExplicitWait(element: mailManagementObjects.SearchButtonXpath, elementType: ProperType.X_Path, driver: driver);
                        seleniumSetMethod.Click(element: mailManagementObjects.SearchButtonXpath, elementType: ProperType.X_Path, driver: driver);
                        ErrorOccured = false;
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error Occured {ex.Message}");
                    }
                }

                Thread.Sleep(5000);
                driver.SwitchTo().DefaultContent();
            }
        }


        [When(@"I find that there are total (.*) queries in the list\.")]
        public void WhenIFindThatThereAreTotalQueriesInTheList_(int p0)
        {
            driver.SwitchTo().Frame(0);
            int elements = seleniumSetMethod.CountMatching(element: mailManagementObjects.AllQueriesXpath, elementType: ProperType.X_Path, driver: driver);
            Console.WriteLine(elements);
            Assert.IsTrue(elements == 10 );
            driver.SwitchTo().DefaultContent();
        }

        [When(@"I pinned one of the queries\.")]
        public void WhenIPinnedOneOfTheQueries_()
        {
            //TO get text
            //  (//span[contains(text(),"Query")])[1]
            
            // to pin the first query
            // (//span[contains(text(),"Query")]/following-sibling::span)[1]

            driver.SwitchTo().Frame(0);
            seleniumSetMethod.Click(element: "(//span[contains(text(),\"Query\")]/following-sibling::span)[1]", elementType: ProperType.X_Path, driver: driver);
            PinnedQueryText = seleniumSetMethod.GetText(element: "(//span[contains(text(),\"Query\")])[1]", elementType: ProperType.X_Path, driver: driver);
            Console.WriteLine(PinnedQueryText);
            driver.SwitchTo().DefaultContent();



        }

        [When(@"I find that the pinned query is not removed\.")]
        public void WhenIFindThatThePinnedQueryIsNotRemoved_()
        {
            driver.SwitchTo().Frame(0);
            string text = seleniumSetMethod.GetText(element: "(//span[contains(text(),\"Query\")])[1]", elementType: ProperType.X_Path, driver: driver);
            Console.WriteLine(text);
            Assert.AreEqual(text, PinnedQueryText);
            driver.SwitchTo().DefaultContent();
        }

        //[When(@"I click on the Waiting folder\.")]
        //public void WhenIClickOnTheWaitingFolder_()
        //{
        //    throw new PendingStepException();
        //}

        //[When(@"I right click on the email\.")]
        //public void WhenIRightClickOnTheEmail_()
        //{
        //    throw new PendingStepException();
        //}

        //[When(@"I hover over and move to handled/deleted/span folder\.")]
        //public void WhenIHoverOverAndMoveToHandledDeletedSpanFolder_()
        //{
        //    throw new PendingStepException();
        //}

        //[When(@"I check in the handled/deleted/span folder that moved email is in the folder\.")]
        //public void WhenICheckInTheHandledDeletedSpanFolderThatMovedEmailIsInTheFolder_()
        //{
        //    throw new PendingStepException();
        //}

        //[When(@"I enter the name of queue with a new name\.")]
        //public void WhenIEnterTheNameOfQueueWithANewName_()
        //{
        //    throw new PendingStepException();
        //}

        //[When(@"I select Move to Folder in Select Action drop down\.")]
        //public void WhenISelectMoveToFolderInSelectActionDropDown_()
        //{
        //    throw new PendingStepException();
        //}

        //[When(@"I select new in Folder drop down\.")]
        //public void WhenISelectNewInFolderDropDown_()
        //{
        //    throw new PendingStepException();
        //}

        //[Given(@"I find the sent email in the new folder\.")]
        //public void GivenIFindTheSentEmailInTheNewFolder_()
        //{
        //    throw new PendingStepException();
        //}
    }
}
