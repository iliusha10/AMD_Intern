using System;

namespace Domain.Row
{
    public class InternDetailsDto
    {
        public long Id { get; set; }
        public PersonType PersonType { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public double AverageMark { get; set; }

        public long CompanyId { get; set; }
    }
}