using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Domain;

namespace Domain.Mapping
{
    class PrivilegeMap: EntityMap<PersonSkills>
    {
        #region Public members

        public PrivilegeMap()
        {
            References(x => x.Person);
            Map(x => x.Name).Not.Nullable();
        }

        #endregion
    }
}