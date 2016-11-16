using OpenQA.Selenium;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;

namespace Rmhp_Framework.PageObjects
{
    class LoginPage    //LogIn page have three imporatnt objects to add .(Username textbox, Password textbox & Submit button)
    {
        private IWebDriver driver;

        
        [FindsBy(How = How.Id, Using = "log")]  //The PageFactory implementation for C# only searches for elements using the ID. (How = How.Id)
        [CacheLookup]
        private IWebElement UserName { get; set; }

        [FindsBy(How = How.Id, Using = "pwd")]
        [CacheLookup]
        private IWebElement Password { get; set; }

        [FindsBy(How = How.Id, Using = "login")]
        [CacheLookup]
        private IWebElement Submit { get; set; }

        public LoginPage(IWebDriver driver) //Every time the object for the LogIN page is created, it will first go into the constructor
                                            //and initialize all the object of the page. This is the nice way of Optimizing Page Object Model 
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void LoadApplication()
        {
            UserName.SendKeys("groverok");
            Password.SendKeys("cWJmSiO2w2p#q7ML");
            Submit.Submit();
        }
    }
}
