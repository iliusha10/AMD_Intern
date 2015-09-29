using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Domain.CompanyAssets;
using Domain.Persons;
using Domain.Row;
using Factories;
using Infrastructure.IoC;
using Repository.Interfaces;
using WEB_Presentation.Models;


namespace WEB_Presentation.Controllers
{
    public class WorkersController : Controller
    {
        private readonly IAddressRepository AddressRepository = ServiceLocator.Get<IAddressRepository>();
        private readonly ICompanyRepository CompanyRepository = ServiceLocator.Get<ICompanyRepository>();
        private readonly ContractorFactory ContractorFactory = ServiceLocator.Get<ContractorFactory>();
        private readonly EmployeeFactory EmployeeFactory = ServiceLocator.Get<EmployeeFactory>();
        private readonly InternFactory InternFactory = ServiceLocator.Get<InternFactory>();
        private readonly IPersonRepository PersonRepository = ServiceLocator.Get<IPersonRepository>();

        [HttpGet]
        public ViewResult Index()
        {
            var pers = PersonRepository.GetAllFirstAndLastNames();
            return View(pers);
        }


        [HttpGet]
        public PartialViewResult DetailsIntern(long id)
        {
            var person = PersonRepository.GetItemById<Intern>(id);
            var intern = new InternModel(person);
            return PartialView(intern);
        }

        [HttpGet]
        public PartialViewResult DetailsContractor(long id)
        {
            var person = PersonRepository.GetItemById<Contractor>(id);
            var contractor = new ContractorModel(person);
            return PartialView(contractor);
        }

        [HttpGet]
        public PartialViewResult DetailsEmployee(long id)
        {
            var person = PersonRepository.GetItemById<Employee>(id);
            var emp = new EmployeeModel(person);
            return PartialView(emp);
        }


        [HttpGet]
        public PartialViewResult CreateIntern()
        {
            var items = new List<SelectListItem>();
            var companies = CompanyRepository.GetAllCompanyNames();
            items.Add(new SelectListItem {Text = "Select copmany", Value = "0", Selected = true});
            foreach (var comp in companies)
            {
                items.Add(new SelectListItem {Text = comp.CompanyNames, Value = comp.Id.ToString()});
            }
            var pers = new InternModel(items);
            return PartialView(pers);
        }

        //
        // POST: /MyView/Create

        [HttpPost]
        public ActionResult CreateIntern(InternModel newintern)
        {
            if (ModelState.IsValid)
            {
                var company = CompanyRepository.GetItemById<Company>(newintern.CompanyId);
                var address = new Address(newintern.Street, newintern.City);
                var skill = new Dictionary<string, int>();
                var intern = InternFactory.CreateIntern(newintern.Firstname, newintern.Lastname, newintern.BirthDate,
                    skill, address, company, newintern.AverageMark);
                PersonRepository.AddPerson(intern);

                var pers = PersonRepository.GetAllFirstAndLastNames();
                return PartialView("WorkerList", pers);
            }
            return PartialView(newintern);
        }


        [HttpGet]
        public PartialViewResult CreateContractor()
        {
            var items = new List<SelectListItem>();
            var companies = CompanyRepository.GetAllCompanyNames();
            items.Add(new SelectListItem {Text = "Select copmany", Value = "0", Selected = true});
            foreach (var comp in companies)
            {
                items.Add(new SelectListItem {Text = comp.CompanyNames, Value = comp.Id.ToString()});
            }
            var pers = new ContractorModel(items);
            return PartialView(pers);
        }

        //
        // POST: /MyView/Create

        [HttpPost]
        public ActionResult CreateContractor(ContractorModel newcontractor)
        {
            if (ModelState.IsValid)
            {
                var company = CompanyRepository.GetItemById<Company>(newcontractor.CompanyId);
                var address = new Address(newcontractor.Street, newcontractor.City);
                var skill = new Dictionary<string, int>();
                var salary = new Salary(newcontractor.Salary, 0.0);
                var contractor = ContractorFactory.CreateContractor(newcontractor.Firstname, newcontractor.Lastname,
                    newcontractor.BirthDate,
                    skill, address, company, newcontractor.WorkExp, salary);
                PersonRepository.AddPerson(contractor);

                var pers = PersonRepository.GetAllFirstAndLastNames();
                return PartialView("WorkerList", pers);
            }
            return PartialView(newcontractor);
        }


        [HttpGet]
        public PartialViewResult CreateEmployee()
        {
            var items = new List<SelectListItem>();
            var companies = CompanyRepository.GetAllCompanyNames();
            items.Add(new SelectListItem {Text = "Select copmany", Value = "0", Selected = true});
            foreach (var comp in companies)
            {
                items.Add(new SelectListItem {Text = comp.CompanyNames, Value = comp.Id.ToString()});
            }
            var pers = new EmployeeModel(items);
            return PartialView(pers);
        }

        //
        // POST: /MyView/Create

        [HttpPost]
        public ActionResult CreateEmployee(EmployeeModel newcontractor)
        {
            if (ModelState.IsValid)
            {
                var company = CompanyRepository.GetItemById<Company>(newcontractor.CompanyId);
                var address = new Address(newcontractor.Street, newcontractor.City);
                var skill = new Dictionary<string, int>();
                var salary = new Salary(newcontractor.Salary, 0.0);
                var employee = EmployeeFactory.CreateEmployee(newcontractor.Firstname, newcontractor.Lastname,
                    newcontractor.BirthDate,
                    skill, address, company, newcontractor.WorkExp, salary, newcontractor.Department, newcontractor.Role);
                PersonRepository.AddPerson(employee);

                var pers = PersonRepository.GetAllFirstAndLastNames();
                return PartialView("WorkerList", pers);
            }
            return PartialView(newcontractor);
        }


        [HttpGet]
        public PartialViewResult EditIntern(long id)
        {
            var person = PersonRepository.GetItemById<Intern>(id);
            var items = new List<SelectListItem>();
            var companies = CompanyRepository.GetAllCompanyNames();
            //items.Add(new SelectListItem { Text = "No company", Value = "0" });
            foreach (var comp in companies)
            {
                if (comp.CompanyNames == person.Company.CompanyName)
                    items.Add(new SelectListItem {Text = comp.CompanyNames, Value = comp.Id.ToString(), Selected = true});
                else
                    items.Add(new SelectListItem {Text = comp.CompanyNames, Value = comp.Id.ToString()});
            }

            var intern = new InternModel(person);
            intern.Companies = items;
            return PartialView(intern);
        }


        [HttpPost]
        public ActionResult EditIntern(long id, InternModel editedIntern)
        {
            if (ModelState.IsValid)
            {
                var newIntern = new InternDetailsDto();
                editedIntern.ConvertToDto(newIntern);
                var currentIntern = PersonRepository.GetItemById<Intern>(id);
                var currentAddress = AddressRepository.GetItemById<Address>(currentIntern.Address.Id);
                AddressRepository.UpdateAddress(currentAddress, editedIntern.City, editedIntern.Street);
                var newCompany = CompanyRepository.GetItemById<Company>(newIntern.CompanyId);
                PersonRepository.UpdateIntern(currentIntern, newIntern, newCompany);

                var pers = PersonRepository.GetAllFirstAndLastNames();
                return PartialView("WorkerList", pers);
            }
            return PartialView(editedIntern);
        }


        [HttpGet]
        public PartialViewResult EditContractor(long id)
        {
            var person = PersonRepository.GetItemById<Contractor>(id);
            var items = new List<SelectListItem>();
            var companies = CompanyRepository.GetAllCompanyNames();
            //items.Add(new SelectListItem { Text = "No company", Value = "0" });
            foreach (var comp in companies)
            {
                if (comp.CompanyNames == person.Company.CompanyName)
                    items.Add(new SelectListItem {Text = comp.CompanyNames, Value = comp.Id.ToString(), Selected = true});
                else
                    items.Add(new SelectListItem {Text = comp.CompanyNames, Value = comp.Id.ToString()});
            }

            var contractor = new ContractorModel(person);
            contractor.Companies = items;

            return PartialView(contractor);
        }


        [HttpPost]
        public ActionResult EditContractor(long id, ContractorModel editedContractor)
        {
            if (ModelState.IsValid)
            {
                var newContractor = new ContractorDetailsDto();
                editedContractor.ConvertToDto(newContractor);
                var currentContractor = PersonRepository.GetItemById<Contractor>(id);
                var currentAddress = AddressRepository.GetItemById<Address>(currentContractor.Address.Id);
                AddressRepository.UpdateAddress(currentAddress, editedContractor.City, editedContractor.Street);
                var newCompany = CompanyRepository.GetItemById<Company>(newContractor.CompanyId);
                var currentsalary = PersonRepository.GetItemById<Salary>(currentContractor.Salary.Id);
                PersonRepository.UpdateContractor(currentContractor, newContractor, newCompany, currentsalary);

                var pers = PersonRepository.GetAllFirstAndLastNames();
                return PartialView("WorkerList", pers);
            }
            return PartialView(editedContractor);
        }


        [HttpGet]
        public PartialViewResult EditEmployee(long id)
        {
            var person = PersonRepository.GetItemById<Employee>(id);
            var items = new List<SelectListItem>();
            var companies = CompanyRepository.GetAllCompanyNames();
            //items.Add(new SelectListItem { Text = "No company", Value = "0" });
            foreach (var comp in companies)
            {
                if (comp.CompanyNames == person.Company.CompanyName)
                    items.Add(new SelectListItem {Text = comp.CompanyNames, Value = comp.Id.ToString(), Selected = true});
                else
                    items.Add(new SelectListItem {Text = comp.CompanyNames, Value = comp.Id.ToString()});
            }
            var emp = new EmployeeModel(person);
            emp.Companies = items;
            return PartialView(emp);
        }


        [HttpPost]
        public ActionResult EditEmployee(long id, EmployeeModel editedEmployee)
        {
            if (ModelState.IsValid)
            {
                var newEmployee = new EmployeeDetailsDto();
                editedEmployee.ConvertToDto(newEmployee);
                var currentEmployee = PersonRepository.GetItemById<Employee>(id);
                var currentAddress = AddressRepository.GetItemById<Address>(currentEmployee.Address.Id);
                AddressRepository.UpdateAddress(currentAddress, editedEmployee.City, editedEmployee.Street);
                var newCompany = CompanyRepository.GetItemById<Company>(newEmployee.CompanyId);
                var currentsalary = PersonRepository.GetItemById<Salary>(currentEmployee.Salary.Id);
                PersonRepository.UpdateEmployee(currentEmployee, newEmployee, newCompany, currentsalary);

                var pers = PersonRepository.GetAllFirstAndLastNames();
                return PartialView("WorkerList", pers);
            }

            return PartialView(editedEmployee);
        }

        //
        // GET: /MyView/Delete/5

        [HttpGet]
        public PartialViewResult DeleteIntern(long id)
        {
            var person = PersonRepository.GetItemById<Intern>(id);
            var intern = new InternModel(person);
            return PartialView(intern);
        }


        //
        // POST: /MyView/Delete/5

        [HttpPost, ActionName("DeleteIntern")]
        public PartialViewResult DeleteInternPost(long id, FormCollection collection)
        {
            PersonRepository.DeletePerson(id);
            var pers = PersonRepository.GetAllFirstAndLastNames();
            return PartialView("WorkerList", pers);
        }


        [HttpGet]
        public PartialViewResult DeleteContractor(long id)
        {
            var person = PersonRepository.GetItemById<Contractor>(id);
            var contractor = new ContractorModel(person);
            return PartialView(contractor);
        }

        //
        // POST: /MyView/Delete/5

        [HttpPost, ActionName("DeleteContractor")]
        public PartialViewResult DeleteContractorPost(long id)
        {
            PersonRepository.DeletePerson(id);
            var pers = PersonRepository.GetAllFirstAndLastNames();
            return PartialView("WorkerList", pers);
        }

        [HttpGet]
        public PartialViewResult DeleteEmployee(long id)
        {
            var person = PersonRepository.GetItemById<Employee>(id);
            var emp = new EmployeeModel(person);
            return PartialView(emp);
        }

        //
        // POST: /MyView/Delete/5

        [HttpPost, ActionName("DeleteEmployee")]
        public PartialViewResult DeleteEmployeePost(long id)
        {
            PersonRepository.DeletePerson(id);
            var pers = PersonRepository.GetAllFirstAndLastNames();
            return PartialView("WorkerList", pers);
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