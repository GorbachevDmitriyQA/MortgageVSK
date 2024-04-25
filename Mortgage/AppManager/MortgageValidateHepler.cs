using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageTests
{
    public class MortgageValidateHepler :HelperBase
    {
        public MortgageValidateHepler(AppManager manager) : base(manager) { }   

        public void FillingFieldsMortgageValidate(MortgageData creationData, MortgageData existingData)
        {
            if (manager.Mortgage.VerifyFieldDatePolicyEnd(creationData))
            {
                Assert.AreEqual(creationData, existingData);
                Assert.IsTrue(manager.Mortgage.VerifyEmptyPolicySum(existingData));
                Assert.IsTrue(manager.Mortgage.GoToStepProcessingButtonIsActive());
            }
        }
    }
}
