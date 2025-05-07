using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome; // Specify the desired browser driver
using System;
using TechTalk.SpecFlow;

namespace LoginTest
{
   public class Program
    {
        
      public  static void main(string[] args)

        {
            String expUrl = "https://irpbusinessapp2309-tst-cin.azurewebsites.net/TilesHome";
            String actUrl;
            IWebDriver driver = new ChromeDriver(); // Initialize the WebDriver

            try
            {
                driver.Navigate().GoToUrl("https://irpbusinessapp2309-tst-cin.azurewebsites.net/jobs/jobsgrid"); // Replace with actual login page URL

                // Locate elements using appropriate locator strategies
                IWebElement usernameField = driver.FindElement(By.Id("userNameInput"));
                IWebElement passwordField = driver.FindElement(By.Name("passwordInput"));
                IWebElement loginButton = driver.FindElement(By.XPath("/html/body/div[1]/div[2]/form/div[3]/button"));

                // Enter credentials
                usernameField.SendKeys("kshete@symtrax.in");
                passwordField.SendKeys("Kajal@123");

                // Click the login button
                loginButton.Click();

                // Verify successful login (example)
                actUrl = driver.Url;
                Assert.AreEqual(expUrl, actUrl);
            }
            finally
            {
                // Close the browser (important for resource cleanup)
                driver.Quit();
            }
        }
    }
}
