using OpenQA.Selenium;

namespace QualityMinds.Pages
{
    public class BasePage
    {
        protected readonly IWebDriver Driver;

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}