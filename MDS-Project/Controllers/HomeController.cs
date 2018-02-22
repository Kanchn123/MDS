using MDS_Project.Models.com.main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MDS_Project.Controllers
{
    public class HomeController : Controller
    {
        private static CheckDatalog cdl = new CheckDatalog();

        public ActionResult Index()
        {
            cdl.CheckData();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}