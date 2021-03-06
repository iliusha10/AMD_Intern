﻿using System;
using System.Collections.Generic;
using Domain.CompanyAssets;
using Domain.Interfaces;

namespace Domain.Persons
{
    public class Director : Person, IPrivileges, IAppointment, INotify
    {
        public Director(string fName, string lName, string bdate, Dictionary<string, int> skillsDictionary, Address address, Company company)
            : base(fName, lName, bdate, skillsDictionary,  address, company)
        {
        }

        public override PersonType PersonType
        {
            get { return PersonType.Director; }
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