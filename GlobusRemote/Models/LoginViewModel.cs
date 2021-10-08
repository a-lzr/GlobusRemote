using GlobusRemote.Data.Annotations;
using System.ComponentModel.DataAnnotations;

namespace GlobusRemote.Models
{
    public class LoginViewModel
    {
        [RequiredLocalized]
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Localize.Index), Name = "Field_Base_Login")]
        public string Login { get; set; }

        [RequiredLocalized]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Localize.Index), Name = "Field_Base_Password")]
        public string Password { get; set; }

        //[Display(Name = "Remember me?")]
        //public bool RememberMe { get; set; }
    }
}
