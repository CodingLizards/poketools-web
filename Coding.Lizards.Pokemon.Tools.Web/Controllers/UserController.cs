namespace Coding.Lizards.Pokemon.Tools.Web.Controllers {

    using Models;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin.Security;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;

    [Authorize]
    public class UserController : BaseController<UserModel, string, ListUserViewModel, AddUserViewModel, EditUserViewModel, DetailsUserViewModel, DeleteUserViewModel> {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ApplicationSignInManager SignInManager {
            get {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager {
            get {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set {
                _userManager = value;
            }
        }

        [HttpPost]
        public override async Task<ActionResult> Delete(DeleteUserViewModel model) {
            var usr = await UserManager.FindByIdAsync(model.Item.Id);
            await UserManager.DeleteAsync(usr);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public override async Task<ActionResult> Add(AddUserViewModel model) {
            var user = new ApplicationUser { Email = model.Item.Email, UserName = model.Item.Email };
            var result = await UserManager.CreateAsync(user, model.Item.Password);

            var code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
            await UserManager.ConfirmEmailAsync(user.Id, code);

            return RedirectToAction("Details", new { id = user.Id });
        }

        [HttpPost]
        public override async Task<ActionResult> Edit(EditUserViewModel model) {
            var res = await UserManager.SetEmailAsync(model.Item.UserName, model.Item.Email);
            return RedirectToAction("Details", model.Item.Id);
        }

        private IAuthenticationManager AuthenticationManager {
            get {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
    }
}