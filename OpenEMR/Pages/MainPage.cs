using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenEMR.Pages
{
    public class MainPage
    {
        private By _firstnameLoc = By.Id("form_fname");
        private By _middlenameLoc = By.Id("form_mname");
        private By _lasttnameLoc = By.Id("form_lname");
        private By _searchoraddnewpatientloc = By.XPath("//div[text()='Patient']");
        private By _clickonaddnewpatient = By.XPath("//div[text()='New/Search']");
        private By _dateofbirthloc = By.Id("form_DOB");
        private By _selctgenderloc = By.Id("form_sex");
        private By _selectmaritalstatusloc = By.Id("form_status");


        private IWebDriver driver;
        public MainPage(IWebDriver driver)
        {
            this.driver = driver;

        }

        public void MouseOverAction()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(_searchoraddnewpatientloc)).Build().Perform();
            driver.FindElement(_clickonaddnewpatient).Click();

        }
        public void SelectTheNameSuffix(string suffix)
        {
            SelectElement sel = new SelectElement(driver.FindElement(By.Id("form_title")));
            sel.SelectByText(suffix);

        }

        public void EnterFirstName(string firstname)
        {
            driver.FindElement(_firstnameLoc).SendKeys(firstname);

        }
        public void EnterMiddleName(string middlename)
        {
            driver.FindElement(_middlenameLoc).SendKeys(middlename);

        }
        public void EnterLastName(string lastname)
        {
            driver.FindElement(_lasttnameLoc).SendKeys(lastname);

        }
        public void EnterDateOfBirth(string date)
        {

            driver.FindElement(_dateofbirthloc).SendKeys(date);
        }

        public void SelectGender(string gender)
        {
            SelectElement select1 = new SelectElement(driver.FindElement(_selctgenderloc));
            select1.SelectByText(gender);

        }
        public void SelectMaritalStatus(string maritalstatus)
        {
            SelectElement select1 = new SelectElement(driver.FindElement(_selectmaritalstatusloc));
            select1.SelectByText(maritalstatus);

        }
    }
}
