using System.ComponentModel.DataAnnotations;

namespace ngwmapp
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "Please enter Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter the password")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}