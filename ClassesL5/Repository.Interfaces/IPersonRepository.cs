using System;
using System.Collections.Generic;
using Domain.CompanyAssets;
using Domain.Persons;
using Domain.Row;

namespace Repository.Interfaces
{
    public interface IPersonRepository : IRepository
    {
        void AddPerson(Person person);
        void UpdateIntern(Person currentIntern, InternDetailsDto newIntern, Company company);
        void UpdateContractor(Person currentContractor, ContractorDetailsDto newContractor, Company newCompany, Salary currentSalary);
        void UpdateEmployee(Person currentEmployee, EmployeeDetailsDto newEmployee, Company newCompany, Salary currentSalary);
        void DeletePerson(long id);

        IList<Person> GetAll();
        IList<Person> GetPersonSkillsByFirstname(string firstname);
        IList<Person> GetPersonByTaskName(string taskname);
        IList<EmployeDetails> GetEmployeeDetails1();
        string GetPersonLastnameById(long id);
        IList<PersonWithSkillsCount> GetPersonRowsHavingMoreThanOneSkill();
        IList<PersonDto> GetAllFirstAndLastNames();
        IList<EmployeeNamesDto> GetAllEmployeeFirstAndLastNames();
        IList<Person> GetAllPersonsWithSkills();
        IList<Person> GetPersonByLNameOrByFName(string lastname, string firstname);
        Person GetPersonId(long id);

        
    }
}