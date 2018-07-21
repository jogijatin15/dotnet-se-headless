using Xunit;
using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;
using OpenQA.Selenium.Remote;

namespace HeadLessTest
{
    public class SutGoogleHomePage
    {
        // private ChromeOptions desiredCapabilities;
        // private ChromeDriver chromeDriver;
        private string appURL;
        private IWebDriver driver;

        public SutGoogleHomePage()
        {
            DesiredCapabilities caps = new DesiredCapabilities();
            caps.SetCapability(CapabilityType.BrowserName, "chrome");
            caps.SetCapability(CapabilityType.Version, "latest");
            caps.SetCapability(CapabilityType.Platform, "macOS 10.13");
            caps.SetCapability("username", "Cognizant_Integration");
            caps.SetCapability("accessKey", "a90e4692-648f-49b8-9691-b372a9973c12");
            appURL = "https://www.geico.com/";

            driver = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"), caps, TimeSpan.FromSeconds(600));
        }

        [Fact]
        public void validateHomePage()
        {
            driver.Navigate().GoToUrl(appURL);
            var pgTitle = driver.Title;
            driver.Quit();
            Assert.Contains("GEICO", pgTitle);
        }

        [Fact]
        public void validateFooterLegal()
        {
            driver.Navigate().GoToUrl(appURL);
            IWebElement link = driver.FindElement(By.LinkText("LEGAL & SECURITY"));
            link.Click();
            var pgTitle = driver.Title;
            driver.Quit();
            Assert.Contains("Legal & Security", pgTitle);
        }

        [Fact]
        public void validateFooterCareers()
        {
            driver.Navigate().GoToUrl(appURL);
            IWebElement link = driver.FindElement(By.LinkText("CAREERS"));
            link.Click();
            var pgTitle = driver.Title;
            driver.Quit();
            Assert.Contains("Careers", pgTitle);
        }

        [Fact]
        public void validateFooterContact()
        {
            driver.Navigate().GoToUrl(appURL);
            IWebElement link = driver.FindElement(By.LinkText("CONTACT US"));
            link.Click();
            var pgTitle = driver.Title;
            driver.Quit();
            Assert.Contains("Contact Us", pgTitle);
        }

        [Fact]
        public void validateFooterSiteMap()
        {
            driver.Navigate().GoToUrl(appURL);
            IWebElement link = driver.FindElement(By.LinkText("SITE MAP"));
            link.Click();
            var pgTitle = driver.Title;
            driver.Quit();
            Assert.Contains("This should fail", pgTitle);
        }
    }
}
