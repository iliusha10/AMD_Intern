using System;
using Domain.Persons;

namespace Domain.Company
{
    public class Salary : Entity
    {
        public Salary(Contractor contractor, double amount, double bonus)
        {
            Contractor = contractor; 
            Bonus = bonus;
            Amount = amount;
        }

        [Obsolete]
        protected Salary()
        {
        }
        public virtual Contractor Contractor { get; protected set; }
        public virtual double Bonus { get; protected set; }
        public virtual double Amount { get; protected set; }
    }
}