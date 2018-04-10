using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_BasicTutorial.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            TempData["name"] = "Test data";
            TempData["age"] = 30;

            throw new Exception("This is unhandled exception");

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            string userName;
            int userAge;

            if (TempData.ContainsKey("name"))
            {
                userName = TempData["name"].ToString();
                ViewBag.username = TempData["name"].ToString();
            }

            if (TempData.ContainsKey("age"))
            {
                userAge = int.Parse(TempData["age"].ToString());

                ViewBag.userage = int.Parse(TempData["age"].ToString());

            }
            TempData.Keep();
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}