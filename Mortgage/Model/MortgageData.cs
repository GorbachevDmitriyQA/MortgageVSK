using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageTests
{
    public class MortgageData
    {
        public static int DateCreditDaysValue = 0;
        public string Bank {  get; set; }
        public string BalanceDebt { get; set; }
        public string BidPercent { get; set; }
        public string DateCreditStart { get; set; } 
        public string DateCreditEnd { get; set;} 
        public string DatePolicyStart { get; set;}
    }
}
