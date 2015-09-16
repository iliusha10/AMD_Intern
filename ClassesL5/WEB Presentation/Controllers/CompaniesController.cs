using System.Web.Mvc;
using Domain.CompanyAssets;
using Domain.Row;
using Factories;
using Infrastructure.IoC;
using Repository.Interfaces;
using WEB_Presentation.Models;

namespace Web.Controllers
{
    public class CompaniesController : Controller
    {
        //
        // GET: /Company/
        private static readonly ICompanyRepository CompanyRepository = ServiceLocator.Get<ICompanyRepository>();
        private static readonly CompanyFactory CompanyFactory = ServiceLocator.Get<CompanyFactory>();
        private static readonly IAddressRepository AddressRepository = ServiceLocator.Get<IAddressRepository>();


        public ActionResult Index()
        {
            var companyNamesActivity = CompanyRepository.GetAllCompanyNamesAndActivity();
            return View(companyNamesActivity);
        }

        //
        // GET: /Company/Details/5

        public ActionResult Details(int id)
        {
            var result = CompanyRepository.GetCompanyAllInfo(id);

            return View(result);
        }

        //
        // GET: /Company/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Company/Create

        [HttpPost]
        public ActionResult Create(CompanyModel model)
        {
            //Address address= AddressRepository.CheckAdress(model.Street, model.City)
            var company = CompanyFactory.CreateCompany(model.CompanyName, model.Activity,
                new Address(model.City, model.Street));
            CompanyRepository.AddCompany(company);
            return RedirectToAction("Index");
        }

        //
        // GET: /Company/Edit/5

        public ActionResult Edit(long id)
        {
            var company = CompanyRepository.GetCompanyAllInfo(id);
            var comp = new CompanyModel(company);
            return View(comp);
        }

        //
        // POST: /Company/Edit/5

        [HttpPost]
        public ActionResult Edit(long id, CompanyModel company)
        {
            CompanyAllInfo newCompany = company.TransformToDto(id);
            Company currentCompany = CompanyRepository.GetItemById<Company>(id);
            Address currentAddress = AddressRepository.GetItemById<Address>(currentCompany.Address.Id);
            AddressRepository.UpdateAddress(currentAddress, newCompany.City, newCompany.Street);
            CompanyRepository.UpdateCompany(currentCompany, newCompany);

            return RedirectToAction("Index");
        }

        //
        // GET: /Company/Delete/5
        //[HttpGet]
        public ActionResult Delete(long id)
        {
            var company = CompanyRepository.GetCompanyAllInfo(id);
            var comp = new CompanyModel(company);
            return View(comp);
        }

        //
        // POST: /Company/Delete/5

        [HttpPost]
        public ActionResult Delete(long id, FormCollection collection)
        {
            CompanyRepository.DeleteCompany(id);
            return RedirectToAction("Index");
        }
    }
}