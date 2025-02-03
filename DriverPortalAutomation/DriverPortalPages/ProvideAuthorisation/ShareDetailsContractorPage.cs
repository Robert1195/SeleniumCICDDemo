using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverPortalAutomation.DriverPortalPages.ProvideAuthorisation
{
    internal class ShareDetailsContractorPage(IWebDriver driver)
    {
        private readonly IWebDriver driver = driver;
        IWebElement PermanentMemberCheckbox => driver.CustomFindElement(By.Id("IsPermanentMember"));
        IWebElement ContinueBtn => driver.CustomFindElement(By.CssSelector("button[type='submit']"));
        IWebElement DepartmentField => driver.CustomFindElement(By.Id("Department"));

        public void EnterContractorDetails(string department) 
        {
            PermanentMemberCheckbox.Click();
            DepartmentField.EnterText(department);
            ContinueBtn.Click();
        }

    }
}
