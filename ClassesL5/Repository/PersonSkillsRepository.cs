using System;
using System.Collections.Generic;
using Domain.CompanyAssets;
using NHibernate.Criterion;
using Repository.Interfaces;

namespace Repository
{

    public class PersonSkillsRepository : Repository, IPersonSkillsRepository
    {
        public IList<PersonSkills> GetPersonSkillsByFirstname(string firstname)
        {
            return _session.QueryOver<PersonSkills>().List();
        }
    }
}