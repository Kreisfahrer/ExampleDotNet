using NUnit.Framework;
using OpenQA.Selenium;
using Rmhp_Framework.PageObjects;
using Rmhp_Framework.Popups;
using Rmhp_Framework.WrapperFactory;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rmhp_Framework.TestCases
{
    class EmployerInformationTest
    {
        private IWebDriver driver;
        EmployerInformation employerInformation;
        QuestionPopup questionPopup;

        [SetUp]
        public void Setup()
        {
            WebDriverFactory.InitBrowser("Chrome");
            WebDriverFactory.LoadApplication(ConfigurationManager.AppSettings["URL"]);
            driver = WebDriverFactory.Driver;
            driver.Manage().Window.Maximize();
            employerInformation = new EmployerInformation(driver);
            questionPopup = new QuestionPopup(driver);
        }

        [Test]
        public void FillEmployerInformationTest()
        {
            Employer employer = new Employer("test", "test", "12345", "111 Wheat");
            employerInformation.FillEmpoyerForm(employer);
            employerInformation.ClickClearForm();
            questionPopup.ClickYes();
            Assert.IsEmpty(employerInformation.companyName.Text);
            Assert.IsEmpty(employerInformation.address.Text);
        }

        [TearDown]
        public void TearDown()
        {
            WebDriverFactory.CloseAllDrivers();
        }
    }
}
