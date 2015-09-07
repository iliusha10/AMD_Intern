using BL.SalaryCalculator;
using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    public class EmployeeSalaryCalculatorFixture
    {
        [Test]
        public void EmployeeSalaryCalculatorShouldReturnExpectedValue()
        {
            double Salary = 1500;
            var salEmpl = new EmployeeSalaryCalculator();
            var actual = salEmpl.Calculate(Salary);
            Assert.AreEqual(1500 + 300, actual);
        }
    }
}