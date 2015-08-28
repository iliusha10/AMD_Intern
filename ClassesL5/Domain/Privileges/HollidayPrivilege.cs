using System;
using Domain.Interfaces;

namespace Domain.Privileges
{
    public class HollidayPrivilege : Privileges
    {

        public HollidayPrivilege(IPrivileges i) : base(i)
        {
        }

        public override void AddPrivilege()
        {
            Input.AddPrivilege();
            Console.WriteLine("Added HollidayPrivilege");
            Logger.Logger.AddToLog("Added HollidayPrivilege");
        }
    }
}