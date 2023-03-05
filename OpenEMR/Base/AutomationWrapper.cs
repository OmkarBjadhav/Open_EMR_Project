using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenEMR.Base
{
    public  class AutomationWrapper
    {

        protected IWebDriver driver;



        // This Method will run before the [Test]Method
        [SetUp]
        public void beforeMethod()
        {

            string browserValue = "firefox";
            if (browserValue.ToLower().Equals("edge"))
            {
                driver = new EdgeDriver();
            }
            else if (browserValue.ToLower().Equals("firfox"))
            {
                driver = new FirefoxDriver();

            }
            else
            {
                driver = new ChromeDriver();

            }


            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            driver.Url = "https://demo.openemr.io/openemr/interface/login/login.php?site=default";

        }

        //This Method will run after the [Test] Method no matter it is fail or pass.
        [TearDown]
        public void afterMethod()
        {
            driver.Quit();
        }
    }
}
