using Bl.Interfaces;

namespace Bl.SalaryCalculator
{
    public class ContractorSalaryCalculator : ISalaryCalculator
    {
        public double Calculate(double salary)
        {
            return salary;
        }
    }
}