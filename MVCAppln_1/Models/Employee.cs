using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MVCAppln_1.Validations;

namespace MVCAppln_1.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [FirstNameValidation]
        public string FName { get; set; }
        [Required(ErrorMessage = "Enter Last Name")]
        public string LName { get; set; }
       
        public int? Salary { get; set; }
    }
    
    
}