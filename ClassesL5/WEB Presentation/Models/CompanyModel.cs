using System.ComponentModel.DataAnnotations;
using Domain;

namespace WEB_Presentation.Models
{
    public class CompanyModel
    {
        [UIHint("TextEditor")]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        public FieldOfActivity Activity { get; set; }

        [UIHint("TextEditor")]
        public string City { get; set; }

        [UIHint("TextEditor")]
        public string Street { get; set; }
    }
}