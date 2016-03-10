namespace Coding.Lizards.Pokemon.Tools.Web.Controllers {

    using Models;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    public abstract class BaseController<TModel, TModelId, TListViewModel, TAddViewModel, TEditViewModel, TDetailsViewModel, TDeleteViewModel> : Controller
        where TModel : BaseModel<TModelId>, new()
        where TListViewModel : BaseListViewModel<TModel, TModelId>, new()
        where TAddViewModel : BaseAddViewModel<TModel, TModelId>, new()
        where TEditViewModel : BaseEditViewModel<TModel, TModelId>, new()
        where TDetailsViewModel : BaseDetailsViewModel<TModel, TModelId>, new()
        where TDeleteViewModel : BaseDeleteViewModel<TModel, TModelId>, new() {

        public virtual async Task<ActionResult> Index() {
            var vm = new TListViewModel();
            await vm.LoadData();
            return View(vm);
        }

        public virtual async Task<ActionResult> Add() {
            return View();
        }

        [HttpPost]
        public virtual async Task<ActionResult> Add(TAddViewModel model) {
            var id = await model.Save();
            return RedirectToAction("Details", ControllerContext.Controller.GetType().Name, new { id = id });
        }

        public virtual async Task<ActionResult> Edit(TModelId id) {
            var vm = new TEditViewModel();
            await vm.LoadData(id);
            return View(vm);
        }

        [HttpPost]
        public virtual async Task<ActionResult> Edit(TEditViewModel model) {
            var id = await model.Save();
            return RedirectToAction("Details", ControllerContext.Controller.GetType().Name, new { id = id });
        }

        public virtual async Task<ActionResult> Details(TModelId id) {
            var vm = new TDetailsViewModel();
            await vm.LoadData(id);
            return View(vm);
        }

        public virtual async Task<ActionResult> Delete(TModelId id) {
            var vm = new TDeleteViewModel();
            await vm.LoadData(id);
            return View(vm);
        }

        [HttpPost]
        public virtual async Task<ActionResult> Delete(TDeleteViewModel model) {
            await model.Delete();
            return RedirectToAction("Index", ControllerContext.Controller.GetType().Name);
        }
    }
}