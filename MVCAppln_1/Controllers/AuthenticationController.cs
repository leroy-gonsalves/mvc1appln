using MVCAppln_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCAppln_1.Controllers
{
    public class AuthenticationController : Controller
    {
        //
        // GET: /Authentication/
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoLogin(UserDetails u)
        {
            if (ModelState.IsValid)
            {
                EmployeeBussinessLayer ebl = new EmployeeBussinessLayer();
                UserStatus us = ebl.GetUserValidity(u);
                bool IsAdmin = false;
                if (us == UserStatus.AuthenticatedAdmin)
                {
                    IsAdmin = true;                    
                }
                else if (us == UserStatus.AuthenticatedUser)
                {
                    IsAdmin = false;
                    
                }
                else
                {
                    ModelState.AddModelError("ABCD", "Invalid Username / Password");
                    return View("Login");   
                }
                FormsAuthentication.SetAuthCookie(u.UserName, false);
                Session["IsAdmin"] = IsAdmin;
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                return View("Login");
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}