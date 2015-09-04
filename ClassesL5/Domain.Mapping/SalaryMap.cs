using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Company;

namespace Domain.Mapping
{
    class SalaryMap: EntityMap<Salary>
    {
        #region Public members

        public SalaryMap()
        {
            References(x => x.Contractor);
            Map(x => x.GetDate).Not.Nullable();
            Map(x => x.Amount).Not.Nullable();
        }

        #endregion
    }
}