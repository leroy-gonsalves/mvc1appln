using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCAppln_1.DAL;

namespace MVCAppln_1.Models
{
    public class EmployeeBussinessLayer
    {
        //public List<Employee> GetEmployees()
        //{
        //    List<Employee> employees = new List<Employee>();
        //    Employee emp = new Employee();
        //    emp.FName = "johnson";
        //    emp.LName = " fernandes";
        //    emp.Salary = 14000;
        //    employees.Add(emp);

        //    emp = new Employee();
        //    emp.FName = "michael";
        //    emp.LName = "jackson";
        //    emp.Salary = 16000;
        //    employees.Add(emp);

        //    emp = new Employee();
        //    emp.FName = "robert";
        //    emp.LName = " pattinson";
        //    emp.Salary = 20000;
        //    employees.Add(emp);

        //    return employees;
        //}


        public List<Employee> GetEmployees()
        {
            SalesERPDAL saldb = new SalesERPDAL();
            return saldb.Employees.ToList();
        }

        public Employee SaveEmployee(Employee e)
        {
            SalesERPDAL salesDal = new SalesERPDAL();
            salesDal.Employees.Add(e);
            salesDal.SaveChanges();
            return e;
        }

        //public bool IsValidUser(UserDetails u)
        //{
        //    if (u.UserName == "asd" && u.Password == "asd")
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        public UserStatus GetUserValidity(UserDetails u)
        {
            if (u.UserName == "asd" && u.Password == "asd")
            {
                return UserStatus.AuthenticatedAdmin;
            }
            else if (u.UserName == "leroy" && u.Password == "leroy")
            {
                return UserStatus.AuthenticatedUser;
            }
            else
            {
                return UserStatus.NonAuthenticatedUser;
            }
        }

        public void UploadEmployees(List<Employee> employees)
        {
            SalesERPDAL salesDal = new SalesERPDAL();
            salesDal.Employees.AddRange(employees);
            salesDal.SaveChanges();
        }
    }
}