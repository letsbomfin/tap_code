using NUnit.Framework;

using TAP_PageObjects.PageObjects;

namespace TAP_PageObjects
{
    [TestFixture]
    class SearchGoogle : TestBase
    {
        private SearchGooglePage searchGoogle;
        private ClickFirstLinkPage clickLink;

        [SetUp]
        public override void TestInitialize()
        {
            base.TestInitialize();
            searchGoogle = new SearchGooglePage(driver);
            clickLink = new ClickFirstLinkPage(driver);
        }

        [Test]
        public void SearchOnGoogle()
        {
            searchGoogle.SearchSomething("O que é PageObjects?");
            clickLink.ClickLick();
        }
    }
}
