using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repository.Interfaces;
using Repository;
using Infrastructure.IoC;


namespace Web.Controllers
{
    public class MyViewController : Controller
    {

        private static IPersonRepository PersonRepository = ServiceLocator.Get<IPersonRepository>();
        

        public ActionResult MyView()

        {
            

            return View();
        }


        public ActionResult ViewEmployee()
        {
            var emp = PersonRepository.GetAll();
            return View(emp);
        }


        //
        // GET: /MyView/Details/5

        public
            ActionResult Details
            (int id)
        {
            return View();
        }

//
// GET: /MyView/Create

        public
            ActionResult Create
            ()
        {
            return
                View();
        }

        //
        // POST: /MyView/Create

        [
            HttpPost]
        public
        ActionResult Create
            (FormCollection
                collection)
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

        public
            ActionResult Edit
            (int
                id)
        {
            return View();
        }

        //
        // POST: /MyView/Edit/5

        [
            HttpPost]
        public
        ActionResult Edit
            (int id, FormCollection collection)
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
        // GET: /MyView/Delete/5

        public
            ActionResult Delete
            (int
                id)
        {
            return View();
        }

        //
        // POST: /MyView/Delete/5

        [
            HttpPost]
        public
        ActionResult Delete
            (int id, FormCollection collection)
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