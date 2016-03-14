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

        public async Task<ActionResult> Attack(int id) {
            var attack = new DetailsAttackViewModel();
            await attack.LoadData(id);
            return Json(attack.Item);
        }

        public async Task<ActionResult> Pokemon(int id) {
            var pokemon = new DetailsPokemonViewModel();
            await pokemon.LoadData(id);
            return Json(pokemon.Item);
        }
    }
}