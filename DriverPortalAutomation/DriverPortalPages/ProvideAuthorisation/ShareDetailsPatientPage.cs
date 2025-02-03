using OpenQA.Selenium;

namespace DriverPortalAutomation.DriverPortalPages.ProvideAuthorisation
{
    internal class ShareDetailsPatientPage(IWebDriver driver)
    {
        private readonly IWebDriver driver = driver;

        IWebElement DepartmentField => driver.CustomFindElement(By.Id("Department"));
        IWebElement ContinueBtn => driver.CustomFindElement(By.CssSelector("button[type='submit']"));


        public void ClickContinueBtn()
        {
            ContinueBtn.SubmitElement();
        }

        public void EnterDepartment(string department)
        {
            DepartmentField.EnterText(department);
            ClickContinueBtn();
        }
    }
}
