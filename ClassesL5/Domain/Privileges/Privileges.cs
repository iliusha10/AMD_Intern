using Domain.Interfaces;

namespace Domain.Privileges
{
    public abstract class Privileges : IPrivileges
    {
        protected IPrivileges Input;
        
        protected Privileges(IPrivileges i)
        {
            Input = i; //store the item to be decorated
        }
        public abstract void AddPrivilege();
    }
}