using Domain.Persons;
using InterfaceActions.Actions;

namespace ActionImplementation
{
    public class DisplayImportantInfo : IDisplayInfoAction, IContractorDisplay
    {
        public void DisplayInfo(Person person)
        {
            person.DisplayMainInfo();
        }
    }
}