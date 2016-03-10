namespace Coding.Lizards.Pokemon.Tools.Web.Models {

    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public abstract class BaseAddViewModel<TModel, TId> where TModel : BaseModel<TId> {
        public TModel Item { get; set; }

        public abstract Task<TId> Save();
    }

    public abstract class BaseDeleteViewModel<TModel, TId> where TModel : BaseModel<TId> {
        public TModel Item { get; set; }

        public abstract Task<bool> Delete();

        public abstract Task LoadData(TId id);
    }

    public abstract class BaseDetailsViewModel<TModel, TId> where TModel : BaseModel<TId> {
        public TModel Item { get; set; }

        public abstract Task LoadData(TId id);
    }

    public abstract class BaseEditViewModel<TModel, TId> where TModel : BaseModel<TId> {
        public TModel Item { get; set; }

        public abstract Task LoadData(TId id);

        public abstract Task<TId> Save();
    }

    public abstract class BaseListViewModel<TModel, TId> : IEnumerable<TModel> where TModel : BaseModel<TId> {
        public IEnumerable<TModel> Items { get; set; }

        public TModel this[int index] {
            get {
                return Items.ElementAt(index);
            }
        }

        public IEnumerator<TModel> GetEnumerator() {
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return Items.GetEnumerator();
        }

        public abstract Task LoadData();
    }
}