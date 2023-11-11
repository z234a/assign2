using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace assign2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "My Website";
            ViewBag.Message = "Welcome to my website!";

            return View("~/Views/Home/Index.cshtml");
        }

        public ActionResult Historical()
        {
            ViewBag.Title = "My Website";
            ViewBag.Message = "Welcome to my website!";

            return View("~/Views/Home/Historical.cshtml");
        }
        public ActionResult Core()
        {
            ViewBag.Title = "My Website";
            ViewBag.Message = "Welcome to my website!";

            return View("~/Views/Home/Core.cshtml");
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