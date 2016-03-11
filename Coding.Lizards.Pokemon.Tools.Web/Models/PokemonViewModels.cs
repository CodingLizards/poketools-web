namespace Coding.Lizards.Pokemon.Tools.Web.Models {
    using Dapper;
    using System;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;

    public class AddPokemonViewModel : BaseAddViewModel<PokemonModel, int> {

        public override async Task<int> Save() {
            using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)) {
                var affectedRows = await sqlconnection.ExecuteAsync(@"INSERT INTO Pokemon (
	                NationalDexId,
	                GermanName,
	                EnglishName,
	                Frenchname,
	                Thumbnail,
	                Sprite,
	                FirstType,
	                SecondType,
	                BaseHP,
	                BaseAttack,
	                BaseDefense,
	                SpecialAttack,
	                SpecialDefense,
	                Speed,
	                BaseXp,
                    XpType
                ) VALUES (
	                @id,
	                @germanName,
	                @englishName,
	                @frenchName,
	                @thumbnail,
	                @sprite,
	                @firstType,
	                @secondType,
	                @baseHp,
	                @baseAttack,
	                @baseDefense,
	                @specialAttack,
	                @specialDefense,
	                @speed,
	                @baseXp,
                    @xpType
                )", new {
                    germanName = Item.GermanName,
                    englishName = Item.EnglishName,
                    frenchName = Item.FrenchName,
                    thumbnail = Item.Thumbnail,
                    sprite = Item.Sprite,
                    firstType = Item.FirstType,
                    secondType = Item.SecondType,
                    baseHp = Item.BaseHealth,
                    baseAttack = Item.BaseAttack,
                    baseDefense = Item.BaseDefense,
                    specialAttack = Item.BaseSpecialAttack,
                    specialDefense = Item.BaseSpecialDefense,
                    speed = Item.BaseSpeed,
                    baseXp = Item.BaseExperience,
                    xpType = Item.ExperienceType,
                    id = Item.Id
                });
                if (affectedRows < 1) {
                    throw new Exception("Pokémon not inserted");
                }
                return Item.Id;
            }
        }
    }

    public class EditPokemonViewModel : BaseEditViewModel<PokemonModel, int> {

        public override async Task LoadData(int id) {
            using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)) {
                var items = await sqlconnection.QueryAsync<PokemonModel>("SELECT [NationalDexId] AS Id, [GermanName], [EnglishName], [Frenchname], [Thumbnail], [Sprite], [FirstType], [SecondType], [XpType] AS ExperienceType, [BaseHP] AS BaseHealth, [BaseAttack], [BaseDefense], [SpecialAttack] AS BaseSpecialAttack, [SpecialDefense] AS BaseSpecialDefense, [Speed] AS BaseSpeed, [BaseXp] AS BaseExperience FROM [dbo].[Pokemon] WHERE NationalDexId = @id", new { id = id });
                this.Item = items.First();
            }
        }

        public override async Task<int> Save() {
            using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)) {
                await sqlconnection.ExecuteAsync(@"UPDATE Pokemon SET 
[GermanName] = @germanName,
[EnglishName] = @englishName,
[Frenchname] = @frenchName,
[FirstType] = @firstType,
[SecondType] = @secondType,
[BaseHP] = @baseHp,
[BaseAttack] = @baseAttack,
[BaseDefense] = @baseDefense,
[SpecialAttack] = @specialAttack,
[SpecialDefense]= @specialDefense,
[Speed] = @speed,
[BaseXp] = @baseXp,
[XpType] = @xpType
WHERE NationalDexId = @id", new {
                    germanName = Item.GermanName,
                    englishName = Item.EnglishName,
                    frenchName = Item.FrenchName,
                    firstType = Item.FirstType,
                    secondType = Item.SecondType,
                    baseHp = Item.BaseHealth,
                    baseAttack = Item.BaseAttack,
                    baseDefense = Item.BaseDefense,
                    specialAttack = Item.BaseSpecialAttack,
                    specialDefense = Item.BaseSpecialDefense,
                    speed = Item.BaseSpeed,
                    baseXp = Item.BaseExperience,
                    xpType = Item.ExperienceType,
                    id = Item.Id
                });
                if (Item.Thumbnail != null && Item.Thumbnail.Any()) {
                    await sqlconnection.ExecuteAsync(@"UPDATE Pokemon SET [Thumbnail] = @thumbnail", new { thumbnail = Item.Thumbnail });
                }
                if (Item.Sprite != null && Item.Sprite.Any()) {
                    await sqlconnection.ExecuteAsync(@"UPDATE Pokemon SET [Sprite] = @sprite", new { sprite = Item.Sprite });
                }
                return Item.Id;
            }
        }
    }

    public class DetailsPokemonViewModel : BaseDetailsViewModel<PokemonModel, int> {
        public override async Task LoadData(int id) {
            using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)) {
                var items = await sqlconnection.QueryAsync<PokemonModel>("SELECT [NationalDexId] AS Id, [GermanName], [EnglishName], [Frenchname], [Thumbnail], [Sprite], [FirstType], [SecondType], [XpType] AS ExperienceType, [BaseHP] AS BaseHealth, [BaseAttack], [BaseDefense], [SpecialAttack] AS BaseSpecialAttack, [SpecialDefense] AS BaseSpecialDefense, [Speed] AS BaseSpeed, [BaseXp] AS BaseExperience FROM [dbo].[Pokemon] WHERE NationalDexId = @id", new { id = id });
                this.Item = items.First();
            }
        }
    }

    public class DeletePokemonViewModel : BaseDeleteViewModel<PokemonModel, int> {
        public override async Task<bool> Delete() {
            try {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)) {
                    await sqlconnection.ExecuteAsync("DELETE FROM Pokemon WHERE NationalDexId = @id", new { id = Item.Id });
                }
                return true;
            } catch (Exception ex) {
                return false;
            }
        }

        public override async Task LoadData(int id) {
            using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)) {
                var items = await sqlconnection.QueryAsync<PokemonModel>("SELECT [NationalDexId] AS Id, [GermanName], [EnglishName], [Frenchname], [Thumbnail], [Sprite] FROM [dbo].[Pokemon] WHERE NationalDexId = @id", new { id = id });
                this.Item = items.First();
            }
        }
    }

    public class ListPokemonViewModel : BaseListViewModel<PokemonModel, int> {
        public override async Task LoadData() {
            using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)) {
                this.Items = await sqlconnection.QueryAsync<PokemonModel>("SELECT [NationalDexId] AS Id, [GermanName], [EnglishName], [Frenchname], [Thumbnail], [Sprite], [FirstType], [SecondType], [XpType] AS ExperienceType, [BaseHP] AS BaseHealth, [BaseAttack], [BaseDefense], [SpecialAttack] AS BaseSpecialAttack, [SpecialDefense] AS BaseSpecialDefense, [Speed] AS BaseSpeed, [BaseXp] AS BaseExperience FROM [dbo].[Pokemon]");
            }
        }
    }
}