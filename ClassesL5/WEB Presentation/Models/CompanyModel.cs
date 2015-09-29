using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain;
using Domain.Row;

namespace WEB_Presentation.Models
{
    public class CompanyModel
    {
        public CompanyModel(CompanyAllInfo company)
        {
            Id = company.Id;
            CompanyName = company.CompanyName;
            Activity = company.Activity;
            City = company.City;
            Street = company.Street;
        }

        public CompanyModel()
        {
        }

        public long Id { get; set; }

        [Display(Name = "Company Name")]
        [Required(ErrorMessage = "Company name is required")]
        public string CompanyName { get; set; }

        [Display(Name = "Field of activity")]
        [Required(ErrorMessage = "Activity name is required")]
        public FieldOfActivity Activity { get; set; }

        [Required(ErrorMessage = "City is required")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$",
            ErrorMessage = "First letter should be uppercase and only letters accepted")]
        public string City { get; set; }

        [Required(ErrorMessage = "Street is required")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$",
            ErrorMessage = "First letter should be uppercase and only letters accepted")]
        public string Street { get; set; }


        public CompanyAllInfo TransformToDto(long id)
        {
            var newcompany = new CompanyAllInfo();
            newcompany.Id = id;
            newcompany.CompanyName = CompanyName;
            newcompany.Activity = Activity;
            newcompany.City = City;
            newcompany.Street = Street;
            return newcompany;
        }

        public IList<CompanyModel> ConvertToCompanyModel(IList<CompanyAllInfo> company)
        {
            var allCompanies = new List<CompanyModel>();
            foreach (var comp in company)
            {
                var item = new CompanyModel();
                item.Id = comp.Id;
                item.CompanyName = comp.CompanyName;
                item.Activity = comp.Activity;
                item.City = comp.City;
                item.Street = comp.Street;

                allCompanies.Add(item);
            }
            return allCompanies;
        }
    }
}