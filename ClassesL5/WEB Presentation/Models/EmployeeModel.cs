using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.CompanyAssets;

namespace WEB_Presentation.Models
{
    public class EmployeeModel
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual Salary Salary { get; set; }
        public virtual double WorkExp { get; set; }
        public string Department { get; set; }
        public string Role { get; set; }
    }
}