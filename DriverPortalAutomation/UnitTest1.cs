using DotnetSelenium;
using DriverPortalAutomation.DriverPortalPages;
using DriverPortalAutomation.DriverPortalPages.ProvideAuthorisation;
using OpenQA.Selenium;
using Utilities;
using DriverPortalAutomation.TestData;



namespace DriverPortalAutomation
{
    public class DriverPortalAutomation()


    {
        private IWebDriver _driver;


        [SetUp]
        public void Setup()
        {
            string browser = Environment.GetEnvironmentVariable("BROWSER") ?? "Chrome";
            bool isHeadless = Environment.GetEnvironmentVariable("HEADLESS")?.ToLower() == "true";

            _driver = WebDriverFactory.CreateWebDriver(browser, isHeadless);
            _driver.Navigate().GoToUrl("https://pe-uks-test-driverportal-web01.azurewebsites.net/");
            _driver.Manage().Window.Maximize();
        }

        [Test]
        [TestCase("12345/12345", "QW12ASD")]
        [Category("smoke")]
        public void TestCase22000(string reference, string plate)
        {
            ReportManager.StartTest("TestCase22000", "'Unable to find parking charge'validation message");

            try
            {
                HomePage homePage = new(_driver);
                homePage.Login(reference, plate);

                Assert.That(homePage.GetErrorMsgTxt(), Is.EqualTo(homePage.ErrorMsgTxt));
                ReportManager.CurrentTest.Pass("Test completed successfully");
            }
            catch (Exception ex)
            {

                ReportManager.CurrentTest.Fail($"Test failed with exception: {ex.Message}");
                Assert.Fail(ex.ToString());
            }
        }

        [Test]
        [TestCase("123/456", "QW12ASD")]
        [Category("smoke")]
        public void TestCase22001(string reference, string plate)
        {
            ReportManager.StartTest("TestCase22001", "Invalid Parking Charge Reference - validation message");

            try
            {
                HomePage homePage = new(_driver);
                homePage.Login(reference, plate);
                Assert.That(homePage.GetReferenceValidationTxt(), Is.EqualTo(homePage.IncorrectReferenceValidationTxt));
                ReportManager.CurrentTest.Pass("Test completed successfully");
            }
            catch (Exception ex)
            {

                ReportManager.CurrentTest.Fail($"Test failed with exception: {ex.Message}");
                Assert.Fail(ex.ToString());
            }
        }

        [Test]
        [TestCase(" ", " ")]
        [Category("smoke")]
        // Empty input fields - validation message
        public void TestCase22034(string reference, string plate)
        {
            ReportManager.StartTest("TestCase22034", " Empty input fields - validation message");

            try
            {
                HomePage homePage = new(_driver);
                homePage.Login(reference, plate);
                Assert.Multiple(() =>
                {
                    Assert.That(homePage.GetEmptyReferenceValidationTxt(), Is.EqualTo(homePage.EmptyReferenceValidationTxt));
                    Assert.That(homePage.GetEmptyRegistrationValidationTxt(), Is.EqualTo(homePage.EmptyRegistrationValidationTxt));
                });
                ReportManager.CurrentTest.Pass("Test completed successfully");
            }
            catch (Exception ex)
            {

                ReportManager.CurrentTest.Fail($"Test failed with exception: {ex.Message}");
                Assert.Fail(ex.ToString());
            }
        }

        [Test]
        [TestCase("396432/344751", "RJ22OFW")]
        [Category("smoke")]
        public void TestCase22035(string reference, string plate)
        {
            ReportManager.StartTest("TestCase22035", "Successful login");

            try
            {
                HomePage homePage = new(_driver);
                ParkingChargeDetailsPage parkingChargeDetailsPage = new(_driver);

                homePage.Login(reference, plate);
                Assert.Multiple(() =>
                {
                    Assert.That(parkingChargeDetailsPage.IsChargeDetailsHeaderDisplayed, Is.True);
                    Assert.That(parkingChargeDetailsPage.IsActionsHeaderDisplayed, Is.True);
                });
                ReportManager.CurrentTest.Pass("Test completed successfully");
            }
            catch (Exception ex)
            {

                ReportManager.CurrentTest.Fail($"Test failed with exception: {ex.Message}");
                Assert.Fail(ex.ToString());
            }
        }

        [Test]
        [TestCase("396432/344751", "RJ22OFW")]
        public void TestCase16807(string reference, string plate)
        {
            ReportManager.StartTest("TestCase16807", "AZ168 - Driver Portal - View photographic evidence");

            try
            {
                HomePage homePage = new(_driver);
                ParkingChargeDetailsPage parkingChargeDetailsPage = new(_driver);
                EvidencePage evidencePage = new(_driver);

                homePage.Login(reference, plate);
                parkingChargeDetailsPage.ClickViewPhotographicEvidenceBTN();

                Assert.Multiple(() =>
                {
                    Assert.That(evidencePage.IsPhotographicEvidenceHeaderDisplayed, Is.True);
                    Assert.That(evidencePage.IsImageDisplayed, Is.True);
                });
                ReportManager.CurrentTest.Pass("Test completed successfully");
            }
            catch (Exception ex)
            {

                ReportManager.CurrentTest.Fail($"Test failed with exception: {ex.Message}");
                Assert.Fail(ex.ToString());
            }
        }

        [Test]
        // AZ168 - Driver Portal - Welsh translation
        public void TestCase16808()
        {
            ReportManager.StartTest("TestCase16808", "AZ168 - Driver Portal - Welsh translation");

            try
            {
                HomePage homePage = new(_driver);
                homePage.ClickCymraegBtn();
                Assert.That(homePage.IsDriverPortalWelshHeaderDisplayed, Is.True);
                ReportManager.CurrentTest.Pass("Test completed successfully");
            }
            catch (Exception ex)
            {

                ReportManager.CurrentTest.Fail($"Test failed with exception: {ex.Message}");
                Assert.Fail(ex.ToString());
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.ProvideAuthLoginData))]
        //[TestCase("074540/862765", "L99ANF", "ZJALj", "robert.szewczyk@parkingeye.co.uk", "Test department", "Robert Test")]
        [Category("E2E")]
        public void TestCase16844(string reference, string plate, string code, string email, string department, string fullName)
        {
            try
            {
                ReportManager.StartTest("TestCase16844", "AZ168 - Driver Portal - Provide Authorisation - Share details with the site - Patient");

                ProvideAuthE2E provideAuthE2E = new(_driver);
                SubmittedPage submittedPage = new(_driver);

                provideAuthE2E.ProvideAuthShareDetailsPatient(reference, plate, code, email, department, fullName);
                Assert.That(submittedPage.IsAuthSubmittedHeaderDisplayed(), Is.True);
                ReportManager.CurrentTest.Pass("Test completed successfully");
            }
            catch (Exception ex)
            {

                ReportManager.CurrentTest.Fail($"Test failed with exception: {ex.Message}");
                Assert.Fail(ex.ToString());
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.ProvideAuthLoginData))]
        [Category("E2E")]
        public void TestCase16845(string reference, string plate, string code, string email, string department, string fullName)
        {
            try
            {
                ReportManager.StartTest("TestCase16845", "AZ168 - Driver Portal - Provide Authorisation - Share details with the site - Member of staff");

                ProvideAuthE2E provideAuthE2E = new(_driver);
                SubmittedPage submittedPage = new(_driver);

                provideAuthE2E.ProvideAuthShareDetailsStaff(reference, plate, code, email, department, fullName);
                Assert.That(submittedPage.IsAuthSubmittedHeaderDisplayed(), Is.True);
                ReportManager.CurrentTest.Pass("Test completed successfully");
            }
            catch (Exception ex)
            {

                ReportManager.CurrentTest.Fail($"Test failed with exception: {ex.Message}");
                Assert.Fail(ex.ToString());
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.ProvideAuthLoginData))]
        [Category("E2E")]
        public void TestCase16843(string reference, string plate, string code, string email, string department, string fullName)
        {
            try
            {
                ReportManager.StartTest("TestCase16843", "AZ168 - Driver Portal - Provide Authorisation - Payment arrangement");

                ProvideAuthE2E provideAuthE2E = new(_driver);
                SubmittedPage submittedPage = new(_driver);

                provideAuthE2E.ProvideAuthPaymentArrangement(reference, plate, code, email, department, fullName);
                Assert.That(submittedPage.IsAuthSubmittedHeaderDisplayed(), Is.True);
                ReportManager.CurrentTest.Pass("Test completed successfully");
            }
            catch (Exception ex)
            {

                ReportManager.CurrentTest.Fail($"Test failed with exception: {ex.Message}");
                Assert.Fail(ex.ToString());
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.ProvideAuthThirdPartyData))]
        [Category("E2E")]
        public void TestCase16803(string reference, string plate, string name, string address, string town, string email, string postcode)
        {
            try
            {
                ReportManager.StartTest("TestCase16803", "AZ168 - Driver Portal - Provide Authorisation - Third party - Registered Keeper");

                ProvideAuthE2E provideAuthE2E = new(_driver);
                SubmittedPage submittedPage = new(_driver);

                provideAuthE2E.ProvideAuthThirdPartyKeeper(reference, plate, name, address, town, email, postcode);
                Assert.That(submittedPage.IsAuthSubmittedHeaderDisplayed(), Is.True);
                ReportManager.CurrentTest.Pass("Test completed successfully");
            }
            catch (Exception ex)
            {

                ReportManager.CurrentTest.Fail($"Test failed with exception: {ex.Message}");
                Assert.Fail(ex.ToString());
            }
        }

        [TearDown]
        public void TearDown()
        {
            if (_driver != null)
            {
                try
                {
                    _driver.Quit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error during driver quit: {ex.Message}");
                }
                finally
                {
                    _driver.Dispose();
                }
            }
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            ReportManager.Flush();
        }
    }
}