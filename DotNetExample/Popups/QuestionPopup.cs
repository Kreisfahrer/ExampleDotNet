using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Rmhp_Framework.Popups
{
    class QuestionPopup
    {
        public QuestionPopup(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        private IWebDriver _driver;

        [CacheLookup]
        [FindsBy(How = How.CssSelector, Using = "button[class*=yes]")]
        #pragma warning disable 649
        private IWebElement _yes;
        #pragma warning restore 649

        [CacheLookup]
        [FindsBy(How = How.CssSelector, Using = "button[class*=no]")]
        private IWebElement _no;

        public void ClickYes()
        {
            _yes.Click();
        }
    }
}
