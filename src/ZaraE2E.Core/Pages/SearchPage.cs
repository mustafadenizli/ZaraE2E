using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using ZaraE2E.Core.Utils;

namespace ZaraE2E.Pages
{
    public class SearchPage : BasePage
    {
        public SearchPage(IWebDriver driver) : base(driver) { }

        private IWebElement SearchInput => WaitForElement(By.CssSelector("span[class='layout-header-action-search__content']"));
        private IWebElement SearchInput2 => WaitForElement(By.Id("search-home-form-combo-input"));


        public void Search(string keyword)
        {
            Logger.Info("Ürün aramasi yapiliyor");
            Click(SearchInput);
            Click(SearchInput2);
            Type(SearchInput2, keyword);
        }

        public void ClearSearch()
        {
            SearchInput2.SendKeys(Keys.Control + "a");
            SearchInput2.SendKeys(Keys.Delete);
        }

        public void SearchWithEnter(string keyword)
        {
            Click(SearchInput2);
            Type(SearchInput2, keyword);
            new Actions(Driver).SendKeys(Keys.Enter).Perform();
            Logger.Info("Ürün aramasi yapildi - Gömlek kategorisine gidildi");
            Thread.Sleep(2000);
        }
    }
}
