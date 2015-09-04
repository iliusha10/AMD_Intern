using System;
using Domain.Interfaces;
using Domain.Persons;

namespace Domain.Privileges
{
    public class LunchTichetsPrivilege : Privileges<Person>
    {
        public LunchTichetsPrivilege(Person person) : base(person)
        {
        }

        public override void AddPrivilege()
        {
            Input.PrivilegeList.Add(new PersonPrivilege("Lunch Tickets", Input));
            Input.AddPrivilege();
            Console.WriteLine("Added LunchTichetsPrivilege");
            Logger.Logger.AddToLog("Added LunchTichetsPrivilege");
        }
    }
}