namespace Coding.Lizards.Pokemon.Tools.Web.Models {

    using Dapper;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;

    public class AddUserViewModel : BaseAddViewModel<UserModel, string> {

        public override async Task<string> Save() {
            return string.Empty;
        }
    }

    public class DeleteUserViewModel : BaseDeleteViewModel<UserModel, string> {

        public override async Task<bool> Delete() {
            return default(bool);
        }

        public override async Task LoadData(string id) {
            using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)) {
                var items = await sqlconnection.QueryAsync<UserModel>("SELECT Id, Email, UserName FROM AspNetUsers WHERE Id=@id", new { id = id });
                this.Item = items.SingleOrDefault();
            }
        }
    }

    public class DetailsUserViewModel : BaseDetailsViewModel<UserModel, string> {

        public override async Task LoadData(string id) {
            using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)) {
                var items = await sqlconnection.QueryAsync<UserModel>("SELECT Id, Email, UserName FROM AspNetUsers WHERE Id=@id", new { id = id });
                this.Item = items.SingleOrDefault();
            }
        }
    }

    public class EditUserViewModel : BaseEditViewModel<UserModel, string> {

        public override async Task LoadData(string id) {
            using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)) {
                var items = await sqlconnection.QueryAsync<UserModel>("SELECT Id, Email, UserName FROM AspNetUsers WHERE Id=@id", new { id = id });
                this.Item = items.SingleOrDefault();
            }
        }

        public override async Task<string> Save() {
            return string.Empty;
        }
    }

    public class ListUserViewModel : BaseListViewModel<UserModel, string> {

        public override async Task LoadData() {
            using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)) {
                this.Items = await sqlconnection.QueryAsync<UserModel>("SELECT Id, Email, UserName FROM AspNetUsers");
            }
        }
    }
}