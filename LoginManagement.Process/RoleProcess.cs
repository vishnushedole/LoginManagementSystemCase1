using LoginManagement.DataAccess;
using LoginManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginManagement.Process
{
    public class RoleProcess
    {
        IRepository<Role, int> Rolerepository = new RoleRepository();
        public List<Role> GetAllRoles()
        {
            try
            {

            return Rolerepository.GetAll().ToList();
            }
            catch
            {
                throw;
            }
        }
        public Role GetRoleById(int id)
        {
            try
            {

            return Rolerepository.FindById(id);
            }
            catch
            {
                throw;
            }
        }
        public void AddRole(string name, string discription)
        {
            try
            {

            var role = RoleFactory.CreateNew(name, discription, true);
            Rolerepository.AddNew(role);
            }
            catch
            {
                throw;
            }
        }
        public void UpdateRole(int id, string name, string discription)
        {
            try
            {

            var role = RoleFactory.CreateNew(name, discription, true);
            role.RoleId = id;
            Rolerepository.Update(role);
            }
            catch
            {
                throw;
            }
        }
        public void RemoveRole(int id)
        {
            try
            {

            var role = GetRoleById(id);
            if (role is not null)
            {
                Rolerepository.Remove(id);
            }
            else
            {
                Console.WriteLine("Role does not exist");
                Console.Clear();
            }
            }
            catch
            {
                throw;
            }
        }
    }
}
