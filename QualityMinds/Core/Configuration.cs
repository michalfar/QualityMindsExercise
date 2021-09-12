using Microsoft.Extensions.Configuration;
using QualityMinds.Core.Models;
using System.IO;

namespace QualityMinds.Core
{
    public class Configuration
    {
        private const string WebDriverConfigSectionName = "webdriver";
        private const string EnvironmentConfigSectionName = "environment";

        public static WebDriverConfiguration WebDriver =>
            Load<WebDriverConfiguration>(WebDriverConfigSectionName);

        public static EnvironmentConfiguration Environment =>
            Load<EnvironmentConfiguration>(EnvironmentConfigSectionName);

        public static string DriverPath =>
            Path.Combine(System.Environment.CurrentDirectory, "Drivers");

        private static T Load<T>(string sectionName)
        {
            var currentDirectory = Directory.GetCurrentDirectory();

            return new ConfigurationBuilder().AddJsonFile(currentDirectory + @"/appsettings.json")
                .Build().GetSection(sectionName).Get<T>();
        }
    }
}