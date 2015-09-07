using BL.Interfaces;

namespace BL.SalaryCalculator
{
    public class ContractorSalaryCalculator : ISalaryCalculator
    {
        public double Calculate(double salary)
        {
            return salary;
        }
    }
}