using System.ComponentModel.DataAnnotations;
using Domain.Persons;

namespace WEB_Presentation.Models
{
    public class InternModel: PersonModel
    {
        public InternModel(Intern pers):base()
        {
            BirthDate = pers.DateOfBirth;
            Firstname = pers.FName;
            Id = pers.Id;
            Lastname = pers.LName;
            AverageMark = pers.AverageMark;
        }

        public InternModel()
        {
            
        }
        [Display(Name = "Average Mark")]
        public double AverageMark { get; set; }
    }
}