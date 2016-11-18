using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Linq;
using Rmhp_Framework.Dto;

namespace Rmhp_Framework.PageObjects
{
    class EmployerInformationPage
    {
        public EmployerInformationPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        private IWebDriver _driver;

        [FindsBy(How = How.CssSelector, Using = "#companyName")]
        public IWebElement CompanyName;

        [FindsBy(How = How.Id, Using = "address")]
        public IWebElement Address;

        [FindsBy(How = How.Id, Using = "primaryZip")]
        public IWebElement PrimaryZip;

        [FindsBy(How = How.CssSelector, Using = ".employerSicCode a")]
        public IWebElement SicCodeButton;

        [FindsBy(How = How.CssSelector, Using = ".sicCode-modal-search-block-codes-list li")]
        public IList<IWebElement> SicCodes;

        [FindsBy(How = How.CssSelector, Using = ".ihc-warning-wrapper")]
        public IWebElement ClearForm;

        [FindsBy(How = How.CssSelector, Using = ".text-danger")]
        public IWebElement Validation;

        public void FillEmpoyerForm(Employer employer)
        {
            CompanyName.SendKeys(employer.CompanyName);
            Address.SendKeys(employer.Address);
            PrimaryZip.SendKeys(employer.Zip);
            SelectSic(employer.Sic);
        }

        public void SelectSic(string zic)
        {
            SicCodeButton.Click();
            SicCodes.ToList().Find(element => element.Text == zic).Click();
        }

        public void ClickClearForm()
        {
            ClearForm.Click();
        }
    }
}
