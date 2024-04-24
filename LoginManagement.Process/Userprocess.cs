using LoginManagement.DataAccess;
using LoginManagement.Entities;

namespace LoginManagement.Process
{
    public class Userprocess
    {
        IRepository<User, int> Userrepository = new UserRepository();
        IUserRepository<UserRole, int> UserRoleRepository = new UserRepository();
        public List<User> GetAllUsers()
        {
            try
            {
            return Userrepository.GetAll().ToList();
            }
            catch
            {
                throw;
            }
        }
        public User GetUserById(int id)
        {
            try
            {

            return Userrepository.FindById(id);
            }catch
            {
                throw;
            }
        }
        public void AddUser(string name,string firstName,string lastName,string password)
        {
            try
            {

            var user = UserFactory.CreateNew(name, firstName, lastName, password,true);
                Console.WriteLine(user);
            if (user != null)
                Userrepository.AddNew(user);
            else
                Console.Write("Password is not in correct format");
            }
            catch
            {
                throw;
            }
        }
        public void UpdateUser(int id,string name,string firstName,string lastName,string password)
        {
            try
            {
                var user = UserFactory.CreateNew(name, firstName, lastName, password, true);
                user.UserId = id;
                Userrepository.Update(user);
            }
            catch
            {
                throw;
            }
        }
        public void RemoveUser(int id)
        {
            try
            {

            var user = GetUserById(id);
            if(user is not null)
            {
                Userrepository.Remove(id);
            }
            else
            {
                Console.WriteLine("User does not exist");
                Console.Clear();
            }
            }
            catch
            {
                throw;
            }
        }
        public Role GetRoleForUser(int userId)
        {
            try
            {

            int roleid = UserRoleRepository.GetRoleIdForUser(userId);

            RoleProcess rp = new RoleProcess();
            return rp.GetRoleById(roleid);
            }
            catch
            {
                throw;
            }

        }

        public void UpdateRole(int userId, int roleId)
        {
            try
            {

            UserRole ur = new UserRole();
            ur.UserId = userId;
            ur.RoleId = roleId;
            ur.IsActive = true;

            UserRoleRepository.UpdateUserRole(ur);
            }
            catch
            {
                throw;
            }
        }
    }
}
