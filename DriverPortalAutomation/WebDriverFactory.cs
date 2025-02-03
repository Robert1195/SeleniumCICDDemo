using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace DotnetSelenium
{
    public static class WebDriverFactory
    {
        public static IWebDriver CreateWebDriver(string browser, bool isHeadless)
        {
            return browser.ToLower() switch
            {
                "chrome" => CreateChromeDriver(isHeadless),
                "firefox" => CreateFirefoxDriver(isHeadless),
                "edge" => CreateEdgeDriver(isHeadless),
                _ => throw new ArgumentException($"Unsupported browser: {browser}")
            };
        }

        private static IWebDriver CreateChromeDriver(bool isHeadless)
        {
            var options = new ChromeOptions();
            if (isHeadless)
            {
                options.AddArgument("--headless");
                options.AddArgument("--disable-gpu");
                options.AddArgument("--no-sandbox");
                options.AddArgument("--disable-dev-shm-usage");
            }
            return new ChromeDriver(options);
        }

        private static IWebDriver CreateFirefoxDriver(bool isHeadless)
        {
            var options = new FirefoxOptions();
            if (isHeadless)
            {
                options.AddArgument("-headless");
            }
            return new FirefoxDriver(options);
        }

        private static IWebDriver CreateEdgeDriver(bool isHeadless)
        {
            var options = new EdgeOptions();
            if (isHeadless)
            {
                options.AddArgument("--headless");
                options.AddArgument("--disable-gpu");
                options.AddArgument("--no-sandbox");
                options.AddArgument("--disable-dev-shm-usage");
            }
            return new EdgeDriver(options);
        }
    }
}
