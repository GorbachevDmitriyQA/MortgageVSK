using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;

namespace MortgageTests
{
    [TestFixture]
    public class MortgagePolicy :TestBase
    {
        [Test]
        public void CreateMortgagePolicy()
        {
            MortgageData creationData = new MortgageData()
            {
                Bank = "ПАО \"СБЕРБАНК\"",
                OutstandingAmount = "5555444",
                AnnualInterestRate = "20",
                DateCreditStart = DateTime.Now.AddDays(7).ToString("dd.MM.yyyy"),
                DateCreditEnd = DateTime.Now.AddDays(7).AddYears(20).ToString("dd.MM.yyyy"),
                DatePolicyStart = DateTime.Now.AddDays(7).ToString("dd.MM.yyyy"),
                DatePolicyEnd = DateTime.Now.AddDays(6).AddYears(1).ToString("dd.MM.yyyy"),
            };
            app.Navigator.OpenMortgagePage();
            app.Mortgage.CreatePolicy(creationData);
            MortgageData existingData = app.Mortgage.ConditionMortgagePolicyInfo();
            Assert.AreEqual(creationData.DatePolicyEnd, existingData.DatePolicyEnd);

        }
    }
}
