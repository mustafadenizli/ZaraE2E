using NUnit.Framework;
using ZaraE2E.Pages;
using ZaraE2E.Utils;
using ZaraE2E.Core.Utils;
using System;

namespace ZaraE2E.Tests
{
    public class NavigateTests : BaseTest
    {
        [Test]
        public void ZaraShoppingFlow()
        {
            var homePage = new HomePage(Driver);
            var cookiesPage = new CookiesPage(Driver);
            var menuPage = new MenuPage(Driver);
            var searchPage = new SearchPage(Driver);
            var productPage = new ProductPage(Driver);
            var cartPage = new CartPage(Driver);

            
            homePage.GoToHomePage();
            cookiesPage.AcceptCookies();
            /*homePage.ClickLogin();

            var loginPage = new LoginPage(Driver);
            loginPage.WaitForLoginPage(Driver);
            //loginPage.Login("tam@testinium.com", "???");
            loginPage.userControl();
            */
            
            menuPage.GoToMenuAll();

            Logger.Info("Ürün arama yapiliyor");
            string keyword1 = ExcelHelper.ReadCell("TestData/Search.xlsx", 0, 0);
            searchPage.Search(keyword1);
            searchPage.ClearSearch();

            string keyword2 = ExcelHelper.ReadCell("TestData/Search.xlsx", 0, 1);
            searchPage.SearchWithEnter(keyword2);

            var products = Driver.FindElements(OpenQA.Selenium.By.XPath("//ul[@class='product-grid__product-list']/li"));
            var rnd = new Random();
            products[rnd.Next(products.Count)].Click();
            
            string productName = productPage.GetProductName();
            string productPrice = productPage.GetProductPrice();
            productPage.SaveProductInfo("TestData/ProductInfo.txt");

            productPage.AddToCart();
            productPage.SelectSize();

            cartPage.ClickCart();
            Assert.That(cartPage.GetCartProductPrice(), Is.EqualTo(productPrice), "Fiyatlar eşleşmiyor");

            cartPage.UpdateQuantity();
            decimal initialPrice = decimal.Parse(productPrice.Split(' ')[0]);
            decimal cartPrice = decimal.Parse(cartPage.GetCartProductPrice().Split(' ')[0]);

            Assert.That(cartPrice, Is.EqualTo(initialPrice * 2), "Fiyat çarpimi yanliş olabilir");

            cartPage.DeleteProduct();
            Assert.That(cartPage.IsCartEmpty(), "Sepet boş değil");

        }
    }
}
