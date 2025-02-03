using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Utilities;

namespace DriverPortalAutomation
{
    internal static class SeleniumCustomMethods
    {
        public static IWebElement WaitForElement(this IWebDriver driver, By locator)
        {
            int timeoutInSeconds = 10; 
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
        }

        public static IWebElement CustomFindElement(this IWebDriver driver, By locator)
        {
            ReportManager.CurrentTest.Log(Status.Info, $"Finding element with locator: {locator}");
            IWebElement element = driver.WaitForElement(locator);
            return element;
        }


        public static void ClickElement(this IWebElement webElement)
        {
            ReportManager.CurrentTest.Log(Status.Info, $"Clicking on element");
            webElement.Click();
        }

        public static void EnterText(this IWebElement webElement, string text)
        {
            ReportManager.CurrentTest.Log(Status.Info, $"Entering text '{text}' into element");
            webElement.SendKeys(text);
        }

        public static void SubmitElement(this IWebElement webElement)
        {
            ReportManager.CurrentTest.Log(Status.Info, $"Submitting the form using element");
            webElement.Submit();
            
        }

        public static bool IsElementDisplayed(this IWebElement webElement)
        {
            ReportManager.CurrentTest.Log(Status.Info, "Checking if element is displayed");
            return webElement.Displayed;
        }

        public static SelectElement SelectDropdownByText(this IWebElement webElement, string text)
        {
            SelectElement multiSelectElement = new(webElement);
            multiSelectElement.SelectByText(text);
            return multiSelectElement;
        }

        public static void SelectDropdownByValue(this IWebElement webElement, string value)
        {
            SelectElement multiSelectElement = new(webElement);
            multiSelectElement.SelectByValue(value);
        }

        public static void ScrollToElement(this IWebDriver driver, IWebElement webElement)
        {
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].scrollIntoView(true);", webElement);
                ReportManager.CurrentTest.Log(Status.Info, "Scrolled to element.");
            }
            catch (Exception ex)
            {
                ReportManager.CurrentTest.Log(Status.Fail, $"Failed to scroll to element. Error: {ex.Message}");
                throw;
            }
        }


        public static SelectElement MultiSelectDropdownByText(this IWebElement webElement, string[] values)
        {
            // Znajdujemy element listy wielokrotnego wyboru
            SelectElement multiSelectElement = new(webElement);

            // Iterujemy przez tablicę wartości i wybieramy każdą z nich
            foreach (string text in values)
            {
                multiSelectElement.SelectByText(text);
            }

            return multiSelectElement;
        }

        public static List<string> GetAllSelectedOptions(this IWebElement webElement)
        {
            List<string> options = [];
            SelectElement multiSelectElement = new(webElement);
            IList<IWebElement> selectedOptions = multiSelectElement.AllSelectedOptions;

            foreach (IWebElement option in selectedOptions)
            {
                options.Add(option.Text);
            }

            return options;
        }

    }
}
