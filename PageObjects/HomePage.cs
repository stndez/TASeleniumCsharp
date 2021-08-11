using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumCsharpPractice.PageObjects
{
    class HomePage
    {
        public IWebDriver driver;
        private WebDriverWait wait;

        //Locators
        private By hamburgerMenu = By.CssSelector("#react-burger-menu-btn");
        private By logoutLink = By.CssSelector("#logout_sidebar_link");
        private By header = By.CssSelector(".primary_header");

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public bool IsNavigatedToHomePage()
        {

            return driver.FindElement(header).Displayed;
        }

        public void LogoutFromSite()
        {
            driver.FindElement(hamburgerMenu).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(logoutLink));
            driver.FindElement(logoutLink).Click();
        }
    }
}
