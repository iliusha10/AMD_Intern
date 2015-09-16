using System.ComponentModel.DataAnnotations;
using Domain;
using Domain.CompanyAssets;
using Domain.Row;

namespace WEB_Presentation.Models
{
    public class CompanyModel
    {
        public CompanyModel(CompanyAllInfo company)
        {
            CompanyName = company.CompanyName;
            Activity = company.Activity;
            City = company.City;
            Street = company.Street;
        }

        public CompanyModel()
        {

        }

        [Display(Name = "Company Name")]
        public string CompanyName { get;  set; }
        public FieldOfActivity Activity { get;  set; }
        public string City { get;  set; }
        public string Street { get;  set; }


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
    }
}