using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

public class BaseStepDefinitions
{
    protected IWebDriver driver;

    [BeforeScenario]
    public void Initialize()
    {
        driver = new ChromeDriver(@"C:\Automation\Compleo Suite\CompleoIRP\Input\ChromeDriver");
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
    }

    [AfterScenario]
    public void Cleanup()
    {
        if (driver != null)
        {
            driver.Quit();
        }
    }
}
