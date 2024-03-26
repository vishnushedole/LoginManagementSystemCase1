using LoginManagement.DataAccess;
using LoginManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    [TestClass]
    public class UserRoleTests
    {
        IUserRepository<UserRole, int> repository = new UserRepository();
        [TestMethod]
        public void Test_For_UpdateUserRole()
        {
            UserRole ur = new UserRole();
            ur.UserId = 3;
            ur.RoleId = 1;
            ur.IsActive = false;
            var newur = repository.UpdateUserRole(ur);
            int  rid = repository.GetRoleIdForUser(newur.UserId);
            Assert.IsNotNull(newur);
            Assert.AreEqual(ur.IsActive, newur.IsActive);
            Assert.AreEqual(ur.RoleId, rid);
        }
    }
}
