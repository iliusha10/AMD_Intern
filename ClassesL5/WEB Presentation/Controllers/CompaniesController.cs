using System.Web.Mvc;
using Domain.CompanyAssets;
using Domain.Row;
using Factories;
using Infrastructure.IoC;
using Repository.Interfaces;
using WEB_Presentation.Models;

namespace WEB_Presentation.Controllers
{
    public class CompaniesController : Controller
    {
        //
        // GET: /Company/
        private readonly ICompanyRepository CompanyRepository = ServiceLocator.Get<ICompanyRepository>();
        private readonly CompanyFactory CompanyFactory = ServiceLocator.Get<CompanyFactory>();
        private readonly IAddressRepository AddressRepository = ServiceLocator.Get<IAddressRepository>();

        [HttpGet]
        public ActionResult Index()
        {
            var companyNamesActivity = CompanyRepository.GetAllCompanyNamesAndActivity();
            return View(companyNamesActivity);
        }

        //
        // GET: /Company/Details/5

        [HttpGet]
        public ActionResult Details(long id)
        {
            var result = CompanyRepository.GetCompanyAllInfo(id);
            return PartialView(result);
        }

        //
        // GET: /Company/Create

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        //
        // POST: /Company/Create

        [HttpPost]
        public ActionResult Create(CompanyModel model)
        {
            if (ModelState.IsValid)
            {
                var company = CompanyFactory.CreateCompany(model.CompanyName, model.Activity,
                    new Address(model.City, model.Street));
                CompanyRepository.AddCompany(company);
                
                var companyNamesActivity = CompanyRepository.GetAllCompanyNamesAndActivity();
                return PartialView("CompanyList", companyNamesActivity);
            }
            return PartialView(model);
        }

        //
        // GET: /Company/Edit/5
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var company = CompanyRepository.GetCompanyAllInfo(id);
            var comp = new CompanyModel(company);
            return PartialView(comp);
        }

        //
        // POST: /Company/Edit/5

        [HttpPost]
        public ActionResult Edit(long id, CompanyModel company)
        {
            if (ModelState.IsValid)
            {
                CompanyAllInfo newCompany = company.TransformToDto(id);
                Company currentCompany = CompanyRepository.GetItemById<Company>(id);
                Address currentAddress = AddressRepository.GetItemById<Address>(currentCompany.Address.Id);
                AddressRepository.UpdateAddress(currentAddress, newCompany.City, newCompany.Street);
                CompanyRepository.UpdateCompany(currentCompany, newCompany);

                var companyNamesActivity = CompanyRepository.GetAllCompanyNamesAndActivity();
                return PartialView("CompanyList", companyNamesActivity);
            }
            return PartialView(company);
        }

        //
        // GET: /Company/Delete/5
        [HttpGet]
        public ActionResult Delete(long id)
        {
            var company = CompanyRepository.GetCompanyAllInfo(id);
            var compMod = new CompanyModel(company);
            return PartialView(compMod);
        }

        //
        // POST: /Company/Delete/5

        [HttpPost]
        public ActionResult Delete(long id, FormCollection collection)
        {
            CompanyRepository.DeleteCompany(id);
            var companyNamesActivity = CompanyRepository.GetAllCompanyNamesAndActivity();
            return PartialView("CompanyList", companyNamesActivity);
        }
    }
}