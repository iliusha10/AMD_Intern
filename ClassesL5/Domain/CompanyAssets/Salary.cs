using System;
using Domain.Persons;

namespace Domain.CompanyAssets
{
    public class Salary : Entity
    {
        public Salary(double amount, double bonus)
        {
            Bonus = bonus;
            Amount = amount;
        }

        [Obsolete]
        protected Salary()
        {
        }

        public virtual double Bonus { get; protected set; }
        public virtual double Amount { get; protected set; }
        public virtual Contractor Contractor { get; protected set; }

        public virtual void ChangeSalary(double amount, double bonus)
        {
            Bonus = bonus;
            Amount = amount;
        }

        public virtual void ChangeSalary(double amount)
        {
            Amount = amount;
        }
    }
}