using Allure.Commons;
using FluentAssertions;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using QualityMinds.Core;
using QualityMinds.Core.Models;
using QualityMinds.Pages;

[assembly: LevelOfParallelism(2)]

namespace QualityMindsTests.Tests
{
    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture(BrowserType.Chrome)]
    [TestFixture(BrowserType.Firefox)]
    public class KontaktPageTest : BaseTest
    {
        public KontaktPageTest(BrowserType browserType) : base(browserType)
        {
        }
        [Test(Description = "Verify Kontakt Pages")]
        [AllureTag("Regression")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("User")]
        [AllureSuite("KontaktTest")]
        public void KontaktTest()
        {
            new HomePage(Driver)
                .Go()
                .ToKontakt();
            var kontaktUrl = new KontaktPage(Driver)
                .MailIsPresent()
                .GetUrl();

            new HomePage(Driver)
                .Go()
                .ToKontaktAndAnfahrt();
            var KontaktAndAnfahrtUrl = new KontaktPage(Driver)
                .GetUrl();

            kontaktUrl.Should().BeEquivalentTo(KontaktAndAnfahrtUrl);
        }
    }

    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture(BrowserType.Chrome)]
    [TestFixture(BrowserType.Firefox)]
    public class PortfolioPageTest : BaseTest
    {
        public PortfolioPageTest(BrowserType browserType) : base(browserType)
        {
        }
        [Test(Description = "Verify Portfolio Page")]
        [AllureTag("Regression")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("User")]
        [AllureSuite("PortfolioTest")]
        public void PortfolioTest()
        {
            new HomePage(Driver)
                .Go()
                .HoverOnPortfolio()
                .SubmenuIsDisplayed()
                .ToWebAutomationMobileTestingPage()
                .VerifyIfPortfolioIsHighlighted()
                .ToMobileTab()
                .VerifyDownloadLink()
                .VerifyFileDownloading();
        }
    }

    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture(BrowserType.Chrome)]
    [TestFixture(BrowserType.Firefox)]
    public class KarrierePageTest : BaseTest
    {
        public KarrierePageTest(BrowserType browserType) : base(browserType)
        {
        }

        [Test(Description = "Verify Karriere Page")]
        [AllureTag("Regression")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("User")]
        [AllureSuite("KarriereTest")]
        public void KarriereTest()
        {
            new HomePage(Driver)
                .Go()
                .ToKarriere()
                .ToKontaktFormular()
                .Submit()
                .VerifyAllValidations()
                .FillVorname()
                .FillNachname()
                .Submit()
                .VerifyEmailValidations()
                .FillEmail()
                .Submit()
                .UploadFile()
                .CheckDatenchutzerklarung();
        }
    }
}