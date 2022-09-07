using System.ComponentModel.DataAnnotations;

namespace OnlineTicketManagement.Data.ViewModel
{
    public class LoginVM
    {
        [Display(Name="Email Address")]
        [Required(ErrorMessage = "Email Address is Required")]
        public string EmailAddress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
