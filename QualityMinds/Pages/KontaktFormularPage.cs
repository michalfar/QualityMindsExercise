using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using QualityMinds.Core;
using System.Collections.Generic;
using System.IO;

namespace QualityMinds.Pages
{
    internal class KontaktFormularPage : BasePage
    {
        private const string UploadFilePath = @"\Tests\TestData\file.txt";
        IWebElement Vorname => Driver.FindElement(By.XPath("//input[@placeholder='Vorname*']"));
        IWebElement Nachname => Driver.FindElement(By.XPath("//input[@placeholder='Nachname*']"));
        IWebElement Email => Driver.FindElement(By.XPath("//input[@placeholder='Email*']"));
        IWebElement JetztBewerben => Driver.FindElement(By.XPath("//input[@type='submit']"));
        IList<IWebElement> ValidationMessages => Driver.FindElements(By.XPath("//*[@class='parsley-required']"));
        IWebElement EmailValidationMessages => Driver.FindElement(By.XPath("//input[@placeholder='Email*']/../..//*[@class='parsley-required']"));
        IWebElement Upload => Driver.FindElement(By.Id("fld_8583967_1"));
        IWebElement Checkbox => Driver.FindElement(By.Id("fld_4989725_1_opt1865542"));
        public KontaktFormularPage(IWebDriver driver) : base(driver)
        {
        }

        public KontaktFormularPage FillVorname()
        {
            Driver.SendKeysWithWait(Vorname, "vorname");
            return this;
        }

        public KontaktFormularPage FillNachname()
        {
            Driver.SendKeysWithWait(Nachname, "nachname");
            return this;
        }
        public KontaktFormularPage FillEmail()
        {
            Driver.SendKeysWithWait(Email, "fake@fake.com");
            return this;
        }

        public KontaktFormularPage Submit()
        {
            Driver.ClickOnElement(JetztBewerben);
            return this;
        }

        public KontaktFormularPage VerifyAllValidations()
        {
            Driver.WaitForClickable(ValidationMessages);
            Assert.AreEqual(4, ValidationMessages.Count);
            return this;
        }

        public KontaktFormularPage VerifyEmailValidations()
        {
            Assert.That(EmailValidationMessages.Displayed);
            return this;
        }
        public KontaktFormularPage UploadFile()
        {
            var allowsDetection = Driver as IAllowsFileDetection;
            if (allowsDetection != null)
            {
                allowsDetection.FileDetector = new LocalFileDetector();
            }

            var CurrentDirectory = Directory.GetCurrentDirectory();
            Upload.SendKeys(CurrentDirectory + UploadFilePath);
            return this;
        }

        public KontaktFormularPage CheckDatenchutzerklarung()
        {
            Driver.ClickOnElement(Checkbox);
            return this;
        }
    }
}