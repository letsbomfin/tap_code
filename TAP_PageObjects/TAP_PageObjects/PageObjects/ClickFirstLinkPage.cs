using OpenQA.Selenium;

namespace TAP_PageObjects.PageObjects
{
    class ClickFirstLinkPage : PageBase
    {
        public ClickFirstLinkPage(IWebDriver driver)
           : base(driver)
        {
        }

        public void ClickLick()
        {
            var textLink = _driver.FindElement(By.XPath("//a[contains(@href, 'http://dextra.com.br/pt/blog/page-objects-padrao-de-projeto-para-organizacao-de-testes-funcionais/')]"));

            textLink.Click();
        }

        public override void GoTo()
        {
            GoToPath("/#/login");
        }
    }
}
