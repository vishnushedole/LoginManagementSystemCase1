using LoginManagement.Entities;

namespace AuthorizationLibrary
{
    public class AuthenticationResponse
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Token { get; set; }

        public AuthenticationResponse(User userDetail, string token)
        {
            Token = token;
            FullName = userDetail.FirstName + ". " + userDetail.LastName;
            UserId = userDetail.UserId;
        }
        public AuthenticationResponse() { }
    }
}
