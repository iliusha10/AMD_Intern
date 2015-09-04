using Domain.Persons;
using InterfaceActions.Actions;

namespace ActionImplementation
{
    public class DisplayAll : IDisplayInfoAction
    {
        public void DisplayInfo(Person person)
        {
            person.DisplayAll();
        }
    }
}