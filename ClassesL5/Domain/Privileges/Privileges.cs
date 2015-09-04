using System;
using Domain.Interfaces;
using Domain.Persons;


namespace Domain.Privileges
{
    public abstract class Privileges<TPrivileges> : IPrivileges where TPrivileges : IPrivileges
    {
        protected TPrivileges Input;

        protected Privileges(TPrivileges person)
        {
            Input = person; //store the item to be decorated
        }

       
         

        public abstract void AddPrivilege();
    }
}