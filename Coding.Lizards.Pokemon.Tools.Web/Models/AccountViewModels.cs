namespace Coding.Lizards.Pokemon.Tools.Web.Models {

    using Strings;
    using System.ComponentModel.DataAnnotations;

    public class LoginViewModel {

        [Required]
        [EmailAddress]
        [Display(Name = "Account_Login_Email", ResourceType = typeof(Texts))]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Account_Login_Password", ResourceType = typeof(Texts))]
        public string Password { get; set; }
    }

    public class RegisterViewModel {

        [Required]
        [EmailAddress]
        [Display(Name = "Account_Register_Email", ResourceType = typeof(Texts))]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Account_Register_Password", ResourceType = typeof(Texts))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Account_Register_ConfirmPassword", ResourceType = typeof(Texts))]
        [Compare("Password", ErrorMessageResourceName = "Account_Register_ConfirmPassword_Compare", ErrorMessageResourceType = typeof(Texts))]
        public string ConfirmPassword { get; set; }
    }
}