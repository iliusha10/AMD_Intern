using System.Web.Mvc;
using Domain.Persons;
using Infrastructure.IoC;
using Repository.Interfaces;

namespace Web.Controllers
{
    public class WorkersController : Controller
    {
        private static readonly IPersonRepository PersonRepository = ServiceLocator.Get<IPersonRepository>();


        public ActionResult Index()

        {
            var pers = PersonRepository.GetAllFirstAndLastNames();
            return View(pers);
        }


        //
        // GET: /MyView/Details/5

        public
            ActionResult Details (long id)
        {

            var result = PersonRepository.GetItemById<Person>(id);

            return View(result);
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