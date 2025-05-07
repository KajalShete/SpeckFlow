using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinition
{
    [Binding]
    public sealed class ParameterizingWithoutExampleKeyword:BaseStepDefinitions
    {

        String actURl = "https://irpbusinessapp2309-tst-cin.azurewebsites.net/TilesHome";
        [Given(@"Open IRP Application Login page")]
        public void GivenOpenIRPApplicationLoginPage()
        {
            driver.Navigate().GoToUrl("https://irpbusinessapp2309-tst-cin.azurewebsites.net");
            driver.Manage().Window.Maximize();
            driver.SwitchTo().Window(driver.WindowHandles.Last());

        }

        [When(@"the user enters valid '(.*)' and '(.*)'")]
        public void WhenTheUserEntersValidAnd(string username, string password)
        {
            driver.FindElement(By.Id("userNameInput")).SendKeys(username);
            driver.FindElement(By.Id("passwordInput")).SendKeys(password);
        }

        [When(@"click the login button")]
        public void WhenClickTheLoginButton()
        {
            Thread.Sleep(5000);
            driver.FindElement(By.Id("btnLogin")).Click();
        }

        [Then(@"the user should navigate to the IRP home page")]
        public void ThenTheUserShouldNavigateToTheIRPHomePage()
        {
            Thread.Sleep(5000);
            String expURL = driver.Url;
            Assert.IsTrue(expURL.Contains(actURl), "URL not same");
        }

        [Then(@"click on logout button to exit from IRP Application")]
        public void ThenClickOnLogoutButtonToExitFromIRPApplication()
        {
            driver.FindElement(By.Id("btnLogout")).Click();
        }

    }
}
