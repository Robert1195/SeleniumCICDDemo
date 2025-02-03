using OpenQA.Selenium;

namespace DriverPortalAutomation.DriverPortalPages.ProvideAuthorisation
{
    internal class ShareDetailsPage(IWebDriver driver)
    {
        private readonly IWebDriver driver = driver;

        IWebElement PatientOption => driver.CustomFindElement(By.Id("OptionPatient"));
        IWebElement StaffOption => driver.CustomFindElement(By.Id("OptionContractor"));
        IWebElement ContinueBtn => driver.CustomFindElement(By.CssSelector("button[type='submit']"));

        public void SelectPatientOption()
        {
            PatientOption.ClickElement();
            ClickContinueBtn();
        }

        public void SelectStaffOption()
        {
            StaffOption.ClickElement();
            ClickContinueBtn();
        }


        public void ClickContinueBtn()
        {
            ContinueBtn.SubmitElement();
        }
    }
}
