using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;

namespace MortgageTests
{
    public class MortgageHelper : HelperBase
    {
        public MortgageHelper(AppManager manager) : base(manager) { }

        public void CreatePolicy(MortgageData data)
        {
            InitBuyPolicy();
            FillPolicyForm(data);
        }

        private void FillPolicyForm(MortgageData data)
        {
            //SelectBank(data);
            driver.FindElement(By.CssSelector("[testing-id='OUTSTANDING_AMOUNT'] input")).Click();
            driver.FindElement(By.CssSelector("[testing-id='OUTSTANDING_AMOUNT'] input")).Clear();
            driver.FindElement(By.CssSelector("[testing-id='OUTSTANDING_AMOUNT'] input")).SendKeys(data.BalanceDebt);
            driver.FindElement(By.CssSelector("[testing-id='ANNUAL_INTEREST_RATE'] input")).SendKeys(data.BidPercent);
            driver.FindElement(By.CssSelector("[testing-id='LOAN_START_CONTRACT_DATE'] input")).SendKeys(data.DateCreditStart);
            driver.FindElement(By.CssSelector("[testing-id='LOAN_END_CONTRACT_DATE'] input")).SendKeys(data.DateCreditEnd);
            driver.FindElement(By.CssSelector("[testing-id='MORTGAGE_DESIRED_START_DATE_POLICY'] input")).SendKeys(data.DatePolicyStart);
        }

        private void SelectBank(MortgageData data)
        {
            //driver.FindElement(By.CssSelector("[testing-id='BANK_NAME']")).Click();
            new SelectElement(driver.FindElement(By.CssSelector("tui-select[testing-id='BANK_NAME']"))).SelectByText(data.Bank);
        }

        public void InitBuyPolicy()
        {
            driver.FindElement(By.CssSelector("a[class = 'vsk-text-22-bold banner-link fill ng-star-inserted']")).Click();
            List<string> tabs = new List<string>(driver.WindowHandles);
            driver.SwitchTo().Window(tabs[1]);
        }
    }
}
