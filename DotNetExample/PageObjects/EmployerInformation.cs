using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rmhp_Framework.PageObjects
{
    class EmployerInformation
    {
        public EmployerInformation(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        private IWebDriver driver;

        [CacheLookup]
        [FindsBy(How = How.CssSelector, Using = "#companyName")]
        public IWebElement companyName;

        [CacheLookup]
        [FindsBy(How = How.Id, Using = "address")]
        public IWebElement address;

        [CacheLookup]
        [FindsBy(How = How.Id, Using = "primaryZip")]
        public IWebElement primaryZip;

        [CacheLookup]
        [FindsBy(How = How.CssSelector, Using = ".employerSicCode a")]
        public IWebElement zicCodeButton;

        [CacheLookup]
        [FindsBy(How = How.CssSelector, Using = ".sicCode-modal-search-block-codes-list li")]
        public IList<IWebElement> zicCodes;

        [CacheLookup]
        [FindsBy(How = How.CssSelector, Using = ".ihc-warning-wrapper")]
        public IWebElement clearForm;

        public void FillEmpoyerForm(Employer employer)
        {
            companyName.SendKeys(employer.CompanyName);
            address.SendKeys(employer.Address);
            primaryZip.SendKeys(employer.Zip);
            SelectSic(employer.Zic);
        }

        public void SelectSic(string Zic)
        {
            zicCodeButton.Click();
            zicCodes.ToList().Find(element => element.Text == Zic).Click();
        }

        public void ClickClearForm()
        {
            clearForm.Click();
        }
    }
}
