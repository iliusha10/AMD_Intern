using Domain.Domain;
using FluentNHibernate.Mapping;

namespace Domain.Mapping
{
    public class ContractorMap : SubclassMap<Contractor>
    {
        public ContractorMap()
        {
            References(x => x.Company).Not.Nullable();
            Map(x => x).Not.Nullable();
        }
    }
}