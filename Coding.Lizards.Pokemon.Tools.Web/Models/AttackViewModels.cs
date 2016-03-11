namespace Coding.Lizards.Pokemon.Tools.Web.Models {

	using Dapper;
	using System;
	using System.Configuration;
	using System.Data.SqlClient;
	using System.Linq;
	using System.Threading.Tasks;

	public class AddAttackViewModel : BaseAddViewModel<AttackModel, int> {

		public override async Task<int> Save() {
			using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)) {
				var affectedRows = await sqlconnection.ExecuteAsync(@"INSERT INTO Attack (
					Id,
					GermanName,
					EnglishName,
					FrenchName,
					Type,
					Strength,
					Accuracy
				) VALUES (
					@id,
					@germanName,
					@englishName,
					@frenchName,
					@type,
					@strength,
					@accuracy
				)", new {
					germanName = Item.GermanName,
					englishName = Item.EnglishName,
					frenchName = Item.FrenchName,
					type = Item.Type,
					strength = Item.Strength,
					accuracy = Item.Accuracy,
					id = Item.Id
				});
				if (affectedRows < 1) {
					throw new Exception("Attack not inserted");
				}
				return Item.Id;
			}
		}
	}

	public class EditAttackViewModel : BaseEditViewModel<AttackModel, int> {

		public override async Task LoadData(int id) {
			using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)) {
				var items = await sqlconnection.QueryAsync<AttackModel>("SELECT [Name], [DamageClass], [Type], [AttackPoints], [Priority], [Accuracy], [DirectHitChance] FROM [dbo].[Attack] WHERE NationalDexId = @id", new { id = id });
				this.Item = items.First();
			}
		}

		public override async Task<int> Save() {
			using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)) {
				await sqlconnection.ExecuteAsync(@"UPDATE Attack SET
[GermanName] = @germanName,
[EnglishName] = @englishName,
[Frenchname] = @frenchName,
[Type] = @type,
[Strength] = @strength,
[Accuracy] = @accuracy
WHERE NationalDexId = @id", new {
					germanName = Item.GermanName,
					englishName = Item.EnglishName,
					frenchName = Item.FrenchName,
					type = Item.Type,
					strength = Item.Strength,
					accuracy = Item.Accuracy,
					id = Item.Id
				});
				return Item.Id;
			}
		}
	}

	public class DetailsAttackViewModel : BaseDetailsViewModel<AttackModel, int> {

		public override async Task LoadData(int id) {
			using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)) {
				var items = await sqlconnection.QueryAsync<AttackModel>("SELECT [Id], [EnglishName], [GermanName], [FrenchName], [DamageClass], [Type], [Accuracy], [Strength] FROM [dbo].[Attack] WHERE Id = @id", new { id = id });
				this.Item = items.First();
			}
		}
	}

	public class DeleteAttackViewModel : BaseDeleteViewModel<AttackModel, int> {

		public override async Task<bool> Delete() {
			try {
				using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)) {
					await sqlconnection.ExecuteAsync("DELETE FROM Attack WHERE Id = @id", new { id = Item.Id });
				}
				return true;
			} catch (Exception ex) {
				return false;
			}
		}

		public override async Task LoadData(int id) {
			using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)) {
				var items = await sqlconnection.QueryAsync<AttackModel>("SELECT [Id], [EnglishName], [GermanName], [FrenchName], [DamageClass], [Type], [Accuracy], [Strength] FROM [dbo].[Attack] WHERE Id = @id", new { id = id });
				this.Item = items.First();
			}
		}
	}

	public class ListAttackViewModel : BaseListViewModel<AttackModel, int> {

		public override async Task LoadData() {
			using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)) {
				this.Items = await sqlconnection.QueryAsync<AttackModel>("SELECT [Id], [EnglishName], [GermanName], [FrenchName], [DamageClass], [Type], [Accuracy], [Strength] FROM [dbo].[Attack]");
			}
		}
	}
}