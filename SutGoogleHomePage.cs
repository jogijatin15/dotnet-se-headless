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
      private ChromeOptions desiredCapabilities;
      private string appURL;
      private ChromeDriver chromeDriver;

        public SutGoogleHomePage()
        {
          desiredCapabilities = new ChromeOptions();
          desiredCapabilities.AddArgument("--headless");
          desiredCapabilities.AddArgument("--no-sandbox");
          desiredCapabilities.AddArgument("--ignore-ssl-errors=true");
          desiredCapabilities.AddArgument("--ssl-protocol=any");
          desiredCapabilities.AddArgument("--disable-gpu");
          desiredCapabilities.AddArgument("window-size=1400,600");

          appURL = "https://www.geico.com";

          chromeDriver = new ChromeDriver(
              Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
              desiredCapabilities
          );
        }

        [Fact]
        public void validateHomePage()
        {
            chromeDriver.Navigate().GoToUrl(appURL);
            var pgTitle = chromeDriver.Title;
            chromeDriver.Quit();
            Assert.Contains("GEICO", pgTitle);
        }


    }
}
