using LoginManagement.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginManagement.DataAccess
{
    public class RoleRepository : IRepository<Role, int>
    {
        public UserDbContext dbContext = new UserDbContext();
        public void AddNew(Role entity)
        {
            try
            {

            dbContext.Roles.Add(entity);
            dbContext.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Role FindById(int id)
        {
            try
            {
            return dbContext.Roles
               .Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Role> GetAll()
        {
            try
            {
            return dbContext.Roles.Where(c=>c.IsActive==true).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Remove(int id)
        {
            try
            {

            var role = FindById(id);

            if (role is not null)
            {
                role.IsActive = false;
                Update(role);
            }
            }
            catch (Exception ex) 
            {
                throw ex;
            }

        }

        public void Update(Role entity)
        {
            try
            {
                var role = dbContext.Roles.Find(entity.RoleId);
                dbContext.ChangeTracker.Clear();
                dbContext.ChangeTracker.DetectChanges();
                if (role is not null)
                {
                    dbContext.Roles
                    .Where(c => c.RoleId == entity.RoleId)
                    .ExecuteUpdate(setters =>
                        setters.SetProperty(p => p.RoleName, entity.RoleName)
                        .SetProperty(p => p.Description, entity.Description)
                        .SetProperty(p => p.IsActive, entity.IsActive)
                    );
                }
                dbContext.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
