using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinition
{
    [Binding]
    public sealed class IRPLoginFunctionality:BaseStepDefinitions
    {
        String expUrl = "https://irpbusinessapp2309-tst-cin.azurewebsites.net/TilesHome";
        String actUrl;
        String expTitle = "Welcome"; String actTitle;


        [Given(@"Open IRP Application")]
        public void OpenIRPApplication()
        {
            //ChromeOptions options = new ChromeOptions();
            //options.AddArguments("--remote-allow-origins");
            //driver = new ChromeDriver(options);

            driver.Navigate().GoToUrl("https://irpbusinessapp2309-tst-cin.azurewebsites.net");
            driver.Manage().Window.Maximize();
            Thread.Sleep(5000);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

        [When(@"the user enters valid userName")]
        public void WhenTheUserEntersValidUserName()
        {
            Thread.Sleep(5000);
            IWebElement usernameField = driver.FindElement(By.Id("userNameInput"));
            usernameField.SendKeys("kshete@symtrax.in");
        }

        [When(@"the user enters valid password")]
        public void WhenTheUserEntersValidPassword()
        {
            IWebElement passwordField = driver.FindElement(By.Id("passwordInput"));
            passwordField.SendKeys("Kajal@123");
        }

        [When(@"clicks the login button")]
        public void WhenClicksTheLoginButton()
        {
            Thread.Sleep(5000);
            IWebElement loginButton = driver.FindElement(By.Id("btnLogin"));
            loginButton.Click();
        }


        [Then(@"the user should redirected to the IRP home page")]
        public void ThenTheUserShouldRedirectedToTheIRPHomePage()
        {
            //actUrl = driver.Url;
            //Assert.AreEqual(expUrl, actUrl);
            actTitle = driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[2]/div[2]/div/div/div[1]/div[1]/span[1]")).Text;
            Assert.AreEqual(expTitle, actTitle);
        }


        [Then(@"click on logout button")]
        public void ThenClickOnLogoutButton()
        {
            IWebElement loginButton = driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[1]/div/div/button"));
            loginButton.Click();
        }


        [When(@"I enter invalid userName")]
        public void WhenIEnterInvalidUserName()
        {
            IWebElement usernameField = driver.FindElement(By.Id("userNameInput"));
            usernameField.SendKeys("kshete@symtrax");
        }

        [When(@"I enter invalid password")]
        public void WhenIEnterInvalidPassword()
        {
            IWebElement passwordField = driver.FindElement(By.Id("passwordInput"));
            passwordField.SendKeys("Kajal");
        }

        [When(@"Click on login")]
        public void WhenClickOnLogin()
        {
            Thread.Sleep(5000);
            IWebElement loginButton = driver.FindElement(By.Id("btnLogin"));
            loginButton.Click();
        }

        [Then(@"Dashboard page should not open")]
        public void ThenDashboardPageShouldNotOpen()
        {
            Thread.Sleep(5000);
            actUrl = driver.Url;
            Assert.AreNotEqual(expUrl, actUrl);
            Console.WriteLine("Current Home Page URL:" + actUrl);
        }

      
    }
}
