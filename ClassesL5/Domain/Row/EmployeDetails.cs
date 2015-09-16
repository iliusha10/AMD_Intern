using System;

namespace Domain.Row
{
    public class EmployeDetails
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Department { get; set; }
        public string Role { get; set; }
        public string SkillName { get; set; }
        public int SkillLevel { get; set; }

        public override string ToString()
        {
            return string.Format("{0, -10} {1, -10} {2, -10} {3, -10} {4, -10} {5, -10} {6, -10}",
                Firstname, Lastname, BirthDate, Department, Role, SkillName, SkillLevel);
        }
    }
}