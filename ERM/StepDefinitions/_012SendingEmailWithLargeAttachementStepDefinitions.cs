using ERM.supportClasses;
using OpenQA.Selenium;
using System;
using System.Net.Mail;
using System.Net;
using TechTalk.SpecFlow;
using ConsoleApp1;
using NUnit.Framework;
using AngleSharp.Io;

namespace ERM.StepDefinitions
{
    [Binding]
    public class _012SendingEmailWithLargeAttachementStepDefinitions
    {
        loginPageObjects loginObjects = new loginPageObjects();
        HomePageObjects homePageObjects = new HomePageObjects();
        CCSuportModuleObjects ccSupportModuleObject = new CCSuportModuleObjects();
        WebClientLoginPageObjects webClientLoginPageObjects = new WebClientLoginPageObjects();
        ErmModuleObjects ermModuleObjects = new ErmModuleObjects();
        ApplicationFixtures applicationFixtures = new ApplicationFixtures();
        IWebDriver driver;

        //public void GivenISendEmail(string path)
        //{
        //    MailMessage mail = new MailMessage();
        //    MailMessage.LoadMessage(path)
        //    //string fromMail_ = "customer@voxtron.lab";
        //    MsgReader.Mime.MESSAGE.Load

        //    SmtpClient smtp = new SmtpClient("pkrd-aim-vcc.vcc.bel.rd.eilab.biz", 25);

        //    smtp.UseDefaultCredentials = false;
        //    smtp.EnableSsl = false;
        //    smtp.Credentials = new NetworkCredential(fromMail_, password);
        //    smtp.Send(mail);
        //    Thread.Sleep(10000);
        //}

        [Given(@"I send email from '([^']*)' to '([^']*)' with large attachment\.")]
        public void GivenISendEmailFromToWithLargeAttachment_(string from_, string to_)
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
            attachment = new System.Net.Mail.Attachment("..\\..\\..\\FilesToBeAttachedWithEmail\\largeEmails.zip");
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

        [Then(@"I ensure that email has large attachment with it\.")]
        public void ThenIEnsureThatEmailHasLargeAttachmentWithIt_()
        {
            driver.SwitchTo().Frame(1);
            String text = seleniumSetMethod.GetText(element: webClientLoginPageObjects.EmailAttachmentXpath, elementType: ProperType.X_Path, driver: driver);
            Console.WriteLine(text);
            Assert.AreEqual(text, "largeEmails.zip");
            driver.SwitchTo().DefaultContent();
        }
    }
}
