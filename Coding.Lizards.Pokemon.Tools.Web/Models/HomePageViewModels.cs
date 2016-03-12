namespace Coding.Lizards.Pokemon.Tools.Web.Models {

    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class HomePageViewModel {
        public IEnumerable<PokemonModel> Pokemon { get; set; }
        public IEnumerable<AttackModel> Attacks { get; set; }

        public async Task LoadData() {
            var pokevm = new ListPokemonViewModel();
            var attackvm = new ListAttackViewModel();
            await pokevm.LoadData();
            await attackvm.LoadData();

            this.Pokemon = pokevm.Items;
            this.Attacks = attackvm.Items;
        }
    }
}