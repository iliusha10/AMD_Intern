namespace Domain.Row
{
    public class PersonDto
    {
        public long Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public PersonType Worker { get; set; }
    }
}