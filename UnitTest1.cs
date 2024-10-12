using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace MSTestDemo
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver;

        [TestMethod]

        public void UC1() 
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://saucedemo.com");

            //Access the username textbox and send standard_user keys.
            IWebElement UserNameTextBox = driver.FindElement(By.XPath("//input[@id='user-name']"));
            UserNameTextBox.SendKeys("honey");

            //Access the password textbox and send the secret_sauce password
            IWebElement PasswordTextBox = driver.FindElement(By.XPath("//input[@id='password']"));
            PasswordTextBox.SendKeys("bey");

            //Clear inputs
            UserNameTextBox.Clear();
            PasswordTextBox.Clear();

            // Wait until both fields are cleared before clicking the login button
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            //wait.Until(driver => string.IsNullOrEmpty(UserNameTextBox.GetAttribute("value")) &&
            //                     string.IsNullOrEmpty(PasswordTextBox.GetAttribute("value")));

            //System.Threading.Thread.Sleep(2000); // Not recommended for production code

            //Click on the Login button
           
            IWebElement LoginButton = driver.FindElement(By.XPath("//input[@id='login-button']"));
           // LoginButton.Click();


        }

        [TestMethod]
        public void UC3()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://saucedemo.com");

            //Access the username textbox and send standard_user keys.
            IWebElement UserNameTextBox = driver.FindElement(By.XPath("//input[@id='user-name']"));
            UserNameTextBox.SendKeys("standard_user");

            //Access the password textbox and send the secret_sauce password
            IWebElement PasswordTextBox = driver.FindElement(By.XPath("//input[@id='password']"));
            PasswordTextBox.SendKeys("secret_sauce");

            //Click on the Login button
            IWebElement LoginButton = driver.FindElement(By.XPath("//input[@id='login-button']"));
            LoginButton.Click();

            // Wait for the page to load and validate the dashboard title
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //Find the dashboard title element and get the text
            string dashboardTitle = driver.Title;

            //Assertion to validate the title of the page
            Assert.AreEqual("Swag Labs", dashboardTitle, "The page title doesn´t match the expected value.");

        }
    }
}