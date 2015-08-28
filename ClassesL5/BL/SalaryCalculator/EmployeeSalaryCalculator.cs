using Bl.Interfaces;

namespace Bl.SalaryCalculator
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