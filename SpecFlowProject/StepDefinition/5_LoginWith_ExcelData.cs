using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowProject.StepDefinition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

[Binding]
public class LoginWith_ExcelData : BaseStepDefinitions
{
    private List<Dictionary<string, string>> excelData;

    //Constructor to initialize the excel data
    //This ensures Excel data is loaded once when the class instance is created rather than multiple times.
    public LoginWith_ExcelData()
    {
        LoginSteps(); // Call LoginSteps to load the Excel data
    }

    public void LoginSteps()
    {
        string filePath = @"C:\Users\Kshete\OneDrive - SYMTRAX\Documents\WorkSpace\SpecFlow\SpecFlow Project\SpecFlowProject - Excel\SpecFlowProject\UserCredential.xlsx";
        excelData = ExcelReaderHelper.ReadExcelData(filePath, "Sheet1", 0, 2);
    }

    [Given(@"I navigate to the login page")]
    public void GivenINavigateToTheLoginPage()
    {
        driver.Navigate().GoToUrl("https://irpbusinessapp2309-tst-cin.azurewebsites.net");
        driver.Manage().Window.Maximize();
        driver.SwitchTo().Window(driver.WindowHandles.Last());
    }

    [When(@"I log in by enter username and password from Excel")]
    public void WhenILogInByEnterUsernameAndPasswordFromExcel()
    {
        // Ensure excelData is not null before accessing it
        if (excelData != null)
        {
            foreach (var data in excelData)
            {
                string username = data["Username"];
                string password = data["Password"];
                Thread.Sleep(2000);
                // Enter username and password
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
        else
        {
            Assert.Fail("Excel data is null");
        }
    }

   
   
}
