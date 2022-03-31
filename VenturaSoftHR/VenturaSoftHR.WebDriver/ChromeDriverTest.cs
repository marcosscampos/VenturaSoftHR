using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System.IO;

namespace VenturaSoftHR.WebDriver
{
    [TestClass]
    public class ChromeDriverTest
    {
        private ChromeDriver _driver;

        [TestInitialize]
        public void ChromeDriverInitialize()
        {
            var location = Path.GetFullPath("ChromeDriver");
            var service = ChromeDriverService.CreateDefaultService(location);
            var options = new ChromeOptions
            {
                PageLoadStrategy = PageLoadStrategy.Normal
            };
            options.AddArgument("headless");
            _driver = new ChromeDriver(service, options);
        }

        [TestMethod]
        public void VerifyTitleAndAuthorName()
        {
            _driver.Url = "http://quotes.toscrape.com";
            var author = _driver.FindElementByCssSelector("small.author");

            Assert.AreEqual("Albert Einstein", author.Text);
            Assert.AreEqual("Quotes to Scrape", _driver.Title);
        }

        [TestCleanup]
        public void ChromeDriverCleanup()
        {
            _driver.Quit();
        }
    }
}
