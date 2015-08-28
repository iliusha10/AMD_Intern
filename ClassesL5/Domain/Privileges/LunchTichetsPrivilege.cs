using System;
using Domain.Interfaces;

namespace Domain.Privileges
{
    public class LunchTichetsPrivilege : Privileges
    {
        public LunchTichetsPrivilege(IPrivileges i) : base(i)
        {
        }

        public override void AddPrivilege()
        {
            Input.AddPrivilege();
            Console.WriteLine("Added LunchTichetsPrivilege");
            Logger.Logger.AddToLog("Added LunchTichetsPrivilege");
        }
    }
}