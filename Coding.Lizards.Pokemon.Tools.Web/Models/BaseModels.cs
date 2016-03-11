namespace Coding.Lizards.Pokemon.Tools.Web.Models {

    public abstract class BaseModel<TId> {
        public TId Id { get; set; }
    }
}