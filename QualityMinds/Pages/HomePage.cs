using NUnit.Framework;
using OpenQA.Selenium;
using QualityMinds.Core;

namespace QualityMinds.Pages
{
    class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement Kontakt => Driver.FindElement(By.XPath("//*[@id='top-menu']//a[contains(text(), 'Kontakt')]"));
        public IWebElement KontaktAndAnfahrt => Driver.FindElement(By.XPath("//a[contains(text(), 'Kontakt & Anfahrt')]"));
        public IWebElement Portfolio => Driver.FindElement(By.XPath("//*[@id='top-menu']//a[contains(text(), 'Portfolio')]"));
        public IWebElement PortfolioSubmenu => Driver.FindElement(By.XPath("//*[@id='top-menu']//a[contains(text(), 'Portfolio')]/../*[contains(@class, 'sub-menu')]"));
        public IWebElement WebAutomationMobileTesting => Driver.FindElement(By.XPath("//*[@id='top-menu']//a[contains(text(), 'Portfolio')]/../*[contains(@class, 'sub-menu')]//a[contains(text(), 'Web, Automation & Mobile Testing')]"));
        public IWebElement Karriere => Driver.FindElement(By.XPath("//*[@id='top-menu']//a[contains(text(), 'Karriere')]"));
        public IWebElement CookiesPopup => Driver.FindElement(By.ClassName("cc-allow"));


        public HomePage Go()
        {
            Driver.Navigate().GoToUrl("https://qualityminds.de");
            AcceptCookies();
            return this;
        }

        public KontaktPage ToKontakt()
        {
            Driver.ClickOnElement(Kontakt);
            return new KontaktPage(Driver);
        }

        public KontaktPage ToKontaktAndAnfahrt()
        {
            Driver.ClickOnElement(KontaktAndAnfahrt);
            return new KontaktPage(Driver);
        }

        public KarrierePage ToKarriere()
        {
            Driver.ClickOnElement(Karriere);
            return new KarrierePage(Driver);
        }

        public string GetUrl() => Driver.GetCurrentUrl();

        public HomePage SubmenuIsDisplayed()
        {
            Assert.That(PortfolioSubmenu.Displayed);
            return this;
        }

        public HomePage HoverOnPortfolio()
        {
            Driver.MoveToElement(Portfolio);
            return this;
        }

        public WebAutomationMobileTestingPage ToWebAutomationMobileTestingPage()
        {
            Driver.ClickOnElement(WebAutomationMobileTesting);
            return new WebAutomationMobileTestingPage(Driver);
        }

        public HomePage AcceptCookies()
        {
            try
            {
                Driver.ClickOnElement(CookiesPopup);
            }
            catch (OpenQA.Selenium.WebDriverTimeoutException)
            {
            }
            return this;
        }
    }
}
