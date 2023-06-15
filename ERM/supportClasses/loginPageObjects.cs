using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERM.supportClasses
{
    class loginPageObjects
    {

        public string url = "http://pkrd-aim-vcc.vcc.bel.rd.eilab.biz/VccWebCenter/Login.aspx";
        public string UsernameInputbarId = "txtUsername";
        public string PasswordInputbarId = "txtPassword";
        public string Username = "superadmin";
        public string Password = "superadmin";
        public string WrongPassword = "super";
        public string SubmitButtonXpath = "//*[@id=\"lbtLoginSubmit\"]/span";
        public string ErrorMsgId = "ui-id-1";
        //arbaz VM
        //public string url = "http://pkrd-akh-vcct1.vcc.bel.rd.eilab.biz/VccWebCenter/Login.aspx";


    }
    class HomePageObjects
    {
        public string UsernameId = "menuHeaderUser";
        public string CCSupportXPath = "(//a[@title=\"CCSUPPORT\"])[2]";
        public string AgentId = "tblVccGrid_row2_username";
        public string UsernameToBe = "Super Admin";
        //arbaz VM
        //public string CCSupportXPath = "(//a[@title=\"CC\"])[2]";
    }
    class CCSuportModuleObjects
    {
        public string url = "http://pkrd-aim-vcc.vcc.bel.rd.eilab.biz/VccWebCenter/?instanceID=76cf08c6-f261-4202-a96b-0c07b4254aca&uc=Users";
        public string AddNewUserButtonId = "btnNew";
        public string AddNewUserButtonXpath = "//div[@id=\"divGrid\"]/a[@role=\"button\"]/span[@class=\"icon\"]";
        public string AddNewQueueButtonXpath = "//div[@id=\"divGrid\"]/a[@role=\"button\"]/span[@class=\"icon\"]";
        public string UsernameInputbarId = "txtUsername";
        public string EmailInputbarId = "txtEmail";
        public string ProfileTabId = "ui-id-12";
        public string ProfileTabXPath = "(//a[contains(text(),'Profiles')])[2]";
        public string QueueTabXPath = "(//a[contains(text(),'Queues')])[2]";
        public string Username = "Dummy Agent1";
        public string Email = "Dummyagent1@grr.la";
        public string ProfileTabOkButtonID = "btnSave";
        public string UserReactivationButtonXpath = "(//button/span[contains(text(),'Ok')])[3]";
        public string ListOfAgentsXpath = "//tbody[@id='tblVccGrid_body']/tr";
        public string AddedAgentXpath = "//a[@title='Delete ']";
        public string DeletingOkButtonXpath = "(//button/span[contains(text(),'Ok')])[3]";
        public string QueueModuleId = "CC_01_Queues";
        public string AddNewQueueId = "lblBtnNew";
        public string AddNewQueueXpath = "//span[@id=\"lblBtnNew\"]";
        public string QueueNameInputbarId = "txtName";
        public string DefaultQueueCheckboxId = "ckbDefault";
        public string DefaultQueueCheckboxXpath = "(//label[@for=\"ckbDefault\"])[2]";
        public string QueueProfileTabId = "ui-id-10";
        public string QueueVoxtronAgentCheckBoxId = "ckbProfile1";
        public string QueueProfileOkButtonId = "btnSave";
        public string QueueVoxtronAgentCheckBoxXpath = "(//label[@for=\"ckbProfile1\"])";
        public string QueueName1 = "Default Dummy Queue";
        public string QueueDelOkButtonXpath = "(//button/span[contains(text(),'Ok')])[6]";
        public string QueueListXpath = "//tbody[@id='tblVccGrid_body']/tr";
        public string QueueUrl = "http://pkrd-aim-vcc.vcc.bel.rd.eilab.biz/VccWebCenter/?instanceID=76cf08c6-f261-4202-a96b-0c07b4254aca&uc=Queues";
        public string QueueAlreadyPresentOkXpath = "(//span[contains(text(),'Ok')])[6]";
        public string QueueSelectedRadioButtonXpath = "(//td[contains(text(),\"{0}\")]/parent::tr/td)[2]/div/label[@for=\"ckbQueueSelected7_InteractionID7_UserID6\"]";
        public string QueueChangedRadioButtonXpath = "(//td[contains(text(),\"{0}\")]/parent::tr/td)[3]/div/label[@for=\"ckbQueueChange8_InteractionID7_UserID6\"]";
        public string QueuePageOkButtonId = "btnSave";
        public string AgentNameSuffixIdPart = "_username";
        public string AgentEditSuffixIdPart = "_edit";
        public List<string> QueueNamesList = new List<string> { "Dummy Queue1", "Dummy Queue2" };

        //arbaz VM
        //public string url = "http://pkrd-akh-vcct1.vcc.bel.rd.eilab.biz/VccWebCenter/?instanceID=20fcce3b-d8c3-41f8-a62b-531b79189c22&uc=Users";
        //public string QueueSelectedRadioButtonXpath = "(//td[contains(text(),\"{0}\")]/parent::tr/td)[2]/div/label";
        //public string QueueChangedRadioButtonXpath = "(//td[contains(text(),\"{0}\")]/parent::tr/td)[3]/div/label";
    }

    class WebClientLoginPageObjects
    {
        public string url = "http://pkrd-aim-vcc.vcc.bel.rd.eilab.biz/webclient/";
        public string UsernameInputbarId = "txtUsername";
        public string OkButtonXpath = "//input[@id=\"btnOK\"]";
        public string OkButtonOnNextPageXpath = "(//input[@class=\"btn btn-text btn-default\"])[2]";
        public string NoInteractionYesXpath = "(//input[@value=\"Yes\"])[2]";
        public string ErrorTextXpath = "//h1[@class=\"error\"]/span";
        public string SettingId = "btnSettings";
        public string SettingHeadingId = "ui-id-6";
        public string LanguageDropDownXpath = "//div[@class=\"comboboxMenuContent\"]/ul[@role=\"listbox\"]/li/span[contains(text(),'{0}')]";
        public string LanguageTableXpath = "(//div[@role='combobox'])[2]";
        public string LanguageDropDownOkButtonId = "btnLoginSettingsOK";
        public string HomePageHeadingId = "ui-id-4";
        public string UsernameTextXpath = "//div/label[@for=\"txtUsername\"]";
        public string QueueSelctedXpath = "//div[@aria-disabled=\"true\"]/div/span[contains(text(),\"{0}\")]";
        public string QueueChangedXpath = "//div[@aria-disabled=\"false\"]/div/span[contains(text(),\"{0}\")]";
        public string AlreadyLoggedButtonId = "btnAlreadyLoggedInOK";
        //arbaz VM
        //public string url = "http://pkrd-akh-vcct1.vcc.bel.rd.eilab.biz/webclient/";
    }

}
