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
            MortgageData data = new MortgageData()
            {
                Bank = "ПАО СБЕРБАНК",
                BalanceDebt = "5555444",
                BidPercent = "20",
                DateCreditStart = DateTime.Now.AddDays(7).ToString("dd.MM.yyyy"),
                DateCreditEnd = DateTime.Now.AddDays(7).AddYears(20).ToString("dd.MM.yyyy"),
                DatePolicyStart = DateTime.Now.AddDays(7).ToString("dd.MM.yyyy")
            };
            app.Navigator.OpenMortgagePage();
            app.Mortgage.CreatePolicy(data);
        }
    }
}
