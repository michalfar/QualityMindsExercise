using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using QualityMinds.Core.Models;

namespace QualityMinds.Core
{
    [TestFixture]
    [AllureNUnit]
    public class BaseTest
    {
        public BaseTest(BrowserType browserType)
        {
            BrowserType = browserType;
        }
        protected IWebDriver Driver { get; set; }
        public BrowserType BrowserType { get; set; }

        [SetUp]
        public void Setup()
        {
            Driver = new WebDriverFactory(BrowserType).InitializeTest();
            Driver.Manage().Cookies.DeleteAllCookies();
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}
