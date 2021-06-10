using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace EdgeDriverTest1
{
    public class LoginPage
    {
        private IWebDriver Driver;

        public LoginPage(IWebDriver driver)
        {
            Driver = driver;
        }

        #region --elements
        public IWebElement UsernameBox { get => Driver.FindElement(By.XPath("//input[@data-test='username']")); }

        public IWebElement PassswordBox { get => Driver.FindElement(By.XPath("//input[@data-test='password']")); }

        public IWebElement LoginButton { get => Driver.FindElement(By.XPath("//input[@data-test='login-button']")); }

        public IWebElement LoginErrorMessage { get => Driver.FindElement(By.XPath("//h3[@data-test='error']")); }
        #endregion

        public void Login(string username, string password)
        {
            UsernameBox.SendKeys(username);
            PassswordBox.SendKeys(password);
            LoginButton.Click();
        }
    }

    public class ProductPage
    {
        private IWebDriver Driver;

        public ProductPage(IWebDriver driver)
        {
            Driver = driver;
        }

        #region --elements
        public IWebElement LogoImage { get => Driver.FindElement(By.XPath("//div[contains(@class, 'app_logo')]")); }
        #endregion

    }
}
