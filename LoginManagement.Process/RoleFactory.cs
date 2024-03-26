using LoginManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginManagement.Process
{
    public class RoleFactory
    {
        public static Role CreateNew(string RoleName, string Discription, bool isActive)
        {
            Role role = new Role();
            role.RoleName = RoleName;
            role.Description = Discription;
            role.IsActive = isActive;
            return role;
        }
    }
}
