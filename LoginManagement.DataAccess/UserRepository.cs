using LoginManagement.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginManagement.DataAccess
{

    public class UserRepository : IUserRepository<UserRole, int>
    {
        public UserDbContext dbContext = new UserDbContext();
        public void AddNew(User entity)
        {
            try
            {
                dbContext.Users.Add(entity);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User FindById(int id)
        {
            try
            {
            var user =  dbContext.Users
                .Find(id);
                if (user.IsActive == true)
                    return user;
                else
                    return null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<User> GetAll()
        {
            try
            {
                return dbContext.Users.Where(c => c.IsActive == true).ToList();
            }
            catch( Exception ex)
            {
                throw ex;
            }
        }

        public int GetRoleIdForUser(int UserId)
        {
            //var user = FindById(UserId);
            //if(user is not null)
            //{
            //    var userroles = dbContext.UserRole.Where(c=>c.IsActive==true).ToList();
            //    foreach(var row in userroles)
            //    {
            //        if(row.UserId ==  UserId)
            //            return row.RoleId;
            //    }
            //}
            //return -1;

            try
            {

                int roleId = dbContext.UserRole
                    .Where(c => c.UserId == UserId)
                    .Select(c => c.RoleId).FirstOrDefault();

                return roleId;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public void Remove(int id)
        {
            try
            {
                var user = FindById(id);

                if (user is not null)
                {
                    user.IsActive = false;
                    Update(user);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        public void Update(User entity)
        {
            try
            {
                var user = dbContext.Users.Find(entity.UserId);
                dbContext.ChangeTracker.Clear();
                dbContext.ChangeTracker.DetectChanges();
                if (user is not null)
                {
                    dbContext.Users
                    .Where(c => c.UserId == entity.UserId)
                    .ExecuteUpdate(setters =>
                        setters.SetProperty(p => p.FirstName, entity.FirstName)
                        .SetProperty(p => p.LastName, entity.LastName)
                        .SetProperty(p => p.UserName, entity.UserName)
                        .SetProperty(p=> p.Password, entity.Password)
                        .SetProperty(p=> p.IsActive, entity.IsActive)
                    );
                }
                    dbContext.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;

            }

        }

        public UserRole UpdateUserRole(UserRole entity)
        {
            try
            {

            var userrole = dbContext.UserRole.AsNoTracking().FirstOrDefault(c=>c.UserId==entity.UserId);
            dbContext.ChangeTracker.Clear();
            dbContext.ChangeTracker.DetectChanges();
            if (userrole is not null)
            {
                    dbContext.UserRole
                    .Where(c => c.UserId == entity.UserId)
                    .ExecuteUpdate(setters =>
                        setters.SetProperty(p => p.IsActive, entity.IsActive)
                        .SetProperty(p=>p.RoleId, entity.RoleId)
                    );
                userrole.IsActive = false;
            }
            else
            {
                dbContext.UserRole.Add(entity);
                dbContext.SaveChanges();
                return entity;
            }
            return userrole;
            }
            catch(Exception ex )
            {
                throw ex;
            }
        }
    }
}
