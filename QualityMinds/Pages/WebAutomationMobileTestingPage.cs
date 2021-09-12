using NUnit.Framework;
using OpenQA.Selenium;
using QualityMinds.Core;

namespace QualityMinds.Pages
{
    class WebAutomationMobileTestingPage : BasePage
    {
        public IWebElement PortfolioButton => Driver.FindElement(By.XPath("//*[@id='top-menu']//a[contains(text(), 'Portfolio')]"));
        public IWebElement MobileTab => Driver.FindElement(By.XPath("//*[@id='team-tab-three-title-desktop']/div[contains(text(),'Mobile')]"));
        public IWebElement Flyer => Driver.FindElement(By.XPath($"//*[@id='team-tab-three-body']//*[@download='{FlyerName}']"));

        private const string FlyerLink = "https://qualityminds.de/app/uploads/2018/11/Find-The-Mobile-Bug-Session.pdf";
        private const string FlyerName = "FLYER FIND THE BUG SESSION";
        private const string FlyerFileName = FlyerName + ".pdf";
        const string highlightedColor = "130, 186, 69";
        public WebAutomationMobileTestingPage(IWebDriver driver) : base(driver)
        {
        }

        public WebAutomationMobileTestingPage VerifyIfPortfolioIsHighlighted()
        {
            Assert.That(Driver.IsElementHighlighted(PortfolioButton, highlightedColor));
            return this;
        }

        public WebAutomationMobileTestingPage ToMobileTab()
        {
            Driver.ClickOnElement(MobileTab);
            return this;
        }
        public WebAutomationMobileTestingPage VerifyDownloadLink()
        {
            var link = Flyer.GetAttribute("href");
            Assert.AreEqual(FlyerLink, link);
            return this;
        }
        public void VerifyFileDownloading()
        {
            Driver.DownloadFile(Flyer, FlyerFileName);
        }
    }
}