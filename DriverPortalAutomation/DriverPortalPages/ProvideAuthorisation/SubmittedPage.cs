using OpenQA.Selenium;

namespace DriverPortalAutomation.DriverPortalPages.ProvideAuthorisation
{
    internal class SubmittedPage(IWebDriver driver)
    {
        private readonly IWebDriver driver = driver;

        IWebElement AuthSubmittedHeader => driver.CustomFindElement(By.XPath("//h1[text()='Electronic authorisation submitted']"));

        public bool IsAuthSubmittedHeaderDisplayed()
        {
            return AuthSubmittedHeader.IsElementDisplayed();
        }
    }
}
