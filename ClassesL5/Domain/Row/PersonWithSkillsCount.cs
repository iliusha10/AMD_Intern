namespace Domain.Row
{
    public class PersonWithSkillsCount
    {
        public long PersonId { get; protected set; }

        public string Firstname { get; protected set; }

        public string Lastname { get; protected set; }

        public long SkillsCount { get; protected set; }

        public override string ToString()
        {
            return string.Format("{0, -15} {1, -15} {2, -15} {3, -15}", PersonId, Firstname, Lastname, SkillsCount);
        }
    }
}