using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using ZaraE2E.Core.Utils;
namespace ZaraE2E.Pages
{
    public class MenuPage : BasePage
    {
        public MenuPage(IWebDriver driver) : base(driver) { }

        private IWebElement Menu => WaitForElement(By.CssSelector("svg[class='layout-header-icon__icon']"));
        private IWebElement ErkekMenu => WaitForElement(By.XPath("(//span[text()='ERKEK'])[1]"));
        private IWebElement TumunuGor => WaitForElement(By.XPath("(//span[text()='TÜMÜNÜ GÖR'])[1]"));
        public void GoToMenuAll()
        {
            Logger.Info("Erkek kategorisine gidiliyor");
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("svg[class='layout-header-icon__icon']")));
            Logger.Info("Menüye tıklanıyor");
            Click(Menu);
            ErkekMenu.Click();
            Logger.Info("Erkek menü seçildi");

            ScrollDown();
            TumunuGor.Click();
            Logger.Info("Tümünü Gör seçildi");
            Thread.Sleep(2000);
        
        }
    }
}
