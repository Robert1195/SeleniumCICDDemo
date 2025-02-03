using OpenQA.Selenium;

namespace DriverPortalAutomation.DriverPortalPages.ProvideAuthorisation
{
    internal class ProvideAuthPage(IWebDriver driver)
    {
        private readonly IWebDriver driver = driver;

        IWebElement ShareDetailBtn => driver.CustomFindElement(By.Id("ActionShareDetails"));
        IWebElement PaymentArrangementBtn => driver.CustomFindElement(By.Id("ActionPaymentArrangement"));
        IWebElement ThirdPartyBtn => driver.CustomFindElement(By.Id("ActionThirdParty"));

        IWebElement ContinueBtn => driver.CustomFindElement(By.CssSelector("button[type='submit']"));

        public void SelectShareDetailOption()
        {
            ShareDetailBtn.ClickElement();
            ClickContinueBtn();
        }

        public void SelectPaymentArrangementOption()
        {
            PaymentArrangementBtn.ClickElement();
            ClickContinueBtn();
        }

        public void SelectThirdPartyOption()
        {
            ThirdPartyBtn.ClickElement();
            ClickContinueBtn();
        }

        public void ClickContinueBtn()
        {
            ContinueBtn.SubmitElement();
        }

    }
}
