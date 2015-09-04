using Domain.Persons;
using FluentNHibernate.Mapping;

namespace Domain.Mapping
{
    public class InternMap : SubclassMap<Intern>
    {
        public InternMap()
        {
            //References(x => x.Company).Not.Nullable();
           Map(x => x.AverageMark).Not.Nullable();
        }
    }
}