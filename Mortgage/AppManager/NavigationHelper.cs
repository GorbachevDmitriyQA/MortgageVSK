using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace MortgageTests
{
    public class NavigationHelper : HelperBase
    {
        public NavigationHelper(AppManager manager) : base(manager) { }

        public void OpenMortgagePage()
        {
            //TO DO добавить ожидаение появления элемента перед нажатием
            driver.FindElement(By.CssSelector("li[id='mortgage']")).Click();
            Thread.Sleep(1500);
        }
    }
}
