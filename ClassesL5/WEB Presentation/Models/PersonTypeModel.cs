using System.ComponentModel.DataAnnotations;
using Domain;

namespace WEB_Presentation.Models
{
    public class PersonTypeModel
    {
        [Display(Name = "Person type")]
        public PersonType Type { get; set; }
    }
}