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
        private string googleUrl;
        // private ChromeDriver chromeDriver;
        private IWebDriver driver;

        public SutGoogleHomePage()
        {
            DesiredCapabilities caps = new DesiredCapabilities();
            caps.SetCapability(CapabilityType.BrowserName, "chrome");
            caps.SetCapability(CapabilityType.Version, "latest");
            caps.SetCapability(CapabilityType.Platform, "Windows 10");
            caps.SetCapability("username", System.Environment.GetEnvironmentVariable("SAUCE_USERNAME"));
            caps.SetCapability("accessKey", System.Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY"));
            caps.SetCapability("name", "Test Case 1");
            googleUrl = "https://www.google.com";
            driver = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"), caps, TimeSpan.FromSeconds(600));
        }

        [Fact]
        public void GoogleHomePageVerifyPageIsLoading()
        {
            driver.Navigate().GoToUrl(googleUrl);
            var pgTitle = driver.Title;
            driver.Quit();

            Assert.Equal("Google", pgTitle);
        }

        [Fact]
        public void GoogleHomePageVerifyUserIsAbleToSearch()
        {
            driver.Navigate().GoToUrl(googleUrl);
            IWebElement searchInputBox = driver.FindElement(By.Name("q"));
            searchInputBox.SendKeys("codewithdot.net");
            searchInputBox.Submit();
            var pgTitle = driver.Title;

            driver.Quit();

            Assert.Equal("codewithdot.net - Google Search", pgTitle);
        }
    }
}
