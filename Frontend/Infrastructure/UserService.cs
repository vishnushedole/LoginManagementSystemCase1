using AuthorizationLibrary;
using LoginManagement.Entities;

namespace Frontend.Infrastructure
{
    public interface IUserService
    {
        public Task<AuthenticationResponse> Authenticate(AuthenticationRequest request);
        public Task<User> GetUserModel(int userId);
    }
    public class UserService : IUserService
    {
        public Task<AuthenticationResponse> Authenticate(AuthenticationRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserModel(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
