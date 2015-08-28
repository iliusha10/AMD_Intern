using System.Collections.Generic;
using Domain.Domain;
using InterfaceActions.Actions;

namespace Factories.Factories
{
    public class InternFactory
    {
        private readonly IDisplayInfoAction _displayInfoAction;

        public InternFactory(IDisplayInfoAction displayInfoAction)
        {
            _displayInfoAction = displayInfoAction;
        }

        public Intern CreateIntern(string fname, string lname, string bdate, double avmark, Company company)
        {
            var intern = new Intern(fname, lname, bdate, avmark, company);
            OnInternCreation(intern);
            return intern;
               
        }

        public void OnInternCreation(Intern intern)
        {
            _displayInfoAction.DisplayInfo(intern);
            //intern.DisplayAll();
        }
    }
}