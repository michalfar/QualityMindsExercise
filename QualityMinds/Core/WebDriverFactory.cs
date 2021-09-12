using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using QualityMinds.Core.Models;
using System;
using System.Text;

namespace QualityMinds.Core
{
    public class WebDriverFactory
    {
        public WebDriverFactory(BrowserType browserType)
        {
            BrowserType = browserType;
        }

        private BrowserType BrowserType { get; set; }

        public IWebDriver InitializeTest()
        {
            var driverConfig = Configuration.WebDriver;
            SetEncoding();

            if (Configuration.WebDriver.remoteRun == true)
            {
                if (BrowserType == BrowserType.Chrome)

                {
                    var chromeOptions = WebDriverOptions.RemoteChromeOptions(driverConfig);
                    return new RemoteWebDriver(new Uri(driverConfig.GridUrl), chromeOptions);

                }
                else if (BrowserType == BrowserType.Firefox)
                {
                    var firefoxOptions = WebDriverOptions.RemoteFirefoxOptions(driverConfig);
                    return new RemoteWebDriver(new Uri(driverConfig.GridUrl), firefoxOptions);
                }
                else
                    throw new ArgumentOutOfRangeException();
            }
            else
            {
                if (BrowserType == BrowserType.Chrome)
                {
                    var chromeOptions = WebDriverOptions.DefaultChromeOptions(driverConfig);
                    return new ChromeDriver(chromeOptions);
                }
                else if (BrowserType == BrowserType.Firefox)
                {
                    var firefoxOptions = WebDriverOptions.DefaultFirefoxOptions(driverConfig);
                    return new FirefoxDriver(firefoxOptions);
                }
                else
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static void SetEncoding()
        {
            CodePagesEncodingProvider.Instance.GetEncoding(437);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }
    }
}