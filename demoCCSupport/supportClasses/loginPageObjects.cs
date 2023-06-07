using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoCCSupport.supportClasses
{
      class loginPageObjects
    {

        public string url = "http://pkrd-aim-vcc.vcc.bel.rd.eilab.biz/VccWebCenter/Login.aspx";
        public string UsernameInputbarId = "txtUsername";
        public string PasswordInputbarId = "txtPassword";
        public string Username = "superadmin";
        public string Password = "superadmin";
        public string SubmitButtonXpath = "//*[@id=\"lbtLoginSubmit\"]/span";
       
    }
    class HomePageObjects
    {
        public string UsernameId = "menuHeaderUser";
        public string CCSupportXPath = "(//a[@title=\"CCSUPPORT\"])[2]";
        public string AgentId = "tblVccGrid_row2_username";
    }
    class  CCSuportModuleObjects
    {
        public string url = "http://pkrd-aim-vcc.vcc.bel.rd.eilab.biz/VccWebCenter/?instanceID=76cf08c6-f261-4202-a96b-0c07b4254aca&uc=Users";
        public string AddNewUserButtonId = "btnNew";
        public string UsernameInputbarId = "txtUsername";
        public string EmailInputbarId = "txtEmail";
        public string ProfileTabId = "ui-id-12";
        public string ProfileTabXPath = "(//a[contains(text(),'Profiles')])[2]";
        public string Username = "Dummy Agent2";
        public string Email = "Dummyagent2@grr.la";
        public string ProfileTabOkButtonID = "btnSave";
        public string UserReactivationButtonXpath = "(//button/span[contains(text(),'Ok')])[3]";
        public string ListOfAgentsXpath = "//tbody[@id='tblVccGrid_body']/tr";
        public string AddedAgentXpath = "//a[@title='Delete ']";
        public string DeletingOkButtonXpath = "(//button/span[contains(text(),'Ok')])[3]";
    }

}
