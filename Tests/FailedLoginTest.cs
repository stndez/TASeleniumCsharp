using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumCsharpPractice.Tests
{
    class FailedLoginTest
    {
        IWebDriver driver;

        [SetUp]
        public void BrowserInitialization()
        {
            // Local Selenium WebDriver
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Sample()
        {
            Assert.Pass();
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}
