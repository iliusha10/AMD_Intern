using System.Collections.Generic;
using Domain.Domain;

namespace Repository.Interfaces
{
    public interface IPersonRepository : IRepository
    {
        void AddPerson(IEnumerable<Person> personsList);
        void UpdatePerson(long id, string fname = null, string lname = null, string bdate = null);
        void DeletePerson(long id);

        IList<Person> GetAll();
    }
}