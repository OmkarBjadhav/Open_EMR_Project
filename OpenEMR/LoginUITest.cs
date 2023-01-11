using NUnit.Framework;
using OpenEMR.Base;
using OpenEMR.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenEMR
{
    public class LoginUITest : AutomationWrapper
    {
        [Test]
        public void ValidateTitleTest()
        {
            string actualTitle = driver.Title;
            Console.WriteLine(actualTitle);

            Assert.That(actualTitle, Is.EqualTo("OpenEMR Login"));

        }


        [Test]
        public void ValidatePlaceHolderTest()
        {
            LoginPage loginPage = new LoginPage(driver);
            string actualUsernamePlaceHolder = loginPage.GetUserNamePlaceholder();
            string actualPasswordPlaceHolder = loginPage.GetPasswordPlaceholder();
            Assert.That(actualPasswordPlaceHolder, Is.EqualTo("Password"));
            Assert.That(actualUsernamePlaceHolder, Is.EqualTo("Username"));
        }
    }
}
