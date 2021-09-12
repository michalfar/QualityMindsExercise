using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using QualityMinds.Core.Models;

namespace QualityMinds.Core
{
    public class WebDriverOptions
    {
        private const string RemoteDownloadPath = @"/tmp/downloads";

        public static ChromeOptions DefaultChromeOptions(WebDriverConfiguration webDriverConfiguration)
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--start-maximized");
            chromeOptions.AddArgument("--disable-infobars");
            chromeOptions.AddArgument("--no-sandbox");
            chromeOptions.AddArgument("--lang=de-DE");
            chromeOptions.AddArgument("--window-size=1920,1080");
            chromeOptions.AddArgument("--disable-popup-blockin");
            chromeOptions.AddUserProfilePreference("download.default_directory", @"c:\Downloads");

            if (webDriverConfiguration.Headless)
            {
                chromeOptions.AddArgument("--headless");
            }

            return chromeOptions;
        }

        public static FirefoxOptions DefaultFirefoxOptions(WebDriverConfiguration webDriverConfiguration)
        {
            var firefoxOptions = new FirefoxOptions();
            firefoxOptions.AddArgument("--start-maximized");
            firefoxOptions.AddArgument("--disable-infobars");
            firefoxOptions.AddArgument("--no-sandbox");
            firefoxOptions.SetPreference("browser.download.dir", @"c:\Downloads");
            firefoxOptions.SetPreference("download.prompt_for_download", false);
            firefoxOptions.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/pdf");
            firefoxOptions.SetPreference("browser.download.folderList", 2);
            firefoxOptions.SetPreference("pdfjs.disabled", true);

            if (webDriverConfiguration.Headless)
            {
                firefoxOptions.AddArgument("--headless");
            }

            return firefoxOptions;
        }

        public static ChromeOptions RemoteChromeOptions(WebDriverConfiguration webDriverConfiguration)
        {
            var options = DefaultChromeOptions(webDriverConfiguration);
            options.AddUserProfilePreference("download.default_directory", RemoteDownloadPath + @"/chrome");
            return options;
        }
        public static FirefoxOptions RemoteFirefoxOptions(WebDriverConfiguration webDriverConfiguration)
        {
            var options = DefaultFirefoxOptions(webDriverConfiguration);
            options.SetPreference("browser.download.dir", RemoteDownloadPath + @"/firefox");
            return options;
        }
    }
}
