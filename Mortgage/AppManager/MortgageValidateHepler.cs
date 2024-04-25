using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageTests
{
    public class MortgageValidateHepler :HelperBase
    {
        //Для повышения читаемости кода в тестах, по продукту "Ипотека"
        //создан специальный класс MortgageValidateHepler который будет содержать методы
        //реализующие валидацию данных в соответствии с тестовым сценарием
        public MortgageValidateHepler(AppManager manager) : base(manager) { }   

        public void FillingFieldsMortgageValidate(MortgageData creationData, MortgageData existingData)
        {
            //Проверка VerifyFieldDatePolicyEnd вынесена в if поскольку при отрицательном результате
            //не имеет смысла идти дальше, т.к. значение из поля тянется в блок условий.
            if (manager.Mortgage.VerifyFieldDatePolicyEnd(creationData))
            {
                Assert.AreEqual(creationData, existingData);
                Assert.IsTrue(manager.Mortgage.VerifyEmptyPolicySum(existingData));
                Assert.IsTrue(manager.Mortgage.GoToStepProcessingButtonIsActive());
            }
        }
    }
}
