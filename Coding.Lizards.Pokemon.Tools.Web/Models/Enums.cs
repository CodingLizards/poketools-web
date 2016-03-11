namespace Coding.Lizards.Pokemon.Tools.Web.Models {

    using Strings;
    using System.ComponentModel.DataAnnotations;

    public enum ExperienceType {

        [Display(ResourceType = typeof(Texts), Name = "Enums_XpType_Fast")]
        Fast = 0,

        [Display(ResourceType = typeof(Texts), Name = "Enums_XpType_MediumFast")]
        MediumFast = 1,

        [Display(ResourceType = typeof(Texts), Name = "Enums_XpType_MediumSlow")]
        MediumSlow,

        [Display(ResourceType = typeof(Texts), Name = "Enums_XpType_Slow")]
        Slow,

        [Display(ResourceType = typeof(Texts), Name = "Enums_XpType_Erratic")]
        Erratic,

        [Display(ResourceType = typeof(Texts), Name = "Enums_XpType_Fluctuating")]
        Fluctuating
    }

    public enum Type {

        [Display(ResourceType = typeof(Texts), Name = "Enums_Type_Normal")]
        Normal = 0,

        [Display(ResourceType = typeof(Texts), Name = "Enums_Type_Fighting")]
        Fighting = 1,

        [Display(ResourceType = typeof(Texts), Name = "Enums_Type_Flying")]
        Flying,

        [Display(ResourceType = typeof(Texts), Name = "Enums_Type_Poison")]
        Poison,

        [Display(ResourceType = typeof(Texts), Name = "Enums_Type_Ground")]
        Ground,

        [Display(ResourceType = typeof(Texts), Name = "Enums_Type_Rock")]
        Rock,

        [Display(ResourceType = typeof(Texts), Name = "Enums_Type_Bug")]
        Bug,

        [Display(ResourceType = typeof(Texts), Name = "Enums_Type_Ghost")]
        Ghost,

        [Display(ResourceType = typeof(Texts), Name = "Enums_Type_Steel")]
        Steel,

        [Display(ResourceType = typeof(Texts), Name = "Enums_Type_Fire")]
        Fire,

        [Display(ResourceType = typeof(Texts), Name = "Enums_Type_Water")]
        Water,

        [Display(ResourceType = typeof(Texts), Name = "Enums_Type_Grass")]
        Grass,

        [Display(ResourceType = typeof(Texts), Name = "Enums_Type_Electric")]
        Electric,

        [Display(ResourceType = typeof(Texts), Name = "Enums_Type_Psychic")]
        Psychic,

        [Display(ResourceType = typeof(Texts), Name = "Enums_Type_Ice")]
        Ice,

        [Display(ResourceType = typeof(Texts), Name = "Enums_Type_Dragon")]
        Dragon,

        [Display(ResourceType = typeof(Texts), Name = "Enums_Type_Dark")]
        Dark,

        [Display(ResourceType = typeof(Texts), Name = "Enums_Type_Fairy")]
        Fairy
    }
}