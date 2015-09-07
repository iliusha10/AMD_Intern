using Domain.Company;

namespace Domain.Mapping
{
    internal class SalaryMap : EntityMap<Salary>
    {
        #region Public members

        public SalaryMap()
        {
            References(x => x.Contractor).Unique();
            Map(x => x.Bonus);
            Map(x => x.Amount).Not.Nullable();
        }

        #endregion
    }
}