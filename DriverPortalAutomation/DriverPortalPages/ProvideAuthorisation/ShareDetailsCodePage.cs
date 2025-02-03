using OpenQA.Selenium;

namespace DriverPortalAutomation.DriverPortalPages.ProvideAuthorisation
{
    internal class ShareDetailsCodePage(IWebDriver driver)
    {
        private readonly IWebDriver driver = driver;

        IWebElement AccessCodeFiled => driver.CustomFindElement(By.Id("AccessCode"));
        IWebElement EmailFiled => driver.CustomFindElement(By.Id("EmailAddress"));
        IWebElement ContinueBtn => driver.CustomFindElement(By.CssSelector("button[type='submit']"));

        public void EnterCodeAndEmail(string code, string email)
        {
            AccessCodeFiled.EnterText(code);
            EmailFiled.EnterText(email);
            ContinueBtn.SubmitElement();
        }
    }
}
