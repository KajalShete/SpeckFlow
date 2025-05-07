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
    public sealed class DDT_WithSceanrioOutline:BaseStepDefinitions
    {
        String actURL = "https://irpbusinessapp2309-tst-cin.azurewebsites.net/TilesHome";
        [Given(@"I navigate to the IRP login page")]
        public void givenINavigateToTheIRPLoginPage()
        {
            driver.Navigate().GoToUrl("https://irpbusinessapp2309-tst-cin.azurewebsites.net");
            driver.Manage().Window.Maximize();
            driver.SwitchTo().Window(driver.WindowHandles.Last());

        }

        [When(@"I enter the following user credentials")]
        public void WhenIEnterTheFollowingUserCredentials(Table table)
        {
            foreach (var row in table.Rows)
            {
                var username = row["Username"];
                var password = row["Password"];
                driver.FindElement(By.Id("userNameInput")).SendKeys(username);
                driver.FindElement(By.Id("passwordInput")).SendKeys(password);

            }
        }

        [When(@"I click the login button")]
        public void WhenIClickTheLoginButton()
        {
            Thread.Sleep(5000);
            driver.FindElement(By.Id("btnLogin")).Click();
        }

        [Then(@"I should see the dashboard page")]
        public void ThenIShouldSeeTheDashboardPage()
        {
            Thread.Sleep(5000);
            String exptURL = driver.Url;
            Assert.IsTrue(exptURL.Contains(actURL),"URL not Same");
        }

    }
}
