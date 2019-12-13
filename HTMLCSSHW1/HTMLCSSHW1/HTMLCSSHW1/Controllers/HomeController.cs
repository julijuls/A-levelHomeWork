using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HTMLCSSHW1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Your Main page.";
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your Contact page.";

            return View();
        }
        public ActionResult Price()
        {
            ViewBag.Message = "Your Price page.";

            return View();
        }
        public ActionResult Reviews()
        {
            ViewBag.Message = "Your Reviews page.";

            return View();
        }
        public ActionResult Music()
        {
            ViewBag.Message = "Your Media page.";

            return View();
        }
        public ActionResult Flex()
        {
            return View();
        }
        public ActionResult HW2()
        {
            return View();
        }
    }
}