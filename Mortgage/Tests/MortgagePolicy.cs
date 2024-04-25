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
        /// <summary>
        /// Основной кейс описанный в тестовом задании. 
        /// Примечание: сумма полиса будет пустая без выбора "Типа страхования"
        /// по данной причине проверки реализованы с учетом пустой суммы
        /// </summary>
        [Test]
        public void FillingFieldsMortgagePolicy()
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
            app.Mortgage.FillPolicyFields(creationData);
            MortgageData existingData = app.Mortgage.ConditionMortgagePolicyInfo();
            app.MortgageValidator.FillingFieldsMortgageValidate(creationData, existingData);


        }
    }
}
