using OpenQA.Selenium;

namespace DriverPortalAutomation.DriverPortalPages.ProvideAuthorisation
{
    internal class ShareDetailsSubmitPage(IWebDriver driver)
    {
        private readonly IWebDriver driver = driver;

        IWebElement FullNameField => driver.CustomFindElement(By.Id("FullName"));
        IWebElement AgreeCheckbox => driver.CustomFindElement(By.Id("AgreeToAuthorise"));
        IWebElement SubmitBtn => driver.CustomFindElement(By.CssSelector("button[type='submit']"));


        public void ClickAgreeCheckbox()
        {
            AgreeCheckbox.ClickElement();
        }

        public void EnterFullName(string fullName)
        {
            FullNameField.EnterText(fullName);
        }

        public void SubmitForm(string fullName)
        {
            ClickAgreeCheckbox();
            EnterFullName(fullName);
            SubmitBtn.SubmitElement();
        }
    }


}
