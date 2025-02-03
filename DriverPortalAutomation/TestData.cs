using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DriverPortalAutomation.TestData
    
{
    public static class TestDataProvider
    {
    public static IEnumerable<TestCaseData> ProvideAuthLoginData
    {
        get
        {
            yield return new TestCaseData("074540/862765", "L99ANF", "ZJALj", "robert.szewczyk@parkingeye.co.uk", "Test department", "Robert Test");
        }
    }

    public static IEnumerable<TestCaseData> ProvideAuthThirdPartyData
    {
            get
            {
            yield return new TestCaseData("074540/862765", "L99ANF", "Robert Szewczyk", "23 Brentlea Avenue", "Wakefield", "robert.szewczyk@parkingeye.co.uk", "WF2 7SE");
        }
    }
}
}
