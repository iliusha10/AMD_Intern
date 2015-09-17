using System.ComponentModel.DataAnnotations;
using Domain.CompanyAssets;

namespace WEB_Presentation.Models
{
    public class EmployeeModel :PersonModel
    {
        public virtual Salary Salary { get; set; }

        [Display(Name = "Work Experience")]
        public virtual double WorkExp { get; set; }

        public string Department { get; set; }
        public string Role { get; set; }
    }
}