using System.ComponentModel.DataAnnotations;

namespace WEB_Presentation.Models
{
    public class InternModel: PersonModel
    {
        [Display(Name = "Average Mark")]
        public double AverageMark { get; set; }
    }
}