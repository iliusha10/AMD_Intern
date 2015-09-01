using System;
using System.Collections.Generic;
using Domain.Domain;
using InterfaceActions.Actions;

namespace Factories.Factories
{
    public class PersonFactory
    {
        private readonly IDisplayInfoAction _displayInfoAction;

        public PersonFactory(IDisplayInfoAction displayInfoAction)
        {
            _displayInfoAction = displayInfoAction;
        }

        //public Person CreatePerson(string fname, string lname, string bdate)
        //{
        //    var person = new Person(fname, lname, bdate);
        //    OnInternCreation(person);
        //    return person;
        //}

        public Person CreatePersonWSkills(string fName, string lName, string bdate, Dictionary<string, int> skillsDictionary, IList<Domain.Privileges.Privileges> privilegeList, Address address, Company company)
        {
            var person = new Person(fName, lName, bdate, skillsDictionary, privilegeList, address, company);
            OnInternCreation(person);
            return person;
        }

        public void OnInternCreation(Person person)
        {
            _displayInfoAction.DisplayInfo(person);
            //intern.DisplayAll();
        }
    }
}