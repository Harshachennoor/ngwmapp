using System.ComponentModel.DataAnnotations;

namespace ngwmapp
{
    public class Customer
    {
        public string CustomerId { get; set; }

        [Required(ErrorMessage = "Please enter First Name")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Only alphabets")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter Last Name")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Only alphabets")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter the Email")]
        [RegularExpression(@"^[a-zA-Z0-9.]+@[a-zA-Z]+\.[a-zA-Z]{2,}$", ErrorMessage = "Must be characters, digits, . and @ only")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter the password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter Phone number")]
        [RegularExpression("^[0-9]{10}", ErrorMessage = "Must be 10 digits")]
        public string PhoneNumber { get; set; }
    }
}