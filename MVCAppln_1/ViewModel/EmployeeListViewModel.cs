using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAppln_1.ViewModel
{
    public class EmployeeListViewModel : BaseViewModel
    {
        public List<EmployeeViewModel> Employee {get; set;}
        //public string UserName { get; set; }
       // public FooterViewModel FooterData { get; set; }

    }
}