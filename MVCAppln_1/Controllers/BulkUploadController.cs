using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAppln_1.ViewModel;
using MVCAppln_1.Models;
using System.IO;
using System.Threading.Tasks;
using System.Threading;

namespace MVCAppln_1.Controllers
{
    public class BulkUploadController : AsyncController
    {
        //
        // GET: /BulkUpload/
        public ActionResult Index()
        {
            return View(new FileUploadViewModel());
        }

        public async Task<ActionResult> BulkUpload(FileUploadViewModel model)
        {
            // **** for synchronus calll
            //List<Employee> employees = GetEmployees(model);
            //EmployeeBussinessLayer bal = new EmployeeBussinessLayer();
            //bal.UploadEmployees(employees);
            //return RedirectToAction("Index", "Employee");

            //**** for asynchronus call
            int t1 = Thread.CurrentThread.ManagedThreadId;
            List<Employee> employees = await Task.Factory.StartNew<List<Employee>>(() => GetEmployees(model));
            int t2 = Thread.CurrentThread.ManagedThreadId;
            EmployeeBussinessLayer bal = new EmployeeBussinessLayer();
            bal.UploadEmployees(employees);
            return RedirectToAction("Index", "Employee");
        }

        private List<Employee> GetEmployees(FileUploadViewModel model)
        {
            List<Employee> employees = new List<Employee>();
            StreamReader csvreader = new StreamReader(model.fileUpload.InputStream);
            csvreader.ReadLine(); // Assuming first line is header
            while (!csvreader.EndOfStream)
            {
                var line = csvreader.ReadLine();
                var values = line.Split(',');//Values are comma separated
                Employee e = new Employee();
                e.FName = values[0];
                e.LName = values[1];
                e.Salary = int.Parse(values[2]);
                employees.Add(e);
            }
            return employees;
        }
    }
}