namespace QualityMinds.Core.Models
{
    public class WebDriverConfiguration
    {
        public BrowserType BrowserType { get; set; }
        public bool Headless { get; set; }
        public bool remoteRun { get; set; }
        public string GridUrl { get; set; }
        public int DefaultTimeout { get; set; }
    }
}