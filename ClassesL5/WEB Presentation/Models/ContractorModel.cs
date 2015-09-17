using System.ComponentModel.DataAnnotations;
using Domain.CompanyAssets;

namespace WEB_Presentation.Models
{
    public class ContractorModel:PersonModel
    {
        public virtual Salary Salary { get; set; }

        [Display(Name = "Work Experience")]
        public virtual double WorkExp { get; set; }
    }
}