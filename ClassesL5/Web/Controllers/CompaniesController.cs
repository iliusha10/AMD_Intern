using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repository.Interfaces;
using Infrastructure.IoC;

namespace Web.Controllers
{
    public class CompaniesController : Controller
    {
        //
        // GET: /Company/
        private static readonly ICompanyRepository CompanyRepository = ServiceLocator.Get<ICompanyRepository>();

        public ActionResult CompanyNames()
        {
            var companyNames = CompanyRepository.GetAllCompanyNames();
            return View(companyNames);
        }

        //
        // GET: /Company/Details/5

        public ActionResult Details(int id)
        {
            var result = CompanyRepository.GetCompanyAllInfo(id);

            return View(result.First());
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
        public ActionResult Create(FormCollection collection)
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
            return View();
        }

        //
        // POST: /Company/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
