using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumCsharpPractice.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumCsharpPractice.Tests
{
    class SuccessLoginTest
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void NavigateToLoginSite()
        {
            // Local Selenium WebDriver
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [Test, Description("Successful Login")]
        [TestCase("standard_user")]
        [TestCase("problem_user")]
        [TestCase("performance_glitch_user")]
        public void ShouldBeAbleToLoginSuccessfully(string username)
        {
            var login = new LoginPage(driver);
            login.EnterCredentialsAndLogin(username, "secret_sauce");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            var homepage = new HomePage(driver);
            Assert.IsTrue(homepage.IsNavigatedToHomePage());
        }

        [TearDown]
        public void Logout()
        {
            var homepage = new HomePage(driver);
            homepage.LogoutFromSite();
        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}
