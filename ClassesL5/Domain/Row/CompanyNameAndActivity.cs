using System.ComponentModel.DataAnnotations;

namespace Domain.Row
{
    public class CompanyNameAndActivity
    {
        public long Id { get; protected set; }

        [Display(Name = "Company name")]
        public string CompanyNames { get; protected set; }

        [Display(Name = "Field of activity")]
        public FieldOfActivity Activity { get; protected set; }
    }
}