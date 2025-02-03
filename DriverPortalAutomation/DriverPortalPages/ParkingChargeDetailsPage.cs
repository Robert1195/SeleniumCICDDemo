using OpenQA.Selenium;

namespace DriverPortalAutomation.DriverPortalPages
{
    internal class ParkingChargeDetailsPage(IWebDriver driver)
    {
        private readonly IWebDriver driver = driver;

        IWebElement ChargeDetailsHeader => driver.CustomFindElement(By.XPath("//h1[text()='Parking charge details']"));
        IWebElement ActionsHeader => driver.CustomFindElement(By.XPath("//h2[text()='Actions']"));
        IWebElement ViewPhotographicEvidenceBTN => driver.CustomFindElement(By.XPath("//a[text()='View photographic evidence']"));
        IWebElement ProvideAuthBtn => driver.CustomFindElement(By.LinkText("Provide authorisation"));

        public bool IsChargeDetailsHeaderDisplayed()
        {
            return ChargeDetailsHeader.IsElementDisplayed();
        }
        public bool IsActionsHeaderDisplayed()
        {
            return ActionsHeader.IsElementDisplayed();
        }

        public void ClickViewPhotographicEvidenceBTN()
        {
            ViewPhotographicEvidenceBTN.ClickElement();
        }

        public void ClickProvideAuthBtn() 
        {
            ProvideAuthBtn.ClickElement();
        }

    }


}
