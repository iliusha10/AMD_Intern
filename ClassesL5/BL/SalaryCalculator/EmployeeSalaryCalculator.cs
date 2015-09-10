using BL.Interfaces;

namespace BL.SalaryCalculator
{
    public class EmployeeSalaryCalculator : ISalaryCalculator
    {
        public double Calculate(double salary)
        {
            return salary + salary*0.6;
        }
    }
}