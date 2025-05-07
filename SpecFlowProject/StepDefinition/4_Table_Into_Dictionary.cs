using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProject.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinition
{
    [Binding]
    public sealed class Table_Into_Dictionary:BaseStepDefinitions
    {
        [Given(@"Navigate to LogIn Page")]
        public void GivenNavigateToLogInPage()
        {
            driver.Navigate().GoToUrl("https://irpbusinessapp2309-tst-cin.azurewebsites.net/");
            driver.Manage().Window.Maximize();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

        [When(@"User Successfully Login and Log out")]
        public void WhenUserSuccessfullyLoginAndLogOut(Table table)
        {
            var creadentialList = TableExtensions.ToListOfDictionaries(table);

            foreach (var credentials in creadentialList)
            {
                string username = credentials["Username"];
                string password = credentials["Password"];

                driver.FindElement(By.Id("userNameInput")).Clear();
                driver.FindElement(By.Id("userNameInput")).SendKeys(username);
               
                driver.FindElement(By.Id("passwordInput")).Clear();
                driver.FindElement(By.Id("passwordInput")).SendKeys(password);
                Thread.Sleep(5000);

                driver.FindElement(By.Id("btnLogin")).Click();
                Thread.Sleep(5000);

                string actHP = driver.Url;
                string expHP = "https://irpbusinessapp2309-tst-cin.azurewebsites.net/TilesHome";
                Assert.IsTrue(actHP.Contains(expHP), "Home page not display");

                driver.FindElement(By.Id("btnLogout")).Click();
                Thread.Sleep(5000);

                string actLP = driver.Url;
                string expLP = "https://irpbusinessapp2309-tst-cin.azurewebsites.net/";
                Assert.IsTrue(actLP.Contains(expLP), "Log in page not display");

            }
        }

    }
}
