namespace Coding.Lizards.Pokemon.Tools.Web.Models {

    using Coding.Lizards.Pokemon.Tools.Web.Strings;
    using System.ComponentModel.DataAnnotations;
    using System.Threading;

    public class AttackModel : BaseModel<int> {

        [Display(ResourceType = typeof(Texts), Name = "Attack_List_GermanName")]
        public string GermanName { get; set; }

        [Display(ResourceType = typeof(Texts), Name = "Attack_List_EnglishName")]
        public string EnglishName { get; set; }

        [Display(ResourceType = typeof(Texts), Name = "Attack_List_FrenchName")]
        public string FrenchName { get; set; }

        [Display(ResourceType = typeof(Texts), Name = "Attack_List_Type")]
        public Type Type { get; set; }

        [Display(ResourceType = typeof(Texts), Name = "Attack_List_Strength")]
        public int Strength { get; set; }

        [Display(ResourceType = typeof(Texts), Name = "Attack_List_Accuracy")]
        public int Accuracy { get; set; }

        public string GetLocalizedName() {
            var uiculture = Thread.CurrentThread.CurrentUICulture;
            switch (uiculture.TwoLetterISOLanguageName.ToLower()) {
                case "de":
                    return GermanName;

                case "fr":
                    return FrenchName;

                default:
                    return EnglishName;
            }
        }
    }
}