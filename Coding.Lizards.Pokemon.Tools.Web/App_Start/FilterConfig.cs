using System.Web;
using System.Web.Mvc;

namespace Coding.Lizards.Pokemon.Tools.Web {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
