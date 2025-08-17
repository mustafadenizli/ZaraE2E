using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace ZaraE2E.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver Driver;
        protected WebDriverWait Wait;
        private readonly int defaultTimeout = 10;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
        protected void Click(IWebElement element)
        {   
            element.Click();
        }

        protected IWebElement WaitForElement(By locator, int? timeoutInSeconds = null)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds ?? defaultTimeout));
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        protected IWebElement WaitForClickable(By locator, int timeoutInSeconds = 15)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        protected IWebElement WaitForElementExists(By locator, int? timeoutInSeconds = null)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds ?? defaultTimeout));
            return wait.Until(ExpectedConditions.ElementExists(locator));
        }

        protected void Type(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        protected string GetText(IWebElement element)
        {
            return element.Text;
        }

        protected bool IsDisplayed(IWebElement element)
        {
            try
            {
                return element.Displayed;
            }
            catch
            {
                return false;
            }
        }
        public void ScrollDown()
        {
            var menuContainer = Driver.FindElement(By.XPath("(//ul[@class='layout-categories__level-n-category-list'])[2]")); // kendi selector'ını kullan

            // JavaScript ile scroll et
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("arguments[0].scrollTop = 100;", menuContainer);
            Thread.Sleep(1000);
        }

        public void ScrollUp()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("window.scrollBy(0,-60);");
        }

        public void ClickWithActions(By locator)
        {
            var element = WaitForElement(locator);
            Console.WriteLine($"Moving to element and clicking: {locator}");
            Actions actions = new Actions(Driver);
            actions.MoveToElement(element).Click().Perform();
        }

        public void Hover(string Locator)
        {
            IWebElement product = Driver.FindElement(By.CssSelector(Locator));
            Actions actions = new Actions(Driver);
            actions.MoveToElement(product).Perform();
            Thread.Sleep(1000);
        }
    }
}
