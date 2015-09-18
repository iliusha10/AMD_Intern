using System.Web.Mvc;
using Domain;
using Domain.Persons;
using Infrastructure.IoC;
using Repository.Interfaces;
using WEB_Presentation.Models;

namespace Web.Controllers
{
    public class WorkersController : Controller
    {
        private readonly IPersonRepository PersonRepository = ServiceLocator.Get<IPersonRepository>();

        [HttpGet]
        public ActionResult Index()

        {
            var pers = PersonRepository.GetAllFirstAndLastNames();
            return View(pers);
        }


        //
        // GET: /MyView/Details/5
        [HttpGet]
        public ActionResult Details(long id)
        {
            var person = PersonRepository.GetItemById<Person>(id);

            if (person.PersonType == PersonType.Intern)
            {
                var intern = new InternModel((Intern) person);
                return View(intern);
            }
            if (person.PersonType == PersonType.Contractor)
            {
                var contractor = new ContractorModel((Contractor) person);
                return View(contractor);
            }
            var emp = new EmployeeModel((Employee) person);
            return View(emp);
        }

//
// GET: /MyView/Create
        [HttpGet] 
        public ActionResult Create()
        {
            var pers = new AllPersonModel();
            ViewBag.JS = "HideRows();";
            return View(pers);
        }

        //
        // POST: /MyView/Create

        [HttpPost]
        public ActionResult Create (FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /MyView/Edit/5
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var person = PersonRepository.GetItemById<Person>(id);

            if (person.PersonType == PersonType.Intern)
            {
                var intern = new InternModel((Intern) person);
                return View(intern);
            }
            if (person.PersonType == PersonType.Contractor)
            {
                var contractor = new ContractorModel((Contractor) person);
                return View(contractor);
            }
            var emp = new EmployeeModel((Employee) person);
            return View(emp);
        }

        //
        // POST: /MyView/Edit/5

        [HttpPost]
        public ActionResult Edit (long id, PersonModel newperson)
        {
            

                return RedirectToAction("Index");

        }

        //
        // GET: /MyView/Delete/5

        [HttpGet]
        public ActionResult Delete(long id)
        {
            var person = PersonRepository.GetItemById<Person>(id);

            if (person.PersonType == PersonType.Intern)
            {
                var intern = new InternModel(person as Intern);
                return View(intern);
            }
            if (person.PersonType == PersonType.Contractor)
            {
                var contractor = new ContractorModel(person as Contractor);
                return View(contractor);
            }
            var emp = new EmployeeModel(person as Employee);
            return View(emp);
        }

        //
        // POST: /MyView/Delete/5

        [HttpPost]
        public ActionResult Delete(long id, FormCollection collection)
        {
            PersonRepository.DeletePerson(id);
            return RedirectToAction("Index");
        }
    }
}