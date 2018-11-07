using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

[SetUpFixture]
class GlobalSetup
{
    public static TimeSpan DefaultTimeout = TimeSpan.FromSeconds(10);
    
    public static IWebDriver Driver { get; private set; }
    public static bool EnableLog { get; internal set; }

    [OneTimeSetUp]
    public void Init()
    {
        var options = new ChromeOptions();
        options.AddArguments("--disable-infobars");
        options.AddUserProfilePreference("credentials_enable_service", false);
        options.AddUserProfilePreference("profile.password_manager_enabled", false);

        var driverService = ChromeDriverService.CreateDefaultService();
        Driver = new ChromeDriver(driverService, options);
        Driver.Manage().Window.Maximize();

        var timeouts = Driver.Manage().Timeouts();
        timeouts.ImplicitWait = DefaultTimeout;
        timeouts.PageLoad = TimeSpan.FromSeconds(15);

        Driver.Navigate().GoToUrl("https://www.google.com/");

    }

    [OneTimeTearDown]
    public static void AssemblyCleanup()
    {
        Driver.Quit();
    }

    private bool? ParseBool(string value)
    {
        try
        {
            return bool.Parse(value);
        }
        catch
        {
            return null;
        }
    }

    private string GetSettings(string key)
           => TestContext.Parameters.Get(key);
}
