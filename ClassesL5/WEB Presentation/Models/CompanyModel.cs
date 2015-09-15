using System.ComponentModel.DataAnnotations;
using Domain;

namespace WEB_Presentation.Models
{
    public class CompanyModel
    {
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        public FieldOfActivity Activity { get; set; }

        public string City { get; set; }

        public string Street { get; set; }
    }
}