﻿using System.Web.Mvc;

namespace Web.Controllers
{
    public class MyViewController : Controller
    {
        //
        // GET: /MyView/

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }
    }
}