using Domain.Domain;
using FluentNHibernate.Mapping;

namespace Domain.Mapping
{
    public class ContractorMap : SubclassMap<Contractor>
    {
        public ContractorMap()
        {
            Map(x => x.Salary).Not.Nullable();
            Map(x => x.WorkExp).Not.Nullable();
        }
    }
}