using System.Collections.Generic;
using Domain.Company;

namespace Repository.Interfaces
{
    public interface IPersonSkillsRepository : IRepository
    {

        IList<PersonSkills> GetPersonSkillsByFirstname(string firstname);

    }
}