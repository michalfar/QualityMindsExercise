using OpenQA.Selenium;
using QualityMinds.Core;

namespace QualityMinds.Pages
{
    internal class KarrierePage : BasePage
    {
        public KarrierePage(IWebDriver driver) : base(driver)
        {
        }
        public IWebElement KontaktFormular => Driver.FindElement(By.XPath("//a[@class='et_pb_button et_pb_button_0 qm-button et_pb_bg_layout_light']"));

        public KontaktFormularPage ToKontaktFormular()
        {
            Driver.ClickOnElement(KontaktFormular);
            return new KontaktFormularPage(Driver);
        }
    }
}