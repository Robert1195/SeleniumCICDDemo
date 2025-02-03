using OpenQA.Selenium;

namespace DriverPortalAutomation.DriverPortalPages
{
    internal class EvidencePage(IWebDriver driver)
    {
        private readonly IWebDriver driver = driver;

        IWebElement PhotographicEvidenceHeader => driver.CustomFindElement(By.XPath("//h2[text()='Photographic evidence']"));
        IWebElement Image => driver.CustomFindElement(By.XPath("//div[@id='content']//img[1]"));

        public bool IsPhotographicEvidenceHeaderDisplayed()
        {
            return PhotographicEvidenceHeader.Displayed;
        }
        public bool IsImageDisplayed()
        {
            return Image.Displayed;
        }
    }
}
