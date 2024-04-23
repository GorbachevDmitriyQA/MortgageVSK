using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace MortgageTests
{
    public class AppManager 
    {
        protected IWebDriver driver;
        public IDictionary<string, object> vars { get; private set; }
        public string baseURL;
        public AppManager()
        {

            ChromeOptions options = new ChromeOptions();
            options.BinaryLocation = @"c:\program files (x86)\google\chrome\application\chrome.exe";
            options.AddArgument("start-maximized");
            options.AddExtension(@"c:\Users\Dmitry\source\repos\GorbachevDmitriyQA\morrtgage\Mortgage\Mortgage\Browsec-VPN.crx");
            string vpn = @"c:\Users\Dmitry\source\repos\GorbachevDmitriyQA\morrtgage\Mortgage\Mortgage\Browsec-VPN.crx";
            options.AddArgument(vpn);
            baseURL = "https://www.vsk.ru/klientam";
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.Url = baseURL;
            Navigator = new NavigationHelper(this);
            Mortgage = new MortgageHelper(this);
        }
        public IWebDriver Driver
        {
            get { return driver; }
        }

        public NavigationHelper Navigator { get; set; }
        public MortgageHelper Mortgage { get; set; }
    }

}
