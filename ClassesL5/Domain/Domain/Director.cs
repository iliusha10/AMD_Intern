using System;
using Domain.Interfaces;

namespace Domain.Domain
{
    public class Director : Person, IPrivileges, IAppointment, INotify
    {
        public Director(string fname, string lname, string bdate)
            : base(fname, lname, bdate)
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