using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;




namespace Rmhp_Framework.PageObjects
{
    class HomePage
    {
        private IWebDriver driver;

        [CacheLookup]
        [FindsBy(How = How.Id, Using = "account")]          // any attribute marked [CacheLookup] will not be searched over and over again just using one object from Home Page
        private IWebElement MyAccount { get; set; }         // Encapsulate Selenium Page Objects we should make all the Page Objects as Private. 

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }

        public void ClickOnMyAccount()
        {
            MyAccount.Click();
        }
    }
}
