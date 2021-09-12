using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;

namespace QualityMinds.Core
{
    static class WaitHelper
    {
        public static void WaitForClickable(this IWebDriver driver, IList<IWebElement> element)
        {
            driver.Wait().Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            foreach (var e in element)
            {
                driver.Wait().Until(ExpectedConditions.ElementToBeClickable(e));
            }
        }

        public static void WaitForClickable(this IWebDriver driver, IWebElement element)
        {
            driver.Wait().Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            driver.Wait().Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public static void WaitForClickable(this IWebDriver driver, By by)
        {
            driver.Wait().Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            driver.Wait().Until(ExpectedConditions.ElementToBeClickable(by));
        }
        public static WebDriverWait Wait(this IWebDriver driver)
        {
            return new WebDriverWait(driver,
                TimeSpan.FromSeconds(Configuration.WebDriver.DefaultTimeout));
        }
    }
}
