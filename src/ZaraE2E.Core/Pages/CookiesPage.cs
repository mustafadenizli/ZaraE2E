using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ZaraE2E.Core.Utils;
namespace ZaraE2E.Pages
{
    public class CookiesPage : BasePage
    {
        public CookiesPage(IWebDriver driver): base(driver) { }

        private IWebElement AcceptButton => WaitForElement(By.Id("onetrust-accept-btn-handler"));

        public void AcceptCookies()
        {
            Logger.Info("Çerezler kabul ediliyor");
            if (AcceptButton.Displayed)
            {
                AcceptButton.Click();
            }
        }
    }
}
