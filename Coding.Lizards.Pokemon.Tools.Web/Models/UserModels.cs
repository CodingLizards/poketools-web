using Coding.Lizards.Pokemon.Tools.Web.Strings;
using System.ComponentModel.DataAnnotations;

namespace Coding.Lizards.Pokemon.Tools.Web.Models {

    public class UserModel : BaseModel<string> {

        [Display(Name = "User_List_Email", ResourceType = typeof(Texts))]
        public string Email { get; set; }

        [Display(Name = "User_List_Username", ResourceType = typeof(Texts))]
        public string UserName { get; set; }

        [Display(Name = "User_List_Password", ResourceType = typeof(Texts))]
        public string Password { get; set; }
    }
}