using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumCsharpPractice.PageObjects
{
    class LoginPage
    {
        public IWebDriver driver;
        private WebDriverWait wait;
        Int32 timeout = 10000; // in milliseconds

        //Locators
        private By userNameTextfield = By.CssSelector("#user-name");
        private By passwordTextfield = By.CssSelector("#password");
        private By loginBtn = By.CssSelector("#login-button");
        private By loginErrorMsg = By.CssSelector("[data-test='error']");
        private By loginErrorMsgX = By.CssSelector(".error-button");

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void EnterUsername(string username)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(userNameTextfield));
            driver.FindElement(userNameTextfield).SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(passwordTextfield));
            driver.FindElement(passwordTextfield).SendKeys(password);
        }

        public void ClickLoginButton()
        {
            driver.FindElement(loginBtn).Click();
        }

        public void EnterCredentialsAndLogin(string username, string password)
        {
            EnterUsername(username);
            EnterPassword(password);
            ClickLoginButton();
        }

        public string LoginErrorMessage()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(loginErrorMsg));
            return driver.FindElement(loginErrorMsg).Text;
        }

        public void CloseLoginErrorMessage()
        {
            driver.FindElement(loginErrorMsgX).Click();
        }
    }
}
