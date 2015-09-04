using Domain.Interfaces;
using Domain.Persons;

namespace Domain.Privileges
{
    public class PersonPrivileges<TPrivileges> where TPrivileges : IPrivileges
    {
        public PersonPrivileges()
        {
        }

        public virtual string PrivilegeName { get; set; }
        public virtual Person Person { get; set; }
    }
}