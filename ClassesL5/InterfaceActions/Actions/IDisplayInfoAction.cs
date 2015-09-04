using Domain.Persons;

namespace InterfaceActions.Actions
{
    public interface IDisplayInfoAction
    {
        //void DisplayInfo<T>(T person) where T:Person;
        void DisplayInfo(Person person);
    }
}