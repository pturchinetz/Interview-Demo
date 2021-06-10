using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;

namespace EdgeDriverTest1
{
    [TestClass]
    public class EdgeDriverTest
    {
        // In order to run the below test(s), 
        // please follow the instructions from http://go.microsoft.com/fwlink/?LinkId=619687
        // to install Microsoft WebDriver.

        private ChromeDriver _driver;
        private LoginPage loginPage;
        private ProductPage productPage;

        public Tuple<string, string>[] Users = { 
            new Tuple<string, string>("standard_user", "secret_sauce"),
            new Tuple<string, string>("locked_out_user", "secret_sauce")
        };

        [TestInitialize]
        public void EdgeDriverInitialize()
        {
            // Initialize edge driver 
            //var options = new ChromeOptions
            //{
            //    PageLoadStrategy = PageLoadStrategy.Normal
            //};
            _driver = new ChromeDriver("C:/driver");
            loginPage = new LoginPage(_driver);
            productPage = new ProductPage(_driver);
        }

        [TestMethod]
        public void LoginTest()
        {
            _driver.Url = "https://www.saucedemo.com/";
            loginPage.Login(Users[0].Item1, Users[0].Item2);
            Assert.IsTrue(productPage.LogoImage.Displayed);
        }

        [TestMethod]
        public void BadLoginTest()
        {
            _driver.Url = "https://www.saucedemo.com/";
            loginPage.Login(Users[1].Item1, Users[1].Item2);
            try { Assert.IsTrue(loginPage.LoginErrorMessage.Text == "Sorry, this user has been banned."); }
            catch (AssertFailedException e ){ /*log value of loginPage.LoginErrorMessage.Text*/ throw e; }
        }

        [TestCleanup]
        public void EdgeDriverCleanup()
        {
            _driver.Quit();
        }
    }
}
