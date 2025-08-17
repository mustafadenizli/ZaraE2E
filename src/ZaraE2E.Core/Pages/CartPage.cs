using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using ZaraE2E.Core.Utils;

namespace ZaraE2E.Pages
{
    public class CartPage : BasePage
    {
        public CartPage(IWebDriver driver) : base(driver) { }
        private IWebElement GoToCart => WaitForElement(By.CssSelector("button[class='zds-button add-to-cart-notification-content__cart-button zds-button--secondary zds-button--small']"));
        private IWebElement CartProductName => WaitForElement(By.CssSelector("a[class='shop-cart-item-header__description-link link']"));
        private IWebElement CartProductPrice => WaitForElement(By.XPath("(//div[@class='shop-cart-item-pricing__current'])//span"));
        private IWebElement AddOrderItem => WaitForElement(By.CssSelector("div[data-qa-id='add-order-item-unit']"));
        private IWebElement DeleteButton => WaitForElement(By.CssSelector("button[data-qa-action='remove-order-item']"));
        private IWebElement isEmptyCart => WaitForElement(By.CssSelector("div[class='zds-empty-state__title']>span"));



        public string GetCartProductName() => CartProductName.Text;
        public string GetCartProductPrice() => CartProductPrice.Text;

        public void ClickCart()
        {
            Logger.Info("sepete gidiliyor");
            Click(GoToCart);
        }

        public void UpdateQuantity()
        {
            Logger.Info("Ürün adedi 2 yapiliyor");
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("window.scrollBy(0, 160);");
            Click(AddOrderItem);
            Thread.Sleep(2000);
        }

        public void DeleteProduct()
        {
            Logger.Info("Ürün siliniyor");
            ScrollUp();
            Hover("a[class='shop-cart-item-header__description-link link");
            Click(DeleteButton);
            Logger.Info("Ürün silindi");
        }
        public bool IsCartEmpty()
        {
            return Driver.PageSource.Contains("Sepetiniz boş") || Driver.FindElements(By.CssSelector("shop-cart-item-header__description-link link")).Count == 0;
        }
    }
}
