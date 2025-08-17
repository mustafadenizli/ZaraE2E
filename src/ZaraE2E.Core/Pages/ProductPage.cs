using OpenQA.Selenium;
using System;
using System.IO;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;
//using NUnit.Framework.Internal;
using ZaraE2E.Core.Utils;

namespace ZaraE2E.Pages
{
    public class ProductPage : BasePage
    {
        public ProductPage(IWebDriver driver) : base(driver) { }

        private IWebElement ProductName => WaitForElement(By.CssSelector("h1[class='product-detail-info__header-name']"));
        private IWebElement ProductPrice => WaitForElement(By.CssSelector("span[class='money-amount__main']"));
        private IWebElement AddToCartButton => WaitForElement(By.CssSelector("button[data-qa-action='add-to-cart']"));
        private IWebElement SizeSelection => WaitForElement(By.XPath("(//div[@data-qa-qualifier='size-selector-sizes-size-label'])[2]"));

        public string GetProductName() => ProductName.Text;
        public string GetProductPrice() => ProductPrice.Text;
        public void SaveProductInfo(string filePath)
        {
            Logger.Info("Ürün name ve price'i dosyaya yaziliyor");
            var name = GetProductName();
            Console.WriteLine($"Product Name: {name}");
            var price = GetProductPrice();
            Console.WriteLine($"Price: {price}");
            File.WriteAllText(filePath, $"{name} - {price}");
        }

        public void AddToCart()
        {
            Logger.Info("Ürün sepete ekleniyor");
            Click(AddToCartButton);
            Logger.Info("Ürün sepete eklendi");
        }

        public void SelectSize()
        {
            Click(SizeSelection);
            Thread.Sleep(1500);
        }
    }
}
