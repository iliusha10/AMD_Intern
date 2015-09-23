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
            //var items = new List<SelectListItem>();
            //var companies = CompanyRepository.GetAllCompanyNames();
            //items.Add(new SelectListItem{Text = "Select copmany", Value = "0", Selected = true});
            //foreach (var comp in companies)
            //{
            //    items.Add(new SelectListItem{Text = comp.CompanyNames, Value = comp.Id.ToString()});
            //}
            //var pers = new AllPersonModel(items);
            var pers = new PersonTypeModel();

            return PartialView(pers);
        }

        //
        // POST: /MyView/Create

        [HttpPost]
        public ActionResult Create(AllPersonModel worker)
        {
            if (ModelState.IsValid)
            {
                var pers = PersonRepository.GetAllFirstAndLastNames();
                return PartialView("WorkerList", pers);
            }

            Response.StatusCode = 200;
            return PartialView(worker);
        }

        [HttpGet]
        public ActionResult CreateIntern()
        {
            var items = new List<SelectListItem>();
            var companies = CompanyRepository.GetAllCompanyNames();
            items.Add(new SelectListItem { Text = "Select copmany", Value = "0", Selected = true });
            foreach (var comp in companies)
            {
                items.Add(new SelectListItem { Text = comp.CompanyNames, Value = comp.Id.ToString() });
            }
            var pers = new InternModel(items);


            return PartialView(pers);
        }

        //
        // POST: /MyView/Create

        [HttpPost]
        public ActionResult CreateIntern(AllPersonModel worker)
        {
            if (ModelState.IsValid)
            {
                var company = CompanyRepository.GetItemById<Company>(worker.CompanyId);
                var address = new Address("street", "city");
                var skill = new Dictionary<string, int>();
                if (worker.PersonType == PersonType.Intern)
                {
                    var intern = InternFactory.CreateIntern(worker.Firstname, worker.Lastname, worker.BirthDate,
                        skill, address, company, worker.AverageMark);
                    PersonRepository.AddPerson(intern);
                }
                else if (worker.PersonType == PersonType.Contractor)
                {
                    var salary = new Salary(worker.Salary, 0.0);
                    var contractor = ContractorFactory.CreateContractor(worker.Firstname, worker.Lastname,
                        worker.BirthDate,
                        skill, address, company, worker.WorkExp, salary);
                    PersonRepository.AddPerson(contractor);
                }
                else if (worker.PersonType == PersonType.Employee)
                {
                    var salary = new Salary(worker.Salary, 0.0);
                    var employee = EmployeeFactory.CreateEmployee(worker.Firstname, worker.Lastname, worker.BirthDate,
                        skill, address, company, worker.WorkExp, salary, worker.Department, worker.Role);
                    PersonRepository.AddPerson(employee);
                }

                var pers = PersonRepository.GetAllFirstAndLastNames();
                return PartialView("WorkerList", pers);
            }




            Response.StatusCode = 200;
            return PartialView(worker);
        }



        [HttpGet]
        public ActionResult CreateContractor()
        {
            var items = new List<SelectListItem>();
            var companies = CompanyRepository.GetAllCompanyNames();
            items.Add(new SelectListItem { Text = "Select copmany", Value = "0", Selected = true });
            foreach (var comp in companies)
            {
                items.Add(new SelectListItem { Text = comp.CompanyNames, Value = comp.Id.ToString() });
            }
            var pers = new InternModel(items);


            return PartialView(pers);
        }

        //
        // POST: /MyView/Create

        [HttpPost]
        public ActionResult CreateContractor(AllPersonModel worker)
        {
            if (ModelState.IsValid)
            {
                var company = CompanyRepository.GetItemById<Company>(worker.CompanyId);
                var address = new Address("street", "city");
                var skill = new Dictionary<string, int>();
                if (worker.PersonType == PersonType.Intern)
                {
                    var intern = InternFactory.CreateIntern(worker.Firstname, worker.Lastname, worker.BirthDate,
                        skill, address, company, worker.AverageMark);
                    PersonRepository.AddPerson(intern);
                }
                else if (worker.PersonType == PersonType.Contractor)
                {
                    var salary = new Salary(worker.Salary, 0.0);
                    var contractor = ContractorFactory.CreateContractor(worker.Firstname, worker.Lastname,
                        worker.BirthDate,
                        skill, address, company, worker.WorkExp, salary);
                    PersonRepository.AddPerson(contractor);
                }
                else if (worker.PersonType == PersonType.Employee)
                {
                    var salary = new Salary(worker.Salary, 0.0);
                    var employee = EmployeeFactory.CreateEmployee(worker.Firstname, worker.Lastname, worker.BirthDate,
                        skill, address, company, worker.WorkExp, salary, worker.Department, worker.Role);
                    PersonRepository.AddPerson(employee);
                }

                var pers = PersonRepository.GetAllFirstAndLastNames();
                return PartialView("WorkerList", pers);
            }




            Response.StatusCode = 200;
            return PartialView(worker);
        }


        [HttpGet]
        public ActionResult CreateEmployee()
        {
            var items = new List<SelectListItem>();
            var companies = CompanyRepository.GetAllCompanyNames();
            items.Add(new SelectListItem { Text = "Select copmany", Value = "0", Selected = true });
            foreach (var comp in companies)
            {
                items.Add(new SelectListItem { Text = comp.CompanyNames, Value = comp.Id.ToString() });
            }
            var pers = new InternModel(items);


            return PartialView(pers);
        }

        //
        // POST: /MyView/Create

        [HttpPost]
        public ActionResult CreateEmployee(AllPersonModel worker)
        {
            if (ModelState.IsValid)
            {
                var company = CompanyRepository.GetItemById<Company>(worker.CompanyId);
                var address = new Address("street", "city");
                var skill = new Dictionary<string, int>();
                if (worker.PersonType == PersonType.Intern)
                {
                    var intern = InternFactory.CreateIntern(worker.Firstname, worker.Lastname, worker.BirthDate,
                        skill, address, company, worker.AverageMark);
                    PersonRepository.AddPerson(intern);
                }
                else if (worker.PersonType == PersonType.Contractor)
                {
                    var salary = new Salary(worker.Salary, 0.0);
                    var contractor = ContractorFactory.CreateContractor(worker.Firstname, worker.Lastname,
                        worker.BirthDate,
                        skill, address, company, worker.WorkExp, salary);
                    PersonRepository.AddPerson(contractor);
                }
                else if (worker.PersonType == PersonType.Employee)
                {
                    var salary = new Salary(worker.Salary, 0.0);
                    var employee = EmployeeFactory.CreateEmployee(worker.Firstname, worker.Lastname, worker.BirthDate,
                        skill, address, company, worker.WorkExp, salary, worker.Department, worker.Role);
                    PersonRepository.AddPerson(employee);
                }

                var pers = PersonRepository.GetAllFirstAndLastNames();
                return PartialView("WorkerList", pers);
            }




            Response.StatusCode = 200;
            return PartialView(worker);
        }




        //
        // GET: /MyView/Edit/5
        [HttpGet]
        public ActionResult Edit(long id)
        {

            var person = PersonRepository.GetItemById<Person>(id);
            var items = new List<SelectListItem>();
            var companies = CompanyRepository.GetAllCompanyNames();
            items.Add(new SelectListItem { Text = "No company", Value = "0"});
            foreach (var comp in companies)
            {
                if (comp.CompanyNames==person.Company.CompanyName)
                    items.Add(new SelectListItem { Text = comp.CompanyNames, Value = comp.Id.ToString(), Selected = true});
                else
                    items.Add(new SelectListItem { Text = comp.CompanyNames, Value = comp.Id.ToString() });
            }

            if (person.PersonType == PersonType.Intern)
            {
                var intern = new InternModel((Intern) person);
                intern.Companies = items;
                return View(intern);
            }
            if (person.PersonType == PersonType.Contractor)
            {
                var contractor = new ContractorModel((Contractor) person);
                contractor.Companies = items;
                return View(contractor);
            }
            var emp = new EmployeeModel((Employee) person);
            emp.Companies = items;
            return View(emp);
        }

        //
        // POST: /MyView/Edit/5

        //[HttpPost]
        //public ActionResult Edit(long id, FormCollection editedworker)
        //{
        //    // if (editedworker["PersonType"] == PersonType.Intern)
        //    //Request.Form["Firstname"];
            
        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public ActionResult EditIntern(long id, InternModel editIntern)
        {
            //if (editedworker["PersonType"] == PersonType.Intern)
            //    Request.Form["Firstname"];

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

        //public ActionResult Skill()
        //{
        //    return PartialView();
        //}

        //public ActionResult AddSkill(string name, int level)
        //{
        //}
    }
}