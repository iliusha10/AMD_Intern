using System.ComponentModel.DataAnnotations;
using Domain.CompanyAssets;
using Domain.Persons;

namespace WEB_Presentation.Models
{
    public class ContractorModel:PersonModel
    {
        public ContractorModel(Contractor cont):base(cont)
        {
            Salary = cont.Salary.Amount;
            WorkExp = cont.WorkExp;
        }

        public ContractorModel()
        {
            
        }
        public virtual double Salary { get; set; }

        [Display(Name = "Work Experience")]
        public virtual double WorkExp { get; set; }
    }
}