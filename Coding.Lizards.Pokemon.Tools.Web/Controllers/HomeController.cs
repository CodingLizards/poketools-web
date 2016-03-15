namespace Coding.Lizards.Pokemon.Tools.Web.Controllers {

    using Models;
    using Dapper;
    using System.Configuration;
    using System.Data.SqlClient;
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
            return Json(attack.Item, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Pokemon(int id) {
            var pokemon = new DetailsPokemonViewModel();
            await pokemon.LoadData(id);
            return Json(pokemon.Item, JsonRequestBehavior.AllowGet);
        }

        public async Task<float> Effect(int usedattack, int defendingpokemon) {
            var attack = new DetailsAttackViewModel();
            await attack.LoadData(usedattack);

            var pokemon = new DetailsPokemonViewModel();
            await pokemon.LoadData(defendingpokemon);

            using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)) {
                var effect = await sqlconnection.ExecuteScalarAsync<float>("SELECT Effect FROM TypeEffect WHERE AttackingType = @attack AND DefendingType = @defending", new { attack = attack.Item.Type, defending = pokemon.Item.FirstType });
                if (pokemon.Item.SecondType.HasValue) {
                    effect *= await sqlconnection.ExecuteScalarAsync<float>("SELECT Effect FROM TypeEffect WHERE AttackingType = @attack AND DefendingType = @defending", new { attack = attack.Item.Type, defending = pokemon.Item.SecondType });
                }
                return effect;
            }
        }
    }
}