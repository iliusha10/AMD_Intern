using System;
using Domain.Interfaces;

namespace Domain.Privileges
{
    public class KingOfTheWorldPrivilege : Privileges
    {
        public KingOfTheWorldPrivilege(IPrivileges i) : base(i)
        {
        }

        public override void AddPrivilege()
        {
            Input.AddPrivilege();
            Console.WriteLine("Added KingOfTheWorldPrivilege");
            Logger.Logger.AddToLog("Added KingOfTheWorldPrivilege");
        }
    }
}