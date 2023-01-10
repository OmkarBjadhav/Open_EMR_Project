using DocumentFormat.OpenXml.Bibliography;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenEMR.Pages
{
    public  class LoginPage
    {
        private By _usernameLoc = By.Id("authUser");
        private By _passwordLoc = By.Id("clearPass");
        private By _loginLoc = By.Id("login-button");
        private By _dropDownLoc = By.XPath("//select[@class='form-control']");
        private By _errorMsgLoc = By.XPath("//div[contains(text(),'Invalid')]");
       

        private IWebDriver driver;
        public LoginPage(IWebDriver driver ) 
        {
          this.driver= driver;
        
        }

        public void EnterUserName(string username )
        {
            driver.FindElement(_usernameLoc).SendKeys(username);

        }
        public void EnterPassword(string password ) 
        {
          driver.FindElement(_passwordLoc).SendKeys(password);
        }

        public void SelectLanguageFromDropdown()
        {
            SelectElement select = new SelectElement(driver.FindElement(_dropDownLoc));
            select.SelectByText("English (Indian)");

        }

        public void ClickOnLogin()
        {

            driver.FindElement(_loginLoc).Click();
        }


        public string GetInvalidErrorMessage()
        { 
          return driver.FindElement(_errorMsgLoc).Text;
        
        }


        public string GetUserNamePlaceholder()
        {
            return driver.FindElement(_usernameLoc).GetAttribute("placeholder");
        }

        public string GetPasswordPlaceholder()
        {
            return driver.FindElement(_passwordLoc).GetAttribute("placeholder");
        }

    }
}
