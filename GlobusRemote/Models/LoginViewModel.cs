using System.ComponentModel.DataAnnotations;

namespace GlobusRemote.Models
{
    public class LoginViewModel
    {
        [Required (ErrorMessage = "LoginRequired")]
        [DataType(DataType.Text)]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "PasswordRequired")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        //[Display(Name = "Remember me?")]
        //public bool RememberMe { get; set; }
    }
}
