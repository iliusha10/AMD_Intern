using System;
using Domain.Persons;

namespace Domain.Privileges
{
    public class PersonPrivilege:Entity
    {
        [Obsolete]
        protected PersonPrivilege()
        {
        }

        public PersonPrivilege(string privilegeName, Person person)
        {
            PrivilegeName = privilegeName;
            Person = person;
        }

        public virtual string PrivilegeName { get; protected set; }
        public virtual Person Person { get; protected set; }
    }
}