using Xunit;
using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;
using OpenQA.Selenium.Remote;
using System.Threading;
using System.Threading.Tasks;

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

            caps.SetCapability("appiumVersion", "1.8.0");
            caps.SetCapability("deviceName", "iPhone 8 Simulator");
            caps.SetCapability("deviceOrientation", "portrait");
            caps.SetCapability("platformVersion", "11.2");
            caps.SetCapability("platformName", "iOS");
            caps.SetCapability("browserName", "Safari");
            // caps.SetCapability("username", System.Environment.GetEnvironmentVariable("SAUCE_USERNAME"));
            // caps.SetCapability("accessKey", System.Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY"));

            caps.SetCapability("username", "Cognizant_Integration");
            caps.SetCapability("accessKey", "a90e4692-648f-49b8-9691-b372a9973c12");
            caps.SetCapability("name", "TC1 - Start a new Insurance Quote on Mobile Device");

            appURL = "https://www.geico.com/";
            driver = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"), caps, TimeSpan.FromSeconds(600));
        }

        [Fact]
        public void validateHomePage()
        {
            driver.Navigate().GoToUrl(appURL);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            Thread.Sleep(20000);

            driver.FindElement(By.Id("zip")).SendKeys("90034");
            driver.FindElement(By.Id("submitButton")).Click();

            // Thread.Sleep(25000);
            //
            // driver.FindElement(By.LinkText("skip")).Click();
            //
            // driver.FindElement(By.Id("firstName")).SendKeys("Mike");
            // driver.FindElement(By.Id("lastName")).SendKeys("West");
            // driver.FindElement(By.CssSelector(".btn-spotlight")).Click();

            var pgTitle = driver.Title;
            driver.Quit();
            Assert.Contains("GEICO", pgTitle);
        }

    }
}
