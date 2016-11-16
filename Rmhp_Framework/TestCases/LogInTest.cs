using System;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using Rmhp_Framework.PageObjects;
using System.Drawing;
using System.Configuration;
using Rmhp_Framework.WrapperFactory;

namespace Rmhp_Framework.TestCases  //Set Up Project for Selenium Automation Framework
{
    class LogInTest
    {


        [Test]
        public void Test()
        {
            WebDriverFactory.InitBrowser("Chrome");
            WebDriverFactory.LoadApplication(ConfigurationManager.AppSettings["URL"]);
            IWebDriver driver = WebDriverFactory.Driver;
            driver.Manage().Window.Size = new Size(1024, 768);

            var homePage = new HomePage(driver);
            homePage.ClickOnMyAccount();

            var loginPage = new LoginPage(driver);
            loginPage.LoadApplication();
            WebDriverFactory.CloseAllDrivers();


        }

    }
}



