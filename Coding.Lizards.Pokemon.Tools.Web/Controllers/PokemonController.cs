namespace Coding.Lizards.Pokemon.Tools.Web.Controllers {

    using System.Web.Mvc;

    public class PokemonController : Controller {

        // GET: Pokemon
        public ActionResult Index() {
            return View();
        }

        public ActionResult Attacks() {
            return View();
        }
    }
}