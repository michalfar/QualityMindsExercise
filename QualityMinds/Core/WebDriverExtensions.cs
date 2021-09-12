using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Drawing;
using System.IO;
using System.Linq;

namespace QualityMinds.Core
{
    static class WebDriverExtensions
    {
        private const string DownloadPath = @"C:\Downloads\";

        public static string GetCurrentUrl(this IWebDriver driver)
        {
            return driver.Url;
        }

        public static void Open(this IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
            driver.Wait().Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public static void MoveToElement(this IWebDriver driver, IWebElement element)
        {
            var actions = new Actions(driver);
            driver.WaitForClickable(element);
            actions.MoveToElement(element).Build().Perform();
        }

        public static void ClickOnElement(this IWebDriver driver, IWebElement element)
        {
            driver.WaitForClickable(element);
            element.Click();
        }

        public static void WaitForLoad(this IWebDriver driver, int timeoutSec = 15)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, timeoutSec));
            wait.Until(wd => js.ExecuteScript("return document.readyState").ToString() == "complete");
        }

        public static bool IsElementHighlighted(this IWebDriver driver, IWebElement element, string highlightedColor)
        {
            string colorFromCss = element.GetCssValue("color");
            var trimmedColor = colorFromCss.Trim(new Char[] { 'r', 'g', 'b', 'a', '(', ')' }).ToColor();
            var expectedColor = highlightedColor.ToColor();
            return expectedColor.Equals(trimmedColor);
        }

        public static void DownloadFile(this IWebDriver driver, IWebElement element, string expectedFileName)
        {
            ICapabilities capabilities = ((RemoteWebDriver)driver).Capabilities;
            var browserName = capabilities.GetCapability("browserName");
            string filePath = DownloadPath + browserName + @"\" + expectedFileName;

            driver.WaitForClickable(element);
            element.Click();

            try
            {
                WaitHelper.Wait(driver).Until(x => true.Equals(File.Exists(filePath)));
                File.Delete(filePath);
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException();
            }
        }

        public static void SendKeysWithWait(this IWebDriver driver, By by, string text)
        {
            driver.WaitForClickable(by);
            driver.FindElement(by).Clear();
            driver.FindElement(by).SendKeys(text);
        }

        public static void SendKeysWithWait(this IWebDriver driver, IWebElement element, string text)
        {
            driver.WaitForClickable(element);
            element.Clear();
            element.SendKeys(text);
        }

        private static System.Drawing.Color ToColor(this string color)
        {
            var arrColorFragments = color?.Split(',').Select(sFragment => { int.TryParse(sFragment, out int fragment); return fragment; }).ToArray();

            return (arrColorFragments?.Length) switch
            {
                3 => Color.FromArgb(arrColorFragments[0], arrColorFragments[1], arrColorFragments[2]),
                4 => Color.FromArgb(arrColorFragments[0], arrColorFragments[1], arrColorFragments[2]),
                _ => Color.Transparent,
            };
        }
    }
}

