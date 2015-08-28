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

        public Person CreatePerson(string fname, string lname, string bdate)
        {
            var person = new Person(fname, lname, bdate);
            OnInternCreation(person);
            return person;
        }

        public Person CreatePersonWSkills(string fname, string lname, string bdate, Dictionary<string, int> skillsDictionary)
        {
            var person = new Person(fname, lname, bdate, skillsDictionary);
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