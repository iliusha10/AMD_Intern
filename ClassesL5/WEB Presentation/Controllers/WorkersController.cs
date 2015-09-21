using System.Collections.Generic;
using System.Web.Mvc;
using Domain;
using Domain.CompanyAssets;
using Domain.Persons;
using Factories;
using Infrastructure.IoC;
using Repository.Interfaces;
using WEB_Presentation.Models;

namespace Web.Controllers
{
    public class WorkersController : Controller
    {
        private readonly IPersonRepository PersonRepository = ServiceLocator.Get<IPersonRepository>();
        private readonly InternFactory InternFactory = ServiceLocator.Get<InternFactory>();
        private readonly ContractorFactory ContractorFactory = ServiceLocator.Get<ContractorFactory>();
        private readonly EmployeeFactory EmployeeFactory = ServiceLocator.Get<EmployeeFactory>();
        private readonly ICompanyRepository CompanyRepository = ServiceLocator.Get<ICompanyRepository>();
        
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
            var items = new List<SelectListItem>();
            var companies = CompanyRepository.GetAllCompanyNames();
            items.Add(new SelectListItem{Text = "no company", Value = "0", Selected = true});
            foreach (var comp in companies)
            {
                items.Add(new SelectListItem{Text = comp.CompanyNames, Value = comp.Id.ToString()});
            }
            var pers = new AllPersonModel(items);

            return View(pers);
        }

        //
        // POST: /MyView/Create

        [HttpPost]
        public ActionResult Create(AllPersonModel worker)
        {
            if (worker.PersonType == PersonType.Intern)
            {
                //var intn = InternFactory.CreateIntern(worker.Firstname, worker.Lastname,worker.BirthDate, new Dictionary<string, int>(),new Address("street", "city"),,worker.AverageMark  )    
                //var intern = worker.MakeIntern();
            }
            else if (worker.PersonType == PersonType.Contractor)
            {
                //var contarctor = worker.MakeContractor();
            }
            else if (worker.PersonType == PersonType.Employee)
            {
                //var employee = worker.MakeEmployee();
            }
            return RedirectToAction("Index");
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
        public ActionResult Edit(long id, PersonModel newperson)
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

        public ActionResult Skill()
        {
            return View();
        }

        //public ActionResult AddSkill(string name, int level)
        //{
        //}
    }
}