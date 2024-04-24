using System.ComponentModel.DataAnnotations;

namespace AuthorizationLibrary
{
    public class AuthenticationRequest
    {
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

    }
}
