using Domain.Domain;
using InterfaceActions.Actions;

namespace ActionImplementation
{
    public class ComapnyInfo : ICompany
    {
        public void ShowCpmpanyInfo(Company company)
        {
            company.DisplayAll();
            //Console.WriteLine("ShowCpmpanyInfo");
        }
    }
}