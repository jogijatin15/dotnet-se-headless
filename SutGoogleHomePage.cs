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
            caps.SetCapability(CapabilityType.AppiumVersion, "1.8.0");
            caps.SetCapability(CapabilityType.DeviceName, "iPhone 8 Plus Simulator");
            caps.SetCapability(CapabilityType.DeviceOrientation, "portrait");
            caps.SetCapability(CapabilityType.PlatformVersion, "11.2");
            caps.SetCapability(CapabilityType.PlatformName, "iOS");
            caps.SetCapability(CapabilityType.BrowserName, "Safari");

            caps.SetCapability("username", System.Environment.GetEnvironmentVariable("SAUCE_USERNAME"));
            caps.SetCapability("accessKey", System.Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY"));
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

    }
}
