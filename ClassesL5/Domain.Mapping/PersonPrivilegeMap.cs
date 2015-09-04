using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Privileges;

namespace Domain.Mapping
{
    public class PersonPrivilegeMap:EntityMap<PersonPrivilege>
    {
        public PersonPrivilegeMap()
        {
            References(x => x.Person);
            Map(x => x.PrivilegeName);
        }
    }
}
