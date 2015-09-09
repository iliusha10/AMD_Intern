using Domain.CompanyAssets;
using Domain.Persons;
using FluentNHibernate.Mapping;

namespace Domain.Mapping
{
    public class ContractorMap : SubclassMap<Contractor>
    {
        public ContractorMap()
        {
            Map(x => x.WorkExp).Not.Nullable();
            HasOne(x => x.Salary).Cascade.SaveUpdate();
            HasMany(x => x.taskList).Cascade.SaveUpdate();
        }
    }
}