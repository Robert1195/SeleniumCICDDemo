using OpenQA.Selenium;

namespace DriverPortalAutomation.DriverPortalPages.ProvideAuthorisation
{
    internal class ProvideAuthE2E(IWebDriver driver)
    {
        private readonly IWebDriver driver = driver;

        HomePage homePage = new(driver);
        ParkingChargeDetailsPage parkingChargeDetailsPage = new(driver);
        ProvideAuthPage provideAuthPage = new(driver);
        ShareDetailsPage shareDetailsPage = new(driver);
        ShareDetailsCodePage shareDetailsCodePage = new(driver);
        ShareDetailsPatientPage shareDetailsPatientPage = new(driver);
        ShareDetailsSubmitPage shareDetailsSubmitPage = new(driver);
        ShareDetailsContractorPage shareDetailsContractorPage = new(driver);
        ThirdPartyPage thirdPartyPage = new(driver);
        ThirdPartyDetailsPage thirdPartyDetailsPage = new(driver);

        public void LoginAndClickProvideAuth(string reference, string plate)
        {
            homePage.Login(reference, plate);
            parkingChargeDetailsPage.ClickProvideAuthBtn();
        }

        public void LoginAndSelectThirdParty(string reference, string plate)
        {
            LoginAndClickProvideAuth(reference, plate);
            provideAuthPage.SelectThirdPartyOption();
        }

        public void ProvideAuthThirdPartyKeeper(string reference, string plate, string name, string address, string town, string email, string postcode)
        {
            LoginAndSelectThirdParty(reference, plate);
            thirdPartyPage.FillForm(name, address, town, email, postcode);
            thirdPartyDetailsPage.FillForm(name, address, town, email, postcode);
            shareDetailsSubmitPage.SubmitForm(name);
        }

        public void ProvideAuthShareDetailsPatient(string reference, string plate, string code, string email, string department, string fullName)
        {
            LoginAndClickProvideAuth(reference, plate);
            provideAuthPage.SelectShareDetailOption();
            shareDetailsPage.SelectPatientOption();
            shareDetailsCodePage.EnterCodeAndEmail(code, email);
            shareDetailsPatientPage.EnterDepartment(department);
            shareDetailsSubmitPage.SubmitForm(fullName);
        }

        public void ProvideAuthShareDetailsStaff(string reference, string plate, string code, string email, string department, string fullName)
        {
            LoginAndClickProvideAuth(reference, plate);
            provideAuthPage.SelectShareDetailOption();
            shareDetailsPage.SelectStaffOption();
            shareDetailsCodePage.EnterCodeAndEmail(code, email);
            shareDetailsContractorPage.EnterContractorDetails(department);
            shareDetailsSubmitPage.SubmitForm(fullName);
        }

        public void ProvideAuthPaymentArrangement(string reference, string plate, string code, string email, string department, string fullName)
        {
            LoginAndClickProvideAuth(reference, plate);
            provideAuthPage.SelectPaymentArrangementOption();
            shareDetailsCodePage.EnterCodeAndEmail(code, email);
            shareDetailsSubmitPage.SubmitForm(fullName);
        }
    }
}
