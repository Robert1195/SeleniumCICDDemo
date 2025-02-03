using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverPortalAutomation.DriverPortalPages.ProvideAuthorisation
{
    internal class ThirdPartyPage(IWebDriver driver)
    {
        private readonly IWebDriver driver = driver;

        IWebElement RegisteredKeeperOption => driver.CustomFindElement(By.Id("RegisteredKeeperType"));
        IWebElement DriverOption => driver.CustomFindElement(By.Id("DriverType"));
        IWebElement HirerOption => driver.CustomFindElement(By.Id("HirerType"));
        IWebElement NameField => driver.CustomFindElement(By.Id("UserName"));
        IWebElement AddressField => driver.CustomFindElement(By.Id("Address1"));
        IWebElement TownField => driver.CustomFindElement(By.Id("Town"));
        IWebElement EmailField => driver.CustomFindElement(By.Id("UserEmailAddress"));
        IWebElement PostcodeField => driver.CustomFindElement(By.Id("Postcode"));
        IWebElement ContinueBtn => driver.CustomFindElement(By.CssSelector("button[type='submit']"));

        public void FillForm(string name, string address, string town, string email, string postcode) 
        {
            ContinueBtn.ClickElement();
            RegisteredKeeperOption.ClickElement();
            NameField.EnterText(name);
            AddressField.EnterText(address);
            TownField.EnterText(town);
            PostcodeField.EnterText(postcode);
            EmailField.EnterText(email);
            ContinueBtn.ClickElement();
        }

    }
}
