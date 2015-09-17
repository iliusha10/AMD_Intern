using System;
using System.Collections.Generic;
using System.Linq;
using Domain.CompanyAssets;
using Domain.Persons;
using Domain.Row;
using NHibernate.Criterion;
using NHibernate.Transform;
using Repository.Interfaces;

namespace Repository
{
    public class PersonRepository : Repository, IPersonRepository
    {
        public void AddPerson(IEnumerable<Person> personsList)
        {
            using (var transaction = _session.BeginTransaction())
            {
                try
                {
                    foreach (var person in personsList)
                    {
                        _session.SaveOrUpdate((person));
                        //Console.WriteLine("Inserting person in DB ");
                    }
                    transaction.Commit();
                    Console.WriteLine("Inserting persons in DB Successfull ");
                }
                catch (Exception ex)
                {
                    Logger.Logger.AddToLog("PersonRepository | AddPerson | {0}", ex);
                    transaction.Rollback();
                }
            }
        }

        public void UpdatePerson(long id, string fname = null, string lname = null, string bdate = null)
        {
            using (var transaction = _session.BeginTransaction())
            {
                try
                {
                    var person = _session.Load<Person>(id);
                    if ((fname != null) && (lname != null))
                        person.Rename(fname, lname);

                    if (bdate != null)
                        person.ChangeBDate(bdate);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Logger.Logger.AddToLog("PersonRepository | UpdatePerson | {0}", ex);
                    transaction.Rollback();
                }
            }
        }

        public void DeletePerson(long id)
        {
            using (var transaction = _session.BeginTransaction())
            {
                try
                {
                    var person = _session.Load<Person>(id);
                    _session.Delete(person);
                    transaction.Commit();
 
                }
                catch (Exception ex)
                {
                    Logger.Logger.AddToLog("PersonRepository | DeletePerson | {0}", ex);
                    transaction.Rollback();
                }
            }
        }

        public IList<Person> GetAll()
        {
            using (var tran = _session.BeginTransaction())
            {
                try
                {
                    return _session.QueryOver<Person>().List();
                }
                catch (Exception ex)
                {
                    Logger.Logger.AddToLog("PersonRepository | AddPerson | {0}", ex);
                    tran.Rollback();
                    return null;
                }
            }
        }

        public IList<Person> GetPersonSkillsByFirstname(string firstname)
        {
            using (var tran = _session.BeginTransaction())
            {
                try
                {
                    return _session.QueryOver<PersonSkills>()
                        .JoinQueryOver(skl => skl.Person)
                        .Where(p => p.FName == firstname)
                        .Select(skl => skl.Person)
                        .List<Person>();
                }
                catch (Exception ex)
                {
                    Logger.Logger.AddToLog("PersonRepository | AddPerson | {0}", ex);
                    tran.Rollback();
                    return null;
                }
            }
        }

        public IList<Person> GetPersonByTaskName(string taskname)
        {
            using (var tran = _session.BeginTransaction())
            {
                try
                {
                    Person pers = null;

                    return _session.QueryOver<Task>()
                        .JoinAlias(t => t.Contractor, () => pers)
                        .Where(t => t.TaskName == taskname)
                        .Select(t => t.Contractor)
                        .List<Person>();
                }
                catch (Exception ex)
                {
                    Logger.Logger.AddToLog("PersonRepository | AddPerson | {0}", ex);
                    tran.Rollback();
                    return null;
                }
            }
        }

        public IList<EmployeDetails> GetEmployeeDetails1()
        {
            using (var tran = _session.BeginTransaction())
            {
                try
                {
                    Employee emp = null;
                    PersonSkills skl = null;
                    EmployeDetails row = null;

                    return _session.QueryOver(() => emp)
                        //.JoinAlias(() => pers.Id, () => emp)
                        .JoinAlias(() => emp.SkillsList, () => skl)
                        .SelectList(list => list
                            .Select(() => emp.FName).WithAlias(() => row.Firstname)
                            .Select(() => emp.LName).WithAlias(() => row.Lastname)
                            .Select(() => emp.DateOfBirth).WithAlias(() => row.BirthDate)
                            .Select(() => emp.Department).WithAlias(() => row.Department)
                            .Select(() => emp.Role).WithAlias(() => row.Role)
                            .Select(() => skl.Name).WithAlias(() => row.SkillName)
                            .Select(() => skl.Level).WithAlias(() => row.SkillLevel))
                        .TransformUsing(Transformers.AliasToBean<EmployeDetails>())
                        .List<EmployeDetails>();
                }
                catch (Exception ex)
                {
                    Logger.Logger.AddToLog("PersonRepository | AddPerson | {0}", ex);
                    tran.Rollback();
                    return null;
                }
            }
        }

        public string GetPersonLastnameById(long id)
        {
            using (var tran = _session.BeginTransaction())
            {
                try
                {
                    return _session.QueryOver<Person>()
                        .Where(p => p.Id == id)
                        .Select(p => p.LName)
                        .SingleOrDefault<string>();
                }
                catch (Exception ex)
                {
                    Logger.Logger.AddToLog("PersonRepository | AddPerson | {0}", ex);
                    tran.Rollback();
                    return null;
                }
            }
        }

        public IList<PersonDto> GetAllFirstAndLastNames()
        {
            using (var tran = _session.BeginTransaction())
            {
                try
                {
                    Person person = null;
                    //PersonDto pdto = null;

                    var test = _session.QueryOver(() => person).List();
                    var res2 = test.Select(x => new PersonDto
                    {
                        Id = x.Id,
                        Firstname = x.FName,
                        Lastname = x.LName,
                        Worker = x.PersonType
                    }).ToList();

                    //var res = _session.QueryOver(() => person)
                    //    .SelectList(list => list
                    //        .Select(()=>person.FName).WithAlias(()=> pdto.Firstname)
                    //        .Select(()=>person.LName).WithAlias(()=> pdto.Lastname)
                    //        .Select(()=>person.PersonType).WithAlias(()=>pdto.Worker)
                    //        )
                    //        .TransformUsing(Transformers.AliasToBean<PersonDto>())
                    //    .List<PersonDto>();
                   
                    return res2;
                }
                catch (Exception ex)
                {
                    Logger.Logger.AddToLog("PersonRepository | AddPerson | {0}", ex);
                    tran.Rollback();
                    return null;
                }
            }
        }

        public IList<EmployeeNamesDto> GetAllEmployeeFirstAndLastNames()
        {
            using (var tran = _session.BeginTransaction())
            {
                try
                {
                    Person person = null;
                    Contractor calias = null;
                    Employee ealias = null;
                    EmployeeNamesDto edtoalais = null;
                    var res = _session.QueryOver(() => person)
                        .JoinAlias(()=>person.Id, ()=> calias)
                        .JoinAlias(()=> calias.Id, ()=> ealias)
                        .SelectList(list => list
                            .Select(() => person.FName).WithAlias(() => edtoalais.Firstname)
                            .Select(() => person.LName).WithAlias(() => edtoalais.Lastname)
                            .Select(() => person.DateOfBirth).WithAlias(() => edtoalais.BirthDate)
                            )
                            .TransformUsing(Transformers.AliasToBean<EmployeeNamesDto>())
                        .List<EmployeeNamesDto>();

                    return res;
                }
                catch (Exception ex)
                {
                    Logger.Logger.AddToLog("PersonRepository | AddPerson | {0}", ex);
                    tran.Rollback();
                    return null;
                }
            }
        }

        public IList<PersonWithSkillsCount> GetPersonRowsHavingMoreThanOneSkill()
        {
            using (var tran = _session.BeginTransaction())
            {
                try
                {
                    PersonSkills skills = null;
                    Person person = null;
                    PersonWithSkillsCount row = null;

                    var res = _session.QueryOver(() => person)
                        .JoinAlias(() => person.SkillsList, () => skills)
                        .SelectList(list => list
                            .SelectGroup(() => person.Id).WithAlias(() => row.PersonId)
                            .SelectGroup(() => person.FName).WithAlias(() => row.Firstname)
                            .SelectGroup(() => person.LName).WithAlias(() => row.Lastname)
                            .SelectCount(() => skills.Person).WithAlias(() => row.SkillsCount))
                        .Where(Restrictions.Gt(Projections.Count(Projections.Property(() => skills.Person)), 1))
                        .TransformUsing(Transformers.AliasToBean<PersonWithSkillsCount>())
                        .List<PersonWithSkillsCount>();

                    tran.Commit();
                    return res;
                }
                catch (Exception ex)
                {
                    Logger.Logger.AddToLog("PersonRepository | AddPerson | {0}", ex);
                    tran.Rollback();
                    return null;
                }
            }
        }

        public IList<Person> GetAllPersonsWithSkills()
        {
            using (var tran = _session.BeginTransaction())
            {
                try
                {
                    Person person = null;
                    PersonSkills skills = null;

                    return _session.QueryOver(() => person)
                        .JoinAlias(() => person.SkillsList, () => skills)
                        .TransformUsing(Transformers.DistinctRootEntity)
                        .List<Person>();
                }
                catch (Exception ex)
                {
                    Logger.Logger.AddToLog("PersonRepository | AddPerson | {0}", ex);
                    tran.Rollback();
                    return null;
                }
            }
        }

        public IList<Person> GetPersonByLNameOrByFName(string lastname, string firstname)
        {
            using (var tran = _session.BeginTransaction())
            {
                try
                {
                    var persons = _session.QueryOver<Person>()
                        .Where(new Disjunction()
                            .Add(Restrictions.Where<Person>(x => x.LName == lastname))
                            .Add(Restrictions.Where<Person>(x => x.FName == firstname)))
                        .List();
                    tran.Commit();
                    return persons;
                }
                catch (Exception ex)
                {
                    Logger.Logger.AddToLog("PersonRepository | AddPerson | {0}", ex);
                    tran.Rollback();
                    return null;
                }
            }
        }

        public Person GetPersonId(long id)
        {
            using (var tran = _session.BeginTransaction())
            {
                try
                {
                    var result = _session.Load<Person>(id);
                    tran.Commit();
                    return result;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }
    }
}