using System.ComponentModel.DataAnnotations;

namespace OnlineTicketManagement.Data.ViewModel
{
    public class RegisterVM
    {
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full name is Required")]
        public string FullName { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email Address is Required")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage ="Confirm Password is a Required field")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Passwords Do not matches")]
        public string ConfirmPassword { get; set; }
    }
}
