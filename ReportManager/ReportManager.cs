using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace Utilities
{
    public static class ReportManager
    {
        private static ExtentReports _extent;
        private static ExtentSparkReporter _htmlReporter;
        private static string _reportPath;
        public static ExtentTest CurrentTest { get; private set; }

        static ReportManager()
        {
            // Report's path
            _reportPath = $"{AppDomain.CurrentDomain.BaseDirectory}TestReport.html";

            // Report's configuration
            _htmlReporter = new ExtentSparkReporter(_reportPath);
            _htmlReporter.Config.DocumentTitle = "Driver Portal Test Report";
            _htmlReporter.Config.ReportName = "Test Execution Report";

            _extent = new ExtentReports();
            _extent.AttachReporter(_htmlReporter);

            // Operating system details
            _extent.AddSystemInfo("Operating System", Environment.OSVersion.ToString());
            _extent.AddSystemInfo("Browser", Environment.GetEnvironmentVariable("BROWSER") ?? "Chrome");
            _extent.AddSystemInfo("Tester", "Your Name");
        }

        public static ExtentReports GetExtent()
        {
            return _extent;
        }

        public static void StartTest(string testName, string description = null)
        {
            CurrentTest = _extent.CreateTest(testName, description);
        }
        //public static ExtentTest CreateTest(string testName, string? description = null)
        //{
        //    return _extent.CreateTest(testName, description);
        //}

        public static void Flush()
        {
            _extent.Flush();
        }
    }
}
