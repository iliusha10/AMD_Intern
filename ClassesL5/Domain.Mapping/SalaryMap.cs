using Domain.CompanyAssets;

namespace Domain.Mapping
{
    internal class SalaryMap : EntityMap<Salary>
    {
        #region Public members

        public SalaryMap()
        {
            HasOne(x => x.Contractor);
            Map(x => x.Amount).Not.Nullable();
            Map(x => x.Bonus);
            
        }

        #endregion
    }
}