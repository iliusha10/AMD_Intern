namespace Domain.Row
{
    public class CompanyNameAndActivity
    {
        public long Id { get; protected set; }
        public string CompanyNames { get; protected set; }
        public FieldOfActivity Activity { get; protected set; }
    }
}