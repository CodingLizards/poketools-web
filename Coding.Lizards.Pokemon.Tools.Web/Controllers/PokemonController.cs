namespace Coding.Lizards.Pokemon.Tools.Web.Controllers {

    using Dapper;
    using Models;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    public class PokemonController : BaseController<PokemonModel, int, ListPokemonViewModel, AddPokemonViewModel, EditPokemonViewModel, DetailsPokemonViewModel, DeletePokemonViewModel> {

        public async Task<ActionResult> GetThumbnail(int id) {
            using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)) {
                var data = await sqlconnection.ExecuteScalarAsync<byte[]>("SELECT Thumbnail FROM Pokemon WHERE NationalDexId = @id", new { id = id });
                return File(data, "image/gif");
            }
        }

        public async Task<ActionResult> GetSprite(int id) {
            using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)) {
                var data = await sqlconnection.ExecuteScalarAsync<byte[]>("SELECT Sprite FROM Pokemon WHERE NationalDexId = @id", new { id = id });
                return File(data, "image/gif");
            }
        }

        public override async Task<ActionResult> Add(AddPokemonViewModel model) {
            var thumbnail = Image.FromStream(Request.Files["Thumbnail"].InputStream);
            using (var ms = new MemoryStream()) {
                thumbnail.Save(ms, ImageFormat.Gif);
                ms.Position = 0;
                model.Item.Thumbnail = ms.ToArray();
            }

            var sprite = Image.FromStream(Request.Files["Sprite"].InputStream);
            using (var ms = new MemoryStream()) {
                sprite.Save(ms, ImageFormat.Gif);
                ms.Position = 0;
                model.Item.Sprite = ms.ToArray();
            }

            return await base.Add(model);
        }

        public override async Task<ActionResult> Edit(EditPokemonViewModel model) {
            if (Request.Files.Get("Thumbnail").ContentLength > 0) {
                var thumbnail = Image.FromStream(Request.Files["Thumbnail"].InputStream);
                using (var ms = new MemoryStream()) {
                    thumbnail.Save(ms, ImageFormat.Gif);
                    ms.Position = 0;
                    model.Item.Thumbnail = ms.ToArray();
                }
            }

            if (Request.Files.Get("Sprite").ContentLength > 0) {
                var sprite = Image.FromStream(Request.Files["Sprite"].InputStream);
                using (var ms = new MemoryStream()) {
                    sprite.Save(ms, ImageFormat.Gif);
                    ms.Position = 0;
                    model.Item.Sprite = ms.ToArray();
                }
            }

            return await base.Edit(model);
        }
    }
}