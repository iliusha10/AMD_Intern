using Bl.Interfaces;

namespace Bl.SalaryCalculator
{
    public class SalaryCalculator
    {
        private ISalaryCalculator _salaryCalculator;

        public double Calculate(double salary, ISalaryCalculator salaryCalculator)
        {
            _salaryCalculator = salaryCalculator;
            return _salaryCalculator.Calculate(salary);
        }
    }
}