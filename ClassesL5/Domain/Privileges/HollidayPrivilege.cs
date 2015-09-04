using System;
using Domain.Interfaces;
using Domain.Persons;

namespace Domain.Privileges
{
    public class HollidayPrivilege : Privileges<Person>
    {

        public HollidayPrivilege(Person person) : base(person)
        {
        }

        public override void AddPrivilege()
        {
            Input.PrivilegeList.Add(new PersonPrivilege("Holiday Privelege" , Input));
            Input.AddPrivilege();
            Console.WriteLine("Added HollidayPrivilege");
            Logger.Logger.AddToLog("Added HollidayPrivilege");
        }
    }
}