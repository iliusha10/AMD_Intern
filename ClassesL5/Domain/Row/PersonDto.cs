using System.ComponentModel.DataAnnotations;

namespace Domain.Row
{
    public class PersonDto
    {
        public long Id { get; set; }

        [Display(Name = "First name")]
        public string Firstname { get; set; }

        [Display(Name = "Last name")]
        public string Lastname { get; set; }

        public PersonType Worker { get; set; }
    }
}