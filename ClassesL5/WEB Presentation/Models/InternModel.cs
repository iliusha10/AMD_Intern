using System.ComponentModel.DataAnnotations;
using Domain.Persons;

namespace WEB_Presentation.Models
{
    public class InternModel: PersonModel
    {
        public InternModel(Intern pers):base()
        {
            PersonType = pers.PersonType;
            BirthDate = pers.DateOfBirth;
            Firstname = pers.FName;
            Id = pers.Id;
            Lastname = pers.LName;
            AverageMark = pers.AverageMark;
            City = pers.Address.City;
            Street = pers.Address.Street;
            CompanyName = pers.Company.CompanyName;
        }

        public InternModel()
        {
            
        }
        [Display(Name = "Average Mark")]
        public double AverageMark { get; set; }
    }
}