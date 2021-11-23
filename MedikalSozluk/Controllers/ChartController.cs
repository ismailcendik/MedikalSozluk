using MedikalSozluk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedikalSozluk.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }

        public List<CategoryClass> BlogList()
        {
            List<CategoryClass> ct = new List<CategoryClass>();
            ct.Add(new CategoryClass()
            {
                CategoryName="Gündem",
                CategoryCount=8

            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Tartışma",
                CategoryCount = 4

            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Mevzuat",
                CategoryCount = 3

            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Sgk",
                CategoryCount = 1

            });
            return ct;

        }
    }
}