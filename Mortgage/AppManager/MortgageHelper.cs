using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System.Threading.Tasks;

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
            SelectBank(data);
            driver.FindElement(By.CssSelector("[testing-id='OUTSTANDING_AMOUNT'] input")).Click();
            driver.FindElement(By.CssSelector("[testing-id='OUTSTANDING_AMOUNT'] input")).Clear();
            driver.FindElement(By.CssSelector("[testing-id='OUTSTANDING_AMOUNT'] input")).SendKeys(data.OutstandingAmount);
            driver.FindElement(By.CssSelector("[testing-id='ANNUAL_INTEREST_RATE'] input")).SendKeys(data.AnnualInterestRate);
            driver.FindElement(By.CssSelector("[testing-id='LOAN_START_CONTRACT_DATE'] input")).SendKeys(data.DateCreditStart);
            driver.FindElement(By.CssSelector("[testing-id='LOAN_END_CONTRACT_DATE'] input")).SendKeys(data.DateCreditEnd);
            driver.FindElement(By.CssSelector("[testing-id='MORTGAGE_DESIRED_START_DATE_POLICY'] input")).SendKeys(data.DatePolicyStart);
        }

        private void SelectBank(MortgageData data)
        {
            driver.FindElement(By.CssSelector("[testing-id='BANK_NAME']")).Click();
            ICollection<IWebElement> button = driver.FindElements(By.CssSelector("[role='listbox'] button"));
            //TO DO подумать как прокинуть exeption если кнопки не найдется
            foreach (IWebElement buttonElement in button)
            {
                if (buttonElement.Text == data.Bank)
                {
                    buttonElement.Click();
                    return;
                }
            }
        }

        public void InitBuyPolicy()
        {
            string currentTab = driver.CurrentWindowHandle;
            driver.FindElement(By.CssSelector("a[href='https://www.vsk.ru/klientam/dvs/ipoteka']")).Click();
            ICollection<string> existingTabs = driver.WindowHandles;
            foreach (string tab in existingTabs)
            {
                if (tab != currentTab && existingTabs.Count <= 2)
                {
                    driver.SwitchTo().Window(tab);
                }
            }
            //List<string> tabs = new List<string>(driver.WindowHandles);
            //driver.SwitchTo().Window(tabs[1]);
        }
    }
}
