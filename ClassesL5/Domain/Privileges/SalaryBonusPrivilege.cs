using System;
using Domain.Interfaces;

namespace Domain.Privileges
{
    public class SalaryBonusPrivilege : Privileges
    {
        public SalaryBonusPrivilege(IPrivileges i) : base(i)
        {
        }

        public override void AddPrivilege()
        {
            Input.AddPrivilege();
            Console.WriteLine("Added SalaryBonusPrivilege");
            Logger.Logger.AddToLog("Added SalaryBonusPrivilege");
        }
    }
}