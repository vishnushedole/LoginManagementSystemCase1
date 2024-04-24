using AuthorizationLibrary;
using LoginManagement.Entities;

namespace AuthenticationAPI.Service
{
    public interface IUserServiceAsync
    {
        Task<User> AuthenticateAsync(AuthenticationRequest model);
        Task<User> GetUserDetails(int userId);
    }

    public class UserService : IUserServiceAsync
    {
        private readonly UserDbContext _context;

        //private readonly List<UserModel> _usersList = new List<UserModel>
        //{
        //    new UserModel{UserId=1, FirstName="Rueben", LastName="Gupta", RoleName="Admin", Email="rueben.gupta@email.com",
        //    Username="admin", Password="admin"},
        //    new UserModel{UserId=1, FirstName="Sharan", LastName="Purohit", RoleName="Operator", Email="sharan.purohit@email.com", Username="operator", Password="operator"},
        //};

        public UserService(UserDbContext context)
        {
            _context = context;
        }

        public Task<User> AuthenticateAsync(AuthenticationRequest model)
        {
            var user = _context.Users.FirstOrDefault(c => c.UserName == model.Username && c.Password == model.Password);
            return Task.Run(() => user);
        }
        public Task<User> GetUserDetails(int userId)
        {
            var user = _context.Users.FirstOrDefault(c => c.UserId == userId);
            return Task.Run(() => user);
        }
    }
}
