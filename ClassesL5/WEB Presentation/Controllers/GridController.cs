using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Infrastructure.IoC;
using Repository.Interfaces;
using WEB_Presentation.Models;

namespace WEB_Presentation.Controllers
{
    public class JqSettings
    {
        public int q { get; set; }
        public bool _search { get; set; }
        public int rows { get; set; }
        public int page { get; set; }
    }


    public class GridController : Controller
    {

        private readonly ICompanyRepository CompanyRepository = ServiceLocator.Get<ICompanyRepository>();


        [HttpGet]
        public JsonResult IndexData(JqSettings settings)
        {
            var company = CompanyRepository.GetAllCompaniesAllInfo();
            var model = new CompanyModel();
            var result = model.ConvertToCompanyModel(company);


            int skip = settings.rows * (settings.page - 1);

            int compCount = result.Count;
            IEnumerable<CompanyModel> companies = result.Skip(skip).Take(settings.rows);

            var data = from a in companies
                       select new
                       {
                           cell = new object[]
                           {
                               a.Id,
                               a.CompanyName,
                               a.Activity.ToString(),
                               a.City,
                               a.Street,
                           }
                       };

            var jsonData = new
            {
                total = (int)Math.Ceiling((double)compCount / settings.rows), //totalPages

                page = settings.page, //page number
                records = compCount, //total record found
                rows = data
            };


            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public ViewResult Index()
        {
            return View();
        }
    }
}