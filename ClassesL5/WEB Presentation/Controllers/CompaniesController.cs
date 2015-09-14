using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Domain.CompanyAssets;
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
            try
            {
                var company = CompanyFactory.CreateCompany(model.CompanyName, model.Activity,
                    new Address(model.City, model.Street));
                CompanyRepository.AddCompany(company);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Company/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Company/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Company/Delete/5

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

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                CompanyRepository.DeleteCompany(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}