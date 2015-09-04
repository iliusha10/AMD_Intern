using System;
using System.Collections.Generic;
using Domain.Persons;
using Domain.Row;

namespace Repository.Interfaces
{
    public interface IPersonRepository : IRepository
    {
        void AddPerson(IEnumerable<Person> personsList);
        void UpdatePerson(long id, string fname = null, string lname = null, string bdate = null);
        void DeletePerson(long id);

        IList<Person> GetAll();
        IList<Person> GetPersonSkillsByFirstname(string firstname);
        IList<Person> GetPersonByTaskName(string taskname);
        IList<EmployeDetails> GetEmployeeDetails1();
        string GetPersonLastnameById(long id);
        IList<PersonWithSkillsCount> GetPersonRowsHavingMoreThanOneSkill();
        IList<object[]> GetAllFirstAndLastNames_ProjectionList();
        IList<Person> GetAllPersonsWithSkills();
        IList<Person> GetPersonByLNameOrByFName(string lastname, string firstname);
    }
}