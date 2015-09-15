using System.Collections.Generic;
using System.Linq;
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
            var companyNames = CompanyRepository.GetAllCompanyNames();
            return View(companyNames);
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
                var company = CompanyFactory.CreateCompany(model.CompanyName, model.Activity,
                    new Address(model.City, model.Street));
                CompanyRepository.AddCompany(company);
                return RedirectToAction("Index");
        }

        //
        // GET: /Company/Edit/5
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var company = CompanyRepository.GetCompanyAllInfo(id);
            CompanyModel comp = new CompanyModel
            {
                CompanyName = company.CompanyName,
                Activity = company.Activity,
                City = company.City,
                Street = company.Street,
             //   AddressId= company.
            };
            return View(comp);
        }

        //
        // POST: /Company/Edit/5

        [HttpPost]
        public ActionResult Edit(long id, CompanyModel company)
        {
                //var newaddress = new Address(company.Street, company.City);
                
                //var oldcompany = CompanyRepository.GetCompanyById(id);
                //var newcompany = CompanyFactory.CreateCompany(company.CompanyName, company.Activity, newaddress );

                //var oldaddress = AddressRepository.GetAddressById(oldcompany.Address.Id)
                //AddressRepository.UpdateAddress(oldaddress, newaddress);
                //CompanyRepository.UpdateCompany(oldcompany, newcompany);

                return RedirectToAction("Index");
        }

        //
        // GET: /Company/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var company = CompanyRepository.GetCompanyAllInfo(id);
            CompanyModel comp = new CompanyModel();
            comp.CompanyName = company.CompanyName;
            comp.Activity = company.Activity;
            comp.City = company.City;
            comp.Street = company.Street;
            return View(comp);
        }

        //
        // POST: /Company/Delete/5

        [HttpGet]
        public ActionResult ApplyDelete(int id)
        {

            CompanyRepository.DeleteCompany(id);
            //var comp = CompanyRepository.GetCompanyById(id);
            //    CompanyRepository.Delete(comp);


            return RedirectToAction("Index");

        }
    }
}