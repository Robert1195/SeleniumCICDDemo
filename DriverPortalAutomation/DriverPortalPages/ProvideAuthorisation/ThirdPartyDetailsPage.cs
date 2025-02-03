using OpenQA.Selenium;

namespace DriverPortalAutomation.DriverPortalPages.ProvideAuthorisation
{
    internal class ThirdPartyDetailsPage(IWebDriver driver)
    {
        private readonly IWebDriver driver = driver;

        IWebElement NameField => driver.CustomFindElement(By.Id("ThirdPartyName"));
        IWebElement AddressField => driver.CustomFindElement(By.Id("Address1"));
        IWebElement TownField => driver.CustomFindElement(By.Id("Town"));
        IWebElement PostcodeField => driver.CustomFindElement(By.Id("Postcode"));
        IWebElement EmailField => driver.CustomFindElement(By.Id("ThirdPartyEmailAddress"));
        IWebElement ContinueBtn => driver.CustomFindElement(By.CssSelector("button[type='submit']"));

        public void FillForm(string name, string address, string town, string email, string postcode)
        {
            ContinueBtn.ClickElement();
            NameField.EnterText(name);
            AddressField.EnterText(address);
            TownField.EnterText(town);
            PostcodeField.EnterText(postcode);
            EmailField.EnterText(email);
            ContinueBtn.ClickElement();
        }
    }
}
