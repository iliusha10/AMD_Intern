using Domain.Persons;

namespace WEB_Presentation.Models
{
    public class EmployeeModel : ContractorModel
    {
        public EmployeeModel(Employee emp):base (emp)
        {
            
            Department = emp.Department;
            Role = emp.Role;
        }

        public EmployeeModel()
        {
        }

        public string Department { get; set; }
        public string Role { get; set; }
    }
}