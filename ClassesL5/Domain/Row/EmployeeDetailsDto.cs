using System;

namespace Domain.Row
{
    public class EmployeeDetailsDto
    {
        public long Id { get; set; }
        public PersonType PersonType { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public double WorkExp { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }
        public string Role { get; set; }

        public long CompanyId { get; set; }
    }
}