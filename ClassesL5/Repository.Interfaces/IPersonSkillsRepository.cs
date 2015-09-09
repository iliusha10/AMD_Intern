using System.Collections.Generic;
using Domain.CompanyAssets;

namespace Repository.Interfaces
{
    public interface IPersonSkillsRepository : IRepository
    {

        IList<PersonSkills> GetPersonSkillsByFirstname(string firstname);

    }
}