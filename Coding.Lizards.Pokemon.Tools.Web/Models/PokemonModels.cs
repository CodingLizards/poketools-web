namespace Coding.Lizards.Pokemon.Tools.Web.Models {

    using Strings;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Threading;

    [Serializable]
    public class PokemonModel : BaseModel<int> {

        [Display(ResourceType = typeof(Texts), Name = "Pokemon_List_GermanName")]
        public string GermanName { get; set; }

        [Display(ResourceType = typeof(Texts), Name = "Pokemon_List_EnglishName")]
        public string EnglishName { get; set; }

        [Display(ResourceType = typeof(Texts), Name = "Pokemon_List_FrenchName")]
        public string FrenchName { get; set; }

        [Display(ResourceType = typeof(Texts), Name = "Pokemon_List_FirstType")]
        public Type FirstType { get; set; }

        [Display(ResourceType = typeof(Texts), Name = "Pokemon_List_SecondType")]
        public Type? SecondType { get; set; }

        [Display(ResourceType = typeof(Texts), Name = "Pokemon_List_BaseHealth")]
        public int BaseHealth { get; set; }

        [Display(ResourceType = typeof(Texts), Name = "Pokemon_List_BaseAttack")]
        public int BaseAttack { get; set; }

        [Display(ResourceType = typeof(Texts), Name = "Pokemon_List_BaseDefense")]
        public int BaseDefense { get; set; }

        [Display(ResourceType = typeof(Texts), Name = "Pokemon_List_BaseSpecialAttack")]
        public int BaseSpecialAttack { get; set; }

        [Display(ResourceType = typeof(Texts), Name = "Pokemon_List_BaseSpecialDefense")]
        public int BaseSpecialDefense { get; set; }

        [Display(ResourceType = typeof(Texts), Name = "Pokemon_List_BaseSpeed")]
        public int BaseSpeed { get; set; }

        [Display(ResourceType = typeof(Texts), Name = "Pokemon_List_BaseExperience")]
        public int BaseExperience { get; set; }

        [Display(ResourceType = typeof(Texts), Name = "Pokemon_List_Thumbnail")]
        public byte[] Thumbnail { get; set; }

        [Display(ResourceType = typeof(Texts), Name = "Pokemon_List_Sprite")]
        public byte[] Sprite { get; set; }

        [Display(ResourceType = typeof(Texts), Name = "Pokemon_List_ExperienceType")]
        public ExperienceType ExperienceType { get; set; }

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