using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Domain;
using Domain.CompanyAssets;

namespace WEB_Presentation.Models
{
    public class AllPersonModel
    {
        public AllPersonModel(IList<SelectListItem> companies)
        {
            BirthDate = DateTime.Now.Date;
            Companies = companies;
            //Skills = new List<PersonSkills>();
        }

        public AllPersonModel()
        {
        }

        public long Id { get; set; }

        [Display(Name = "Person type")]
        public PersonType PersonType { get; set; }

        [Display(Name = "First name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "First letter should be uppercase and only letters accepted")]
        [Required(ErrorMessage = "First Name is required")]
        public string Firstname { get; set; }

        [Display(Name = "Last name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "First letter should be uppercase and only letters accepted")]
        [Required(ErrorMessage = "Last Name is required")]
        public string Lastname { get; set; }

        [Display(Name = "Birth date")]
        [Required(ErrorMessage = "Birth Date is required")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Street is required")]
        public string Street { get; set; }

        [Required(ErrorMessage = "City is required")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "First letter should be uppercase and only letters accepted")]
        public string City { get; set; }

        [Display(Name = "Average mark")]
        [Required(ErrorMessage = "Average mark is required")]
        [Range(1, 100, ErrorMessage = "Average mark must be between $1 and $100")]
        public double AverageMark { get; set; }

        [Display(Name = "Work experience")]
        [Range(1, 100, ErrorMessage = "Work experience must be between $1 and $100")]
        [Required(ErrorMessage = "Work experience is required")]
        public double WorkExp { get; set; }

        [Required(ErrorMessage = "Salary is required")]
        public double Salary { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "First letter should be uppercase and only letters accepted")]
        public string Department { get; set; }

        [Display(Name = "Function")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "First letter should be uppercase and only letters accepted")]
        [Required(ErrorMessage = "Title is required")]
        public string Role { get; set; }


        public string CompanyName { get; set; }
        public long CompanyId { get; set; }
        public IList<SelectListItem> Companies { get; set; }


        //public string SkillName { get; set; }
        //public long SkillLevel { get; set; }
        //public IList<PersonSkills> Skills { get; set; }




        //public void AddSkill(string name, int level)
        //{
        //    var skill = new PersonSkills(name, level);
        //    Skills.Add(skill);
        //}
    }
}