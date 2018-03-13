using MVCAppln_1.Filters;
using MVCAppln_1.Models;
using MVCAppln_1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAppln_1.Controllers
{
    //[AllowAnonymous] for non-authenticated requests
    public class EmployeeController : Controller
    {
        //override string method
        public override string ToString()
        {
            return base.ToString();
        }


        public string GetString()
        {
            return "controller data";
        }

        //public non-action method
        [NonAction]
        public string SimpleMethod()
        {
            return "Not action method";
        }

        public ActionResult GetView()
        {
            Employee emp = new Employee();
            emp.FName = "Leroy";
            emp.LName = "Gonsalves";
            emp.Salary = 30000;

            //// ViewData["Employee"] = emp;                 //  view data
            // //return View("MyView");
            // //ViewBag.Employee = emp;                    //  view bag
            // //return View("MyView");

            // return View("MyView", emp);

            // *********  code for view model **********
            EmployeeViewModel viewm = new EmployeeViewModel();
            viewm.EmployeeName = emp.FName + " " + emp.LName;
            viewm.Salary = emp.Salary.ToString();
            if (emp.Salary > 20000)
            {
                viewm.SalaryColor = "purple";
            }
            else
            {
                viewm.SalaryColor = "greeen";
            }
            //viewm.UserName = "Admin";
            return View("MyView", viewm);
        }
               
        [Authorize]
        [Route("ABC")]
        public ActionResult Index()
        {
            EmployeeListViewModel emplv = new EmployeeListViewModel();
            EmployeeBussinessLayer empbl = new EmployeeBussinessLayer();
            List<Employee> employees = empbl.GetEmployees();
            List<EmployeeViewModel> empview = new List<EmployeeViewModel>();
            emplv.UserName = User.Identity.Name;
            //emplv.FooterData.CompanyName = "ADDFG FJHDHDHDH JDJFHDHFHF";
           // emplv.FooterData.Year = "2018 - @Copyright";
            foreach (Employee emp in employees)
            {
                EmployeeViewModel empViewModel = new EmployeeViewModel();
                empViewModel.EmployeeName = emp.FName + " " + emp.LName;
                empViewModel.Salary = emp.Salary.ToString();
                if (emp.Salary > 15000)
                {
                    empViewModel.SalaryColor = "yellow";
                }
                else
                {
                    empViewModel.SalaryColor = "green";
                }
                empview.Add(empViewModel);
            }
            emplv.Employee = empview;
            return View("Index", emplv);
        }


        public ActionResult Index(string ID)
        {
            EmployeeListViewModel emplv = new EmployeeListViewModel();
            EmployeeBussinessLayer empbl = new EmployeeBussinessLayer();
            List<Employee> employees = empbl.GetEmployees();
            List<EmployeeViewModel> empview = new List<EmployeeViewModel>();

            foreach (Employee emp in employees)
            {
                EmployeeViewModel empViewModel = new EmployeeViewModel();
                empViewModel.EmployeeName = emp.FName + " " + emp.LName;
                empViewModel.Salary = emp.Salary.ToString();
                if (emp.Salary > 15000)
                {
                    empViewModel.SalaryColor = "yellow";
                }
                else
                {
                    empViewModel.SalaryColor = "green";
                }
                empview.Add(empViewModel);
            }
            emplv.Employee = empview;
            return View("Index", emplv);
        }

        public ActionResult GetAddNewLink()
        {
            if (Convert.ToBoolean(Session["IsAdmin"]))
            {
                return PartialView("AddNewLink");
            }
            else
            {
                return new EmptyResult();
            }
        }

        [AdminFilter]
        public ActionResult AddNew()
        {
            //return View("CreateEmployee");
            return View("CreateEmployee",new CreateEmployeeViewModel()); // to handle null .passing null values to view
        }

        [AdminFilter]
        public ActionResult SaveEmployee(Employee e, string BtnSave)
        {
            switch (BtnSave)
            {
                case "Save Employee":
                    if (ModelState.IsValid)
                    {
                        EmployeeBussinessLayer empbl = new EmployeeBussinessLayer();
                        empbl.SaveEmployee(e);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                       // return View("CreateEmployee");

                        // to maintain data on validation
                        CreateEmployeeViewModel cevm = new CreateEmployeeViewModel();
                        cevm.FiName = e.FName;
                        cevm.LaName = e.LName;
                        if (e.Salary.HasValue)
                        {
                            cevm.Salary1 = e.Salary.ToString();
                        }
                        else
                        {
                            cevm.Salary1 = ModelState["Salary"].Value.AttemptedValue;
                        }
                        return View("CreateEmployee", cevm);
                    }                    
                case "Cancel":
                    return RedirectToAction("Index");
            }
            return new EmptyResult();
        }

    }
}