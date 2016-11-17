using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rmhp_Framework.Popups
{
    class QuestionPopup
    {
        public QuestionPopup(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        private IWebDriver driver;

        [CacheLookup]
        [FindsBy(How = How.CssSelector, Using = "button[class*=yes]")]
        private IWebElement yes;

        [CacheLookup]
        [FindsBy(How = How.CssSelector, Using = "button[class*=no]")]
        private IWebElement no;

        public void ClickYes()
        {
            yes.Click();
        }
    }
}
