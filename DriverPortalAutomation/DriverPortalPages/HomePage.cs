using OpenQA.Selenium;

namespace DriverPortalAutomation.DriverPortalPages
{
    public class HomePage(IWebDriver driver)
    {
        private readonly IWebDriver driver = driver;

        public readonly string ErrorMsgTxt = "We have been unable to find your parking charge. Please check you have entered your details correctly.\r\n" +
            "If you have received a Notice to Driver (i.e. a ticket affixed to your vehicle) then please allow 24 hours from the issue date prior to attempting payment.";

        public readonly string IncorrectReferenceValidationTxt = "Please check that you have entered your Parking Charge Reference exactly as it is displayed on your parking " +
            "charge (e.g. 123456/654321).";
        public readonly string EmptyReferenceValidationTxt = "Please enter your Parking Charge Reference";

        public readonly string EmptyRegistrationValidationTxt = "Please enter your Vehicle Registration Number";

        IWebElement ReferenceField => driver.CustomFindElement(By.Id("Reference"));
        IWebElement RegistrationField => driver.CustomFindElement(By.Id("Plate"));
        IWebElement ContinueBtn => driver.CustomFindElement(By.CssSelector("button[type='submit']"));
        IWebElement ErrorMsg => driver.CustomFindElement(By.XPath("//div[@class='flash-error']"));
        IWebElement ReferenceValidationError => driver.CustomFindElement(By.CssSelector(".field-validation-error"));
        IWebElement EmptyReferenceValidationError => driver.CustomFindElement(By.CssSelector(".field-validation-error[data-valmsg-for='Reference']"));
        IWebElement EmptyRegistrationValidationError => driver.CustomFindElement(By.CssSelector(".field-validation-error[data-valmsg-for='Plate']"));
        IWebElement CymraegBtn => driver.CustomFindElement(By.LinkText("Cymraeg"));
        IWebElement DriverPortalWelshHeader => driver.CustomFindElement(By.XPath("//h1[text()='Porth Gyrwyr']"));

        public void Login(string reference, string plate)
        {
            ReferenceField.EnterText(reference);
            RegistrationField.EnterText(plate);
            ContinueBtn.SubmitElement();
        }

        public string GetErrorMsgTxt()
        {
            return ErrorMsg.Text;
        }

        public string GetReferenceValidationTxt()
        {
            return ReferenceValidationError.Text;
        }

        public string GetIncorrectReferenceValidationTxt() 
        {
            return ReferenceValidationError.Text;
        }

        public string GetEmptyReferenceValidationTxt()
        {
            return EmptyReferenceValidationError.Text;
        }

        public string GetEmptyRegistrationValidationTxt()
        {
            return EmptyRegistrationValidationError.Text;
        }

        public void ClickCymraegBtn()
        {
            CymraegBtn.ClickElement();
        }

        public bool IsDriverPortalWelshHeaderDisplayed()
        {
            return DriverPortalWelshHeader.Displayed;
        }







    }
}
