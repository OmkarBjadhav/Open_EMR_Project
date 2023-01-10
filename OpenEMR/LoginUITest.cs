using NUnit.Framework;
using OpenEMR.Base;
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
            string actualUsernamePlaceHolder = driver.FindElement(By.Id("authUser")).GetAttribute("placeholder");
            string actualPasswordPlaceHolder = driver.FindElement(By.Id("clearPass")).GetAttribute("placeholder");
            Assert.That(actualPasswordPlaceHolder, Is.EqualTo("Password"));
            Assert.That(actualUsernamePlaceHolder, Is.EqualTo("Username"));
        }
    }
}
