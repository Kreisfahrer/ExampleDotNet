using NUnit.Framework;
using OpenQA.Selenium;
using Rmhp_Framework.Dto;
using Rmhp_Framework.PageObjects;
using Rmhp_Framework.Popups;
using Rmhp_Framework.WrapperFactory;
using System.Configuration;

namespace Rmhp_Framework.TestCases
{
    class EmployerInformationTest
    {
        private IWebDriver _driver;
        EmployerInformationPage _employerInformation;
        QuestionPopup _questionPopup;

        [SetUp]
        public void Setup()
        {
            WebDriverFactory.InitBrowser(ConfigurationManager.AppSettings["Browser"]);
            WebDriverFactory.LoadApplication(ConfigurationManager.AppSettings["URL"]);
            _driver = WebDriverFactory.Driver;
            _driver.Manage().Window.Maximize();
            _employerInformation = new EmployerInformationPage(_driver);
            _questionPopup = new QuestionPopup(_driver);
        }

        [Test]
        public void FillEmployerInformationTest()
        {
            var employer = new Employer("test", "test", "12345", "111 Wheat");
            _employerInformation.FillEmpoyerForm(employer);
            _employerInformation.ClickClearForm();
            _questionPopup.ClickYes();
            Assert.IsEmpty(_employerInformation.CompanyName.Text);
            Assert.IsEmpty(_employerInformation.Address.Text);
        }

        [Test]
        public void FailingTest()
        {
            _employerInformation.FillEmpoyerForm(new Employer("test", "test", "123456", "111 Wheat"));
            Assert.IsFalse(_employerInformation.Validation.Displayed);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            WebDriverFactory.CloseAllDrivers();
        }
    }
}
