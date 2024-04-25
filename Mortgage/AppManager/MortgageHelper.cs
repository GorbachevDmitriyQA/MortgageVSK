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

        public void FillPolicyFields(MortgageData data)
        {
            manager.Navigator.OpenMortgagePage();
            InitBuyPolicy();
            FillPolicyForm(data);
        }

        private void FillPolicyForm(MortgageData data)
        {
            SelectBank(data);
            driver.FindElement(By.CssSelector("[testing-id='OUTSTANDING_AMOUNT'] input")).Click();
            driver.FindElement(By.CssSelector("[testing-id='OUTSTANDING_AMOUNT'] input")).SendKeys(Keys.Home);
            driver.FindElement(By.CssSelector("[testing-id='OUTSTANDING_AMOUNT'] input")).SendKeys(data.OutstandingAmount);
            driver.FindElement(By.CssSelector("[testing-id='ANNUAL_INTEREST_RATE'] input")).SendKeys(Keys.Home);
            driver.FindElement(By.CssSelector("[testing-id='ANNUAL_INTEREST_RATE'] input")).SendKeys(data.AnnualInterestRate);
            driver.FindElement(By.CssSelector("[testing-id='LOAN_START_CONTRACT_DATE'] input")).SendKeys(data.DateCreditStart);
            driver.FindElement(By.CssSelector("[testing-id='LOAN_END_CONTRACT_DATE'] input")).SendKeys(data.DateCreditEnd);
            driver.FindElement(By.CssSelector("[testing-id='MORTGAGE_DESIRED_START_DATE_POLICY'] input")).SendKeys(data.DatePolicyStart);
        }

        private void SelectBank(MortgageData data)
        {
            driver.FindElement(By.CssSelector("[testing-id='BANK_NAME']")).Click();
            ICollection<IWebElement> button = driver.FindElements(By.CssSelector("[role='listbox'] button"));
            foreach (IWebElement buttonElement in button)
            {
                if (buttonElement.Text == data.Bank)
                {
                    buttonElement.Click();
                    return;
                }
                else
                {
                    throw new Exception(data.Bank + "Не найден при заполнении полиса");
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
            // driver.SwitchTo().Window(driver.WindowHandles.Last());
        }
        public MortgageData ConditionMortgagePolicyInfo()
        {
            MortgageData data = new MortgageData();
            data.Bank =
                driver.FindElement(By.XPath("//div[contains(text(),'Банк')]/following-sibling::div")).Text;
            data.InsurancePeriod =
                driver.FindElement(By.XPath("//div[contains(text(),' Срок страхования')]/following-sibling::div"))
                .Text.Split(" ");
            data.DatePolicyStart = data.InsurancePeriod[0];
            data.DatePolicyEnd = data.InsurancePeriod[2];
            data.OutstandingAmount =
                driver.FindElement(By.XPath("//div[contains(text(),'Страховая сумма')]/following-sibling::div"))
                .Text.Replace("₽", "").Replace(" ", "");
            data.PolicySum = driver.FindElement(By.XPath("//div[@testingid='sum']"))
                .GetAttribute("innerText");

            return data;
        }

        public bool VerifyFieldDatePolicyEnd(MortgageData data)
        {
            string trueDatePolicyEnd = driver.FindElement(By.CssSelector("[testing-id='DESIRED_END_DATE_POLICY'] input"))
                .GetAttribute("value");
            if (trueDatePolicyEnd is null)
            {
                return false;
            }
            if (data.DatePolicyEnd == trueDatePolicyEnd)
            {
                return true;
            }
            return false;
        }

        public bool VerifyEmptyPolicySum(MortgageData data)
        {
            if (data.PolicySum == "— ₽")
            {
                return true;
            }
            else return false;
        }

        public bool GoToStepProcessingButtonIsActive()
        {
            bool buttonIsActive = false;

            for (int i = 0; i < 3; i++)
            {
                string willValidateButton = driver.FindElement(By.CssSelector("button[testingid='goToStepProcessing']"))
                    .GetAttribute("disabled");
                if (willValidateButton is null)
                {
                    buttonIsActive = true;
                    break;
                }
                else
                {
                    Thread.Sleep(3000);
                }
            }
            return buttonIsActive;
        }
    }
}
