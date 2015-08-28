using System;
using System.Collections.Generic;
using Domain.Domain;
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
                    Console.WriteLine("Deleted person");
                }
                catch (Exception ex)
                {
                    Logger.Logger.AddToLog("PersonRepository | DeletePerson | {0}", ex);
                    transaction.Rollback();
                }
            }
        }
    }
}