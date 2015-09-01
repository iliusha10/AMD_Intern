using System;

namespace Domain.Domain
{
    public class Salary : Entity
    {
        public Salary(string date, double amount, Company company)
        {
            GetDate = DateTime.Parse(date);
            Amount = amount;
        }

        [Obsolete]
        protected Salary()
        {
        }

        public virtual DateTime GetDate { get; protected set; }
        public virtual double Amount { get; protected set; }
    }
}