using AngleSharp.Dom;
using ConsoleApp1;
using ERM.supportClasses;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Net.Mail;
using System.Net;
using TechTalk.SpecFlow;

namespace ERM.StepDefinitions
{
    [Binding]
    public class _009HandlingMailsStepDefinitions
    {
        loginPageObjects loginObjects = new loginPageObjects();
        HomePageObjects homePageObjects = new HomePageObjects();
        CCSuportModuleObjects ccSupportModuleObject = new CCSuportModuleObjects();
        WebClientLoginPageObjects webClientLoginPageObjects = new WebClientLoginPageObjects();
        ErmModuleObjects ermModuleObjects= new ErmModuleObjects();
        ApplicationFixtures applicationFixtures = new ApplicationFixtures();
        IWebDriver driver;

        public _009HandlingMailsStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }
        [When(@"I click the ERMSupport\.")]
        public void WhenIClickTheERMSupport_()
        {
            seleniumSetMethod.ExplicitWait(element: ermModuleObjects.ErmModuleXpath, elementType: ProperType.X_Path, driver: driver);
            seleniumSetMethod.Click(element: ermModuleObjects.ErmModuleXpath, elementType: ProperType.X_Path, driver: driver);
        }

        [When(@"I click on the mailboxes\.")]
        public void WhenIClickOnTheMailboxes_()
        {
            seleniumSetMethod.ExplicitWait(element: ermModuleObjects.MailBoxesTabId, elementType: ProperType.Id, driver: driver);
            seleniumSetMethod.Click(element: ermModuleObjects.MailBoxesTabId, elementType: ProperType.Id, driver: driver);

        }

        //[When(@"I click on the edit button of support\.")]
        //public void WhenIClickOnTheEditButtonOfSupport_()
        //{
        //    string url = driver.Url;
        //    applicationFixtures.EditRow(allListFinderElement: ccSupportModuleObject.QueueListXpath, driver: driver, nameSuffixIdPart: "_name", nameToEditRow: p0, editSuffixIdPart: ccSupportModuleObject.AgentEditSuffixIdPart, url: url);

        //}
        //[When(@"I click on the edit button of ""([^""]*)""\.")]
        [When(@"I click on the edit button of mailbox.")]
        public void WhenIClickOnTheEditButtonOf_()
        {

            string url = driver.Url;
            //applicationFixtures.EditRow(allListFinderElement: ccSupportModuleObject.QueueListXpath, driver: driver, nameSuffixIdPart: "_name", nameToEditRow: support, editSuffixIdPart: ccSupportModuleObject.AgentEditSuffixIdPart, url: url);
           
            applicationFixtures.EditRow(allListFinderElement: ccSupportModuleObject.QueueListXpath, driver: driver, nameSuffixIdPart: "_name", nameToEditRow: ermModuleObjects.MailBoxName, editSuffixIdPart: ccSupportModuleObject.AgentEditSuffixIdPart, url: url);

        }


        [When(@"I click on the Routing Routes\.")]
        public void WhenIClickOnTheRoutingRoutes_()
        {
            seleniumSetMethod.ExplicitWait(element: ermModuleObjects.RoutingRulesTabId, elementType: ProperType.Id, driver: driver);
            seleniumSetMethod.Click(element: ermModuleObjects.RoutingRulesTabId, elementType: ProperType.Id, driver: driver);

        }

        [When(@"I click on the Add New Rules button\.")]
        public void WhenIClickOnTheAddNewRulesButton_()
        {
            seleniumSetMethod.ExplicitWait(element: ermModuleObjects.AddNewRulesXpath, elementType: ProperType.X_Path, driver: driver);
            seleniumSetMethod.Click(element: ermModuleObjects.AddNewRulesXpath, elementType: ProperType.X_Path, driver: driver);

        }

        [When(@"I enter the name of queue\.")]
        public void WhenIEnterTheNameOfQueue_()
        {
            seleniumSetMethod.ExplicitWait(element: ermModuleObjects.AddNewRuleInpNameId, elementType: ProperType.Id, driver: driver);
            seleniumSetMethod.EnterText(element: ermModuleObjects.AddNewRuleInpNameId, elementType: ProperType.Id, driver: driver, value: ccSupportModuleObject.QueueNamesList[1]);
        }

        [When(@"I click the Next button of Add New Rule pop up\.")]
        public void WhenIClickTheNextButtonOfAddNewRulePopUp_()
        {
            seleniumSetMethod.ExplicitWait(element: ermModuleObjects.GenPropNextBtnXpath, elementType: ProperType.X_Path, driver: driver);
            seleniumSetMethod.Click(element: ermModuleObjects.GenPropNextBtnXpath, elementType: ProperType.X_Path, driver: driver);

        }

        [When(@"I check Apply New Emails\.")]
        public void WhenICheckApplyNewEmails_()
        {
            seleniumSetMethod.ExplicitWait(element: ermModuleObjects.ApplyNewEmailChkBoxXpath, elementType: ProperType.X_Path, driver: driver);
            seleniumSetMethod.CheckRadioBtn(element: ermModuleObjects.ApplyNewEmailChkBoxXpath, elementType: ProperType.X_Path, driver: driver);

        }
        [When(@"I click the Next button of folder window of pop up\.")]
        public void WhenIClickTheNextButtonOfFolderWindowOfPopUp_()
        {
            seleniumSetMethod.ExplicitWait(element: ermModuleObjects.FolderPopUpNextBtnXpath, elementType: ProperType.X_Path, driver: driver);
            seleniumSetMethod.Click(element: ermModuleObjects.FolderPopUpNextBtnXpath, elementType: ProperType.X_Path, driver: driver);

        }


        [When(@"I click on the Add Condition\.")]
        public void WhenIClickOnTheAddCondition_()
        {
            seleniumSetMethod.ExplicitWait(element: ermModuleObjects.AddNewConditionBtnXpath, elementType: ProperType.X_Path, driver: driver);
            seleniumSetMethod.Click(element: ermModuleObjects.AddNewConditionBtnXpath, elementType: ProperType.X_Path, driver: driver);

        }

        [When(@"I select subject in first drop down\.")]
        public void WhenISelectSubjectInFirstDropDown_()
        {
            seleniumSetMethod.ExplicitWait(element: ermModuleObjects.AddCndtnFrstDrpDwnXpath, elementType: ProperType.X_Path, driver: driver);
            seleniumSetMethod.SelectDropDown(element: ermModuleObjects.AddCndtnFrstDrpDwnXpath, dropDownText: ermModuleObjects.OptionSubjectText, elementType: ProperType.X_Path, driver: driver);
            
        }

        [When(@"I select contains in second drop down\.")]
        public void WhenISelectContainsInSecondDropDown_()
        {
            seleniumSetMethod.ExplicitWait(element: ermModuleObjects.AddCndtnScndDrpDwnXpath, elementType: ProperType.X_Path, driver: driver);
            seleniumSetMethod.SelectDropDown(element: ermModuleObjects.AddCndtnScndDrpDwnXpath, dropDownText: ermModuleObjects.OptionContainsText, elementType: ProperType.X_Path, driver: driver);

        }

        [When(@"I enter ""([^""]*)"" in the input bar\.")]
        public void WhenIEnterInTheInputBar_(string p0)
        {

            seleniumSetMethod.ExplicitWait(element: ermModuleObjects.AddCndtnPopUpInputBarId, elementType: ProperType.Id, driver: driver);
            seleniumSetMethod.EnterText(element: ermModuleObjects.AddCndtnPopUpInputBarId, value: p0, elementType: ProperType.Id, driver: driver);

        }

        [When(@"I click the ok button of Add Condition page of Add New Rule pop up\.")]
        public void WhenIClickTheOkButtonOfAddNewRulePopUp_()
        {
            seleniumSetMethod.ExplicitWait(element: ermModuleObjects.AddCndtnOkBtnXpath, elementType: ProperType.X_Path, driver: driver);
            seleniumSetMethod.Click(element: ermModuleObjects.AddCndtnOkBtnXpath, elementType: ProperType.X_Path, driver: driver);

        }
        [When(@"I click the Next button on Condition window of Add New Rule pop up\.")]
        public void WhenIClickTheNextButtonOnConditionWindowOfAddNewRulePopUp_()
        {
            seleniumSetMethod.ExplicitWait(element: ermModuleObjects.ConditionWindowNextBtnXpath, elementType: ProperType.X_Path, driver: driver);
            seleniumSetMethod.Click(element: ermModuleObjects.ConditionWindowNextBtnXpath, elementType: ProperType.X_Path, driver: driver);
        }

        [When(@"I click add action button\.")]
        public void WhenIClickAddActionButton_()
        {
            seleniumSetMethod.ExplicitWait(element: ermModuleObjects.AddActionBtnOnActionPopUpXpath, elementType: ProperType.X_Path, driver: driver);
            seleniumSetMethod.Click(element: ermModuleObjects.AddActionBtnOnActionPopUpXpath, elementType: ProperType.X_Path, driver: driver);

        }

        [When(@"I select Assign to queue in Select Action drop down\.")]
        public void WhenISelectAssignToQueueInSelectActionDropDown_()
        {
            seleniumSetMethod.ExplicitWait(element: ermModuleObjects.SelectActionDropDownXpath, elementType: ProperType.X_Path, driver: driver);
            seleniumSetMethod.SelectDropDown(element: ermModuleObjects.SelectActionDropDownXpath, dropDownText: ermModuleObjects.OptionAssignQText, elementType: ProperType.X_Path, driver: driver);

        }

        [When(@"I select Dummy Queue(.*) in Queue drop down\.")]
        public void WhenISelectDummyQueueInQueueDropDown_(int p0)
        {
            //Thread.Sleep(4000);
            seleniumSetMethod.ExplicitWait(element: ermModuleObjects.QueueDropDownId, elementType: ProperType.Id, driver: driver);
            seleniumSetMethod.SelectDropDown(element: ermModuleObjects.QueueDropDownId, dropDownText: ccSupportModuleObject.QueueNamesList[1], elementType: ProperType.Id, driver: driver);

        }
        [When(@"I click the ok button of Add Action window of Add New Rule pop up\.")]
        public void WhenIClickTheOkButtonOfAddActionWindowOfAddNewRulePopUp_()
        {
            Thread.Sleep(4000);
            seleniumSetMethod.ExplicitWait(element: ermModuleObjects.AddActionOkBtnXpath, elementType: ProperType.X_Path, driver: driver);
            seleniumSetMethod.Click(element: ermModuleObjects.AddActionOkBtnXpath, elementType: ProperType.X_Path, driver: driver);
            
        }

        [When(@"I click the Update button of Add New Rule pop up\.")]
        public void WhenIClickTheUpdateButtonOfAddNewRulePopUp_()
        {
            seleniumSetMethod.ExplicitWait(element: ermModuleObjects.ActionPopUpNextBtnXpath, elementType: ProperType.X_Path, driver: driver);
            seleniumSetMethod.Click(element: ermModuleObjects.ActionPopUpNextBtnXpath, elementType: ProperType.X_Path, driver: driver);
            seleniumSetMethod.ExplicitWait(element: ermModuleObjects.RoutingRulesOkBtnId, elementType: ProperType.Id, driver: driver);
            seleniumSetMethod.Click(element: ermModuleObjects.RoutingRulesOkBtnId, elementType: ProperType.Id, driver: driver);
            Thread.Sleep(4000);

        }

        [When(@"I click on the Skills Tab\.")]
        public void WhenIClickOnTheSkillsTab_()
        {
            seleniumSetMethod.ExplicitWait(element: ccSupportModuleObject.SkillsTabId, elementType: ProperType.Id, driver: driver);
            seleniumSetMethod.Click(element: ccSupportModuleObject.SkillsTabId, elementType: ProperType.Id, driver: driver);

        }

        [When(@"I ckeck the Support check box\.")]
        public void WhenICkeckTheSupportCheckBox_()
        {
            seleniumSetMethod.ExplicitWait(element: ccSupportModuleObject.SupportChkBoxSkilPageXpath, elementType: ProperType.X_Path, driver: driver);
            seleniumSetMethod.CheckRadioBtn(element: ccSupportModuleObject.SupportChkBoxSkilPageXpath, elementType: ProperType.X_Path, driver: driver);
        }

        [When(@"I check the '([^']*)' option for '([^']*)' for Inbound e-mails\.")]
        public void WhenICheckTheOptionForForInboundE_Mails_(string option, string Q)
        {
            if (option=="selected" && Q == "Q2")
            {
                //string Xpath_Selected_Row = string.Format(ccSupportModuleObject.QueueInboundEmailSelectedXpath, ccSupportModuleObject.QueueNamesList[1]);
                //Console.WriteLine(Xpath_Selected_Row);
                //seleniumSetMethod.Click(element: Xpath_Selected_Row, elementType: ProperType.X_Path, driver: driver);
                //ckbQueueSelected8_InteractionID3_UserID6
                seleniumSetMethod.Click(element: ccSupportModuleObject.QueueInboundEmailSelectedXpath, elementType: ProperType.X_Path, driver: driver);
            }
        }

        [When(@"I check the Voxtron Agent radio button\.")]
        public void WhenICheckTheVoxtronAgentRadioButton_()
        {
            seleniumSetMethod.ExplicitWait(element: ccSupportModuleObject.VoxAgentChkBoxXpath, elementType: ProperType.X_Path, driver: driver);
            seleniumSetMethod.CheckRadioBtn(element: ccSupportModuleObject.VoxAgentChkBoxXpath, elementType: ProperType.X_Path, driver: driver);

        }

        [When(@"I click the OK button\.")]
        public void WhenIClickTheOKButton_()
        {
            throw new PendingStepException();
        }

        [Given(@"I send email from '([^']*)' to '([^']*)'\.")]
        public void GivenISendEmailFromTo_(string from_, string to_)
        {
            

            MailMessage mail = new MailMessage();
            //string fromMail_ = "customer@voxtron.lab";
            string fromMail_ = from_;
            //string toMail_ = "support@voxtron.lab";
            string toMail_ = to_;
            string password = "diadora.2";
            //string password = "";
            string subject = "queue2 " + DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            string body = "<h3> From VS </h3>";


            mail.From = new MailAddress(fromMail_);
            mail.To.Add(toMail_);
            mail.Subject = subject; 
            mail.Body = body;
            mail.IsBodyHtml= true;

            SmtpClient smtp = new SmtpClient("pkrd-aim-vcc.vcc.bel.rd.eilab.biz",25);
            //SmtpClient smtp = new SmtpClient("smtp.gmail.com",587);
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = false;
            smtp.Credentials = new NetworkCredential(fromMail_,password);
            smtp.Send(mail);
            Thread.Sleep(10000);
        }
        [Given(@"I send email from customer to client\.")]
        public void GivenISendEmailFromTo_()
        {


            MailMessage mail = new MailMessage();
            //string fromMail_ = "customer@voxtron.lab";
            string fromMail_ = ermModuleObjects.CustomertEmailAddress;
            //string toMail_ = "support@voxtron.lab";
            string toMail_ = ermModuleObjects.ClientEmailAddress;
            string password = "diadora.2";
            //string password = "jto";
            string subject = "queue2 " + DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            string body = "<h3> From VS </h3>";


            mail.From = new MailAddress(fromMail_);
            mail.To.Add(toMail_);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient("pkrd-aim-vcc.vcc.bel.rd.eilab.biz", 25);
            //SmtpClient smtp = new SmtpClient("BE-JWI-W16-03.vcc.bel.rd.eilab.biz", 587);
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = false;
            smtp.Credentials = new NetworkCredential(fromMail_, password);
            smtp.Send(mail);
            Thread.Sleep(10000);
        }


        [Then(@"I click the Accept button\.")]
        public void ThenIClickTheAcceptButton_()
        {
            Thread.Sleep(7000);
            driver.SwitchTo().Frame(0);
            seleniumSetMethod.ExplicitWait(element: webClientLoginPageObjects.AcceptEmailBtnXpath, elementType: ProperType.X_Path, driver: driver);
            //seleniumSetMethod.Click(element: "//div[@id=\"divContent\"]/div[@id=\"divContactInformation\"]/div[4]/div/input[1]", elementType: ProperType.X_Path, driver: driver);
            seleniumSetMethod.Click(element: webClientLoginPageObjects.AcceptEmailBtnXpath, elementType: ProperType.X_Path, driver: driver);
            //string tt = seleniumSetMethod.GetText(element: "//div[@id=\"divContent\"]/div[@id=\"divContactInformation\"]/div[1]/h1", elementType: ProperType.X_Path, driver: driver);
            //Console.WriteLine(tt);
            driver.SwitchTo().DefaultContent();
            Thread.Sleep(10000);
        }

        [Then(@"I click on the Mark As Handled button\.")]
        public void ThenIClickOnTheMarkAsHandledButton_()
        {
            Thread.Sleep(40000);
            
            driver.SwitchTo().Frame(1);
            seleniumSetMethod.Click(element: webClientLoginPageObjects.MarkAsHandledBtnXpath, elementType: ProperType.X_Path, driver: driver);
            //seleniumSetMethod.Click(element: "//*[@id=\"divInteraction\"]/div[1]/input[5]", elementType: ProperType.X_Path, driver: driver);
            


        }

        [Then(@"I enter comments '([^']*)' in the Remarks input bar\.")]
        public void ThenIEnterCommentsInTheRemarksInputBar_(string comment)
        {
            seleniumSetMethod.EnterText(element: webClientLoginPageObjects.RemarkInputBarId, elementType: ProperType.Id, driver: driver,value:comment );
        }


        [Then(@"I click on commit button to handle the email\.")]
        public void ThenIClickOnCommitButtonToHandleTheEmail_()
        {
            seleniumSetMethod.Click(element: webClientLoginPageObjects.EmailHandledCommitBtnXpath, elementType: ProperType.X_Path, driver: driver);
            driver.SwitchTo().DefaultContent();
        }


        [Then(@"I click on the Delete button\.")]
        public void ThenIClickOnTheDeleteButton_()
        {
            Thread.Sleep(40000);
            driver.SwitchTo().Frame(1);
            seleniumSetMethod.Click(element: webClientLoginPageObjects.EmailDelBtnXpath, elementType: ProperType.X_Path, driver: driver);
            
        }
        [Then(@"I click on commit button to del the email\.")]
        public void ThenIClickOnCommitButtonToDelTheEmail_()
        {
            seleniumSetMethod.Click(element: webClientLoginPageObjects.EmailDelCommitBtnXpath, elementType: ProperType.X_Path, driver: driver);
            driver.SwitchTo().DefaultContent();
        }

        [Then(@"I enter customer@voxtron\.lab' in To input bar\.")]
        public void ThenIEnterCustomerVoxtron_LabInToInputBar_()
        {
            throw new PendingStepException();
        }

        [Then(@"I add attachment\.")]
        public void ThenIAddAttachment_()
        {
            throw new PendingStepException();
        }

        [Then(@"I enter Subject\.")]
        public void ThenIEnterSubject_()
        {
            throw new PendingStepException();
        }

        [Then(@"I enter data in body")]
        public void ThenIEnterDataInBody()
        {
            throw new PendingStepException();
        }

        [Then(@"I click on Add Email\.")]
        public void ThenIClickOnAddEmail_()
        {
            throw new PendingStepException();
        }

        [Then(@"I receive that email with attachment\.")]
        public void ThenIReceiveThatEmailWithAttachment_()
        {
            throw new PendingStepException();
        }

    }
}
