namespace Coding.Lizards.Pokemon.Tools.Web.Controllers {

    using Coding.Lizards.Pokemon.Tools.Web.Models;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    public class HomeController : Controller {

        public async Task<ActionResult> Index() {
            var vm = new HomePageViewModel();
            await vm.LoadData();
            return View(vm);
        }
    }
}