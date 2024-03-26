using LoginManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginManagement.DataAccess
{
    public interface IUserRepository<TEntity,TIdentity>:IRepository<User,TIdentity>
    {
        TIdentity GetRoleIdForUser(TIdentity UserId);
        TEntity UpdateUserRole(TEntity entity);
    }
}
