using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumCsharpPractice.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumCsharpPractice.Tests
{
    class FailedLoginTest
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void BrowserInitialization()
        {
            // Local Selenium WebDriver
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [SetUp]
        public void NavigateToSauceLabs()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [Test]
        public void ShouldNotBeAbleToLoginWhenUsernameIsBlank()
        {
            var login = new LoginPage(driver);
            login.EnterPassword("secret_sauce");
            login.ClickLoginButton();
            Assert.AreEqual("Epic sadface: Username is required", login.LoginErrorMessage());
        }

        [Test]
        public void ShouldNotBeAbleToLoginWhenPasswordIsBlank()
        {
            var login = new LoginPage(driver);
            login.EnterUsername("standard_user");
            login.ClickLoginButton();
            Assert.AreEqual("Epic sadface: Password is required", login.LoginErrorMessage());
        }

        [Test]
        public void ShouldNotBeAbleToLoginWhenBothFieldsAreBlank()
        {
            var login = new LoginPage(driver);
            login.ClickLoginButton();
            Assert.AreEqual("Epic sadface: Username is required", login.LoginErrorMessage());
        }

        [Test]
        public void ShouldNotBeAbleToLoginWhenUsernameAndPasswordDoesNotMatch()
        {
            var login = new LoginPage(driver);
            login.EnterCredentialsAndLogin("standard_user", "secret_saucee");
            Assert.AreEqual("Epic sadface: Username and password do not match any user in this service", login.LoginErrorMessage());
        }

        [Test]
        public void ShouldNotBeAbleToLoginForLockedUser()
        {
            var login = new LoginPage(driver);
            login.EnterCredentialsAndLogin("locked_out_user", "secret_sauce");
            Assert.AreEqual("Epic sadface: Sorry, this user has been locked out.", login.LoginErrorMessage());
        }

        [TearDown]
        public void CloseErrorMessage()
        {
            var login = new LoginPage(driver);
            login.CloseLoginErrorMessage();
        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}
