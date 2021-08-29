using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;


namespace BrowserUserAgent
{
    public class BrowserHW
    {
        private static IWebDriver _driver;

        [TestCase("Firefox", "Firefox 91 on Windows 7", TestName = "Testing Firefox")]
        [TestCase("Chrome", "Chrome 92 on Windows 7", TestName = "Testing Chrome")]

        public static void TestBrowser(string browser, string expectedBrowserAgent)
        {
            if ("Firefox".Equals(browser))
            {
                _driver = new FirefoxDriver();
            }
            if ("Chrome".Equals(browser))
            {
                _driver = new ChromeDriver();
            }

            _driver.Manage().Window.Maximize();

            _driver.Navigate().GoToUrl("https://developers.whatismybrowser.com/useragents/parse/?analyse-my-user-agent=yes#parse-useragent");

            IWebElement ActualBrowserAgent = _driver.FindElement(By.CssSelector(".simple-major"));
            Assert.AreEqual(expectedBrowserAgent, ActualBrowserAgent.Text,$"Browser is not {browser}");

            _driver.Quit();
        }
    }
}
