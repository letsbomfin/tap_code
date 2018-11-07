using OpenQA.Selenium;


namespace TAP_PageObjects.PageObjects
{
    class SearchGooglePage : PageBase
    {
        public SearchGooglePage(IWebDriver driver)
            :base(driver)
        {
        }

        public void SearchSomething(string text)
        {
            var textField = _driver.FindElement(By.Id("lst-ib"));
            var btnSearch = _driver.FindElement(By.XPath("//input[contains(@value, 'Pesquisa Google')]"));

            textField.SendKeys(text);
            btnSearch.Click();
        }

        public override void GoTo()
        {
            GoToPath("/#/login");
        }

    }
}
