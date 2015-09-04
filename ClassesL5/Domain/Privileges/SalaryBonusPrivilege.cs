using System;
using Domain.Interfaces;
using Domain.Persons;

namespace Domain.Privileges
{
    public class SalaryBonusPrivilege : Privileges<Person>
    {
        public SalaryBonusPrivilege(Person person)
            : base(person)
        {
        }

        public override void AddPrivilege()
        {

            Input.PrivilegeList.Add(new PersonPrivilege("Salary Bonus", Input));
         
            Input.AddPrivilege();

            Console.WriteLine("Added SalaryBonusPrivilege");
            
            Logger.Logger.AddToLog("Added SalaryBonusPrivilege");
        }
    }
}