using System;
using System.Collections.Generic;
using Domain.Interfaces;

namespace Domain.Domain
{
    public class Director : Person, IPrivileges, IAppointment, INotify
    {
        public Director(string fName, string lName, string bdate, Dictionary<string, int> skillsDictionary, IList<Privileges.Privileges> privilegeList, Address address, Company company)
            : base(fName, lName, bdate, skillsDictionary, privilegeList, address, company)
        {
        }

        public void AddPrivilege()
        {
            Console.WriteLine("I'm Director");
        }

        public void NewAppontment(DateTime apointmenTime)
        {
            Console.WriteLine("I'm waiting you at {0}", apointmenTime);
        }


        public void Inform(Project p)
        {
            Console.WriteLine("Director: All company must work on new project!");
        }
    }
}