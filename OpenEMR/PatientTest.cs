using NUnit.Framework;
using OpenEMR.Base;
using OpenEMR.Pages;
using OpenEMR.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenEMR
{
    public class PatientTest : AutomationWrapper
    {
        [Test, TestCaseSource(typeof(DataSource), nameof(DataSource.AddValidPatientData))]
        public void AddNewPatient(string username, string password, string suffix, string firstname, string middlename, string lastname, string dob, string gender, string maritalstatus)

        {
            // I made new changes in my code 
            LoginPage loginPage = new LoginPage(driver abc);
            loginPage.EnterUserName(username);
            loginPage.EnterPassword(password);
            loginPage.SelectLanguageFromDropdown();
            loginPage.ClickOnLogin();


            MainPage mainpage = new MainPage(driver);
            mainpage.MouseOverAction();
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@name='pat']")));
            mainpage.SelectTheNameSuffix(suffix);
            mainpage.EnterFirstName(firstname);
            mainpage.EnterMiddleName(middlename);
            mainpage.EnterLastName(lastname);
            mainpage.EnterDateOfBirth(dob);
            Thread.Sleep(1000);
            mainpage.SelectGender(gender);

            Thread.Sleep(1000);

            mainpage.SelectMaritalStatus(maritalstatus);
            Thread.Sleep(1000);
            SelectElement select2 = new SelectElement(driver.FindElement(By.Id("form_gender_identity")));
            string dynamicPath = "Identifies as @@@@";
            dynamicPath = dynamicPath.Replace("@@@@", gender);
            select2.SelectByText(dynamicPath);
            Thread.Sleep(1000);
            driver.FindElement(By.Id("create")).Click();
            driver.SwitchTo().DefaultContent();
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@id='modalframe']")));
            // driver.FindElement(By.XPath("//input[@value='Confirm Create New Patient']")).Click();
            mainpage.ClickOnCreateNewPatient();
            Thread.Sleep(3000);

             driver.SwitchTo().Alert().Accept();




        }

    }
}
