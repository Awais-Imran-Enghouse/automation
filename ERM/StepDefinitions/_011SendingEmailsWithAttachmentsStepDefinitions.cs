using ERM.supportClasses;
using OpenQA.Selenium;
using System;
using System.Net.Mail;
using System.Net;
using TechTalk.SpecFlow;
using ConsoleApp1;
using NUnit.Framework;

namespace ERM.StepDefinitions
{
    [Binding]
    public class _011SendingEmailsWithAttachmentsStepDefinitions
    {
        loginPageObjects loginObjects = new loginPageObjects();
        HomePageObjects homePageObjects = new HomePageObjects();
        CCSuportModuleObjects ccSupportModuleObject = new CCSuportModuleObjects();
        WebClientLoginPageObjects webClientLoginPageObjects = new WebClientLoginPageObjects();
        ErmModuleObjects ermModuleObjects = new ErmModuleObjects();
        ApplicationFixtures applicationFixtures = new ApplicationFixtures();
        IWebDriver driver;

        public _011SendingEmailsWithAttachmentsStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }
        [Given(@"I send email from '([^']*)' to '([^']*)' with attachment\.")]
        public void GivenISendEmailFromToWithAttachment_(string from_, string to_)
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

            System.Net.Mail.Attachment attachment;
            attachment = new System.Net.Mail.Attachment("..\\..\\..\\FilesToBeAttachedWithEmail\\testing.txt");
            mail.Attachments.Add(attachment);
            mail.From = new MailAddress(fromMail_);
            mail.To.Add(toMail_);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient("pkrd-aim-vcc.vcc.bel.rd.eilab.biz", 25);
            
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = false;
            smtp.Credentials = new NetworkCredential(fromMail_, password);
            smtp.Send(mail);
            Thread.Sleep(10000);
        }

        [Then(@"I ensure that email has attachment with it\.")]
        public void ThenIEnsureThatEmailHasAttachmentWithIt_()
        {
            driver.SwitchTo().Frame(1);
            String text = seleniumSetMethod.GetText(element: webClientLoginPageObjects.EmailAttachmentXpath, elementType: ProperType.X_Path, driver: driver);
            Console.WriteLine(text);
            Assert.AreEqual(text, "testing.txt");
            driver.SwitchTo().DefaultContent();
        }

    }
}
