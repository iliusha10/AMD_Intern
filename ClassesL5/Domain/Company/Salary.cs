using System;
using Domain.Persons;

namespace Domain.Company
{
    public class Salary : Entity
    {
        public Salary(Contractor contractor, string date, double amount)
        {
            Contractor = contractor; 
            GetDate = DateTime.Parse(date);
            Amount = amount;
        }

        [Obsolete]
        protected Salary()
        {
        }
        public virtual Contractor Contractor { get; protected set; }
        public virtual DateTime GetDate { get; protected set; }
        public virtual double Amount { get; protected set; }
    }
}