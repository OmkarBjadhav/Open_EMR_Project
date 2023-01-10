using DocumentFormat.OpenXml.Bibliography;
using NUnit.Framework;
using OpenEMR.Base;
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
    public  class LoginTest:AutomationWrapper
    {
        [Test,TestCaseSource(typeof(DataSource),nameof(DataSource.ValidLoginTest))]
        public void ValidLoginTest(string username,string password)
        {
            driver.FindElement(By.Id("authUser")).SendKeys(username);
            driver.FindElement(By.Id("clearPass")).SendKeys(password);
            SelectElement select = new SelectElement(driver.FindElement(By.XPath("//select[@class='form-control']")));
            select.SelectByText("English (Indian)");
            driver.FindElement(By.Id("login-button")).Click();

            string pageUrl = driver.Url;

            // Landing page Url Confirmation 
            Assert.That(pageUrl.Contains("http://demo.openemr.io/b/openemr/interface/main/tabs/main.php"));
        }

        [Test, TestCaseSource(typeof(DataSource), nameof(DataSource.InvalidLoginTest))]


        public void InvalidLoginTest(string username, string password, string expectedMsg)
        {
            driver.FindElement(By.Id("authUser")).SendKeys(username);
            driver.FindElement(By.Id("clearPass")).SendKeys(password);
            driver.FindElement(By.Id("login-button")).Click();
            string errorMsg = driver.FindElement(By.XPath("//div[contains(text(),'Invalid')]")).Text;
            Assert.That(errorMsg.Contains(expectedMsg));

            // Print The Error MSG
            // Console.WriteLine(errorMsg);

        }
    }


}

