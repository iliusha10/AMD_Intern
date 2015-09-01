using System;
using Domain.Interfaces;

namespace Domain.Privileges
{
    public class DirectorPrivilege : Privileges
    {
        public DirectorPrivilege(IPrivileges i) : base(i)
        {
        }

        public override void AddPrivilege()
        {
            Input.AddPrivilege();
            Console.WriteLine("Added DirectorPrivilege");
            Logger.Logger.AddToLog("Added DirectorPrivilege");
        }
    }
}