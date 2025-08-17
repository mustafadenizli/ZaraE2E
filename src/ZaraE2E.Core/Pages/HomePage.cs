using OpenQA.Selenium;
using ZaraE2E.Core.Utils;
namespace ZaraE2E.Pages
{
    public class HomePage : BasePage
    {
        private readonly string baseUrl = "https://www.zara.com/tr/";

        public HomePage(IWebDriver driver) : base(driver) { }

        public void GoToHomePage()
        {
            Logger.Info("Test başladi");
            Logger.Info("Ana sayfa açiliyor");
            Driver.Navigate().GoToUrl(baseUrl);
            Logger.Info("Ana sayfa açildi");
            
        }

        private IWebElement LoginButton => WaitForElement(By.CssSelector("a[data-qa-id='layout-header-user-logon']"));

        public void ClickLogin()
        {
            //Click(LoginButton);
        }
    }
}
