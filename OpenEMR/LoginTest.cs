using DocumentFormat.OpenXml.Bibliography;
using NUnit.Framework;
using OpenEMR.Base;
using OpenEMR.Pages;
using OpenEMR.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenEMR
{
    public class LoginTest : AutomationWrapper
    {
        [Test, TestCaseSource(typeof(DataSource), nameof(DataSource.ValidLoginTest))]
        public void ValidLoginTest(string username, string password)
        {
            LoginPage loginpage = new LoginPage(driver);
            loginpage.EnterUserName(username);
            loginpage.EnterPassword(password);
            loginpage.SelectLanguageFromDropdown();
            loginpage.ClickOnLogin();


            string pageTitle = driver.Title;
           // Console.WriteLine(pageTitle);

            // Landing page Url Confirmation 
            Assert.That(pageTitle.Contains("Open"));
        }

        [Test, TestCaseSource(typeof(DataSource), nameof(DataSource.InvalidLoginTest))]


        public void InvalidLoginTest(string username, string password, string expectedMsg)
        {
            LoginPage loginpage = new LoginPage(driver);
            loginpage.EnterUserName(username);
            loginpage.EnterPassword(password);
            loginpage.ClickOnLogin();
            string errorMsg = loginpage.GetInvalidErrorMessage();
            Assert.That(errorMsg.Contains(expectedMsg));

            // Print The Error MSG
            // Console.WriteLine(errorMsg);

        }
    }


}

