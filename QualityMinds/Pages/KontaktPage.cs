using NUnit.Framework;
using OpenQA.Selenium;
using QualityMinds.Core;

namespace QualityMinds.Pages
{
    public class KontaktPage : BasePage
    {
        public IWebDriver _driver;

        public IWebElement Mail => Driver.FindElement(By.XPath("//a[contains(text(), 'hello@qualityminds.de')]"));
        public string GetUrl() => Driver.GetCurrentUrl();
        public KontaktPage(IWebDriver driver) : base(driver)
        {
        }

        public KontaktPage MailIsPresent()
        {
            Driver.WaitForClickable(Mail);
            Assert.That(Mail.Displayed);
            return this;
        }
    }
}