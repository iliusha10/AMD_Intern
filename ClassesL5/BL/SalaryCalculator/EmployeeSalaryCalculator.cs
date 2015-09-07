using BL.Interfaces;

namespace BL.SalaryCalculator
{
    public class EmployeeSalaryCalculator : ISalaryCalculator
    {
        private readonly double Bonus = 300;

        public double Calculate(double salary)
        {
            return salary + Bonus;
        }
    }
}