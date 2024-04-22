using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageTests
{
    public class NavigationHelper : HelperBase
    {
        public NavigationHelper(AppManager manager) : base(manager) { }

        public void OpenMortgagePage()
        {
            driver.Url = manager.baseURL + "/ipoteka";
            Thread.Sleep(1500);
        }
    }
}
