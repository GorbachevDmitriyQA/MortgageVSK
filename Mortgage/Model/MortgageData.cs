using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MortgageTests
{
    public class MortgageData :IEquatable<MortgageData>
    {
        public string Bank {  get; set; }
        public string OutstandingAmount { get; set; }
        public string AnnualInterestRate { get; set; }
        public string DateCreditStart { get; set; } 
        public string DateCreditEnd { get; set;} 
        public string DatePolicyStart { get; set;}
        public string DatePolicyEnd { get; set; }
        public string[] InsurancePeriod { get; set; }
        public string PolicySum { get; set; } 

        public bool Equals(MortgageData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (other.Bank == Bank
                && other.OutstandingAmount == OutstandingAmount
                && other.DatePolicyStart == DatePolicyStart
                && other.DatePolicyEnd == DatePolicyEnd)
            {
                return true;
            }
            return false;

        }

    }
}
