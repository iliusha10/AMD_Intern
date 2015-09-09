using Domain.Persons;
using FluentNHibernate.Mapping;

namespace Domain.Mapping
{
    public class InternMap : SubclassMap<Intern>
    {
        public InternMap()
        {
           Map(x => x.AverageMark).Not.Nullable();
        }
    }
}