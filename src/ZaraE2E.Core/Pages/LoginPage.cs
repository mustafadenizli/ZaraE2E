using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace ZaraE2E.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) { }

        private IWebElement EmailField => Driver.FindElement(By.CssSelector("input[data-qa-input-qualifier='logonId']"));
        private IWebElement PasswordField => Driver.FindElement(By.CssSelector("input[data-qa-input-qualifier='password']"));
        private IWebElement SubmitButton => Driver.FindElement(By.CssSelector("button[data-qa-id='logon-form-submit']"));

        private IWebElement userAccount => Driver.FindElement(By.CssSelector("a[data-qa-id='layout-header-user-account']"));

        

        public void WaitForLoginPage(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            wait.Until(drv =>
            {
                try
                {
                    return drv.FindElement(By.CssSelector("input[data-qa-input-qualifier='logonId']")).Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }
        /*public void Login(string email, string password)
        {
            Click(EmailField);
            Type(EmailField, email);
            Click(PasswordField);
            Type(PasswordField, password);
            Click(SubmitButton);
        }

        public void userControl()
        {
            IsDisplayed(userAccount);
        }
        */
    }
}
