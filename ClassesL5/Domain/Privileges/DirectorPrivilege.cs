using System;
using Domain.Interfaces;
using Domain.Persons;

namespace Domain.Privileges
{
    public class DirectorPrivilege : Privileges<Person>
    {
        public DirectorPrivilege(Person person) : base(person)
        {
        }

        public override void AddPrivilege()
        {
            Input.PrivilegeList.Add(new PersonPrivilege("Director Privilege", Input));
            Input.AddPrivilege();
            Console.WriteLine("Added DirectorPrivilege");
            Logger.Logger.AddToLog("Added DirectorPrivilege");
        }
    }
}