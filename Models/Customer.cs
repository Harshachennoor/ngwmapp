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

        [Required(ErrorMessage = "Please enter the url of your website")]
        public string WebsiteUrl { get; set; }


        [Required(ErrorMessage = "Please enter company name")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Please select the country")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Please enter the address")]
        public string AddressOne { get; set; }

        public string AddressTwo { get; set; }

        [Required(ErrorMessage = "Please enter the city")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please select the state")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter the postal code")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Must be digits")]
        public string PostalCode { get; set; }
    }
}