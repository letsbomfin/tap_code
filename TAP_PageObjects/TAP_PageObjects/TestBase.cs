using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.IO;


namespace TAP_PageObjects
{
    public abstract class TestBase
    {
        protected IWebDriver driver;
      

        public object LogPath { get; private set; }

        [SetUp]
        public virtual void TestInitialize()
        {
            driver = GlobalSetup.Driver;
        
        }

        [TearDown]
        public void Teardown()
        {
            if (GlobalSetup.EnableLog && TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                var guid = Guid.NewGuid();
                var filePath = $"{LogPath}{TestContext.CurrentContext.Test.FullName}-{DateTime.Today.ToString("yyyy-MM-dd")}";
                TakeScrenshot($"{filePath}_{guid}");
                using (var writer = File.AppendText($"{filePath}.txt"))
                {
                    writer.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\t{guid}\t{TestContext.CurrentContext.Result.Message}");
                }
            }
        }
        protected void TakeScrenshot(string filename)
        {
            var screenshotter = ((ITakesScreenshot)driver).GetScreenshot();
            var format = ScreenshotImageFormat.Jpeg;
            screenshotter.SaveAsFile($"{filename}.{format.ToString().ToLower()}", format);
        }
        protected string GetCurrentPath()
        {
            return new Uri(driver.Url).AbsolutePath;
        }
    }
}
