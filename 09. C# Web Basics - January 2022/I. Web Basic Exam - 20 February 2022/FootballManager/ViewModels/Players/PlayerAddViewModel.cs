namespace FootballManager.ViewModels.Players
{
    using System.ComponentModel.DataAnnotations;
    using Validations = FootballManager.Common.ValidationConstants;

    public class PlayerAddViewModel
    {
        [Required]
        [StringLength(Validations.PlayerFullNameMaxLength)]
        public string FullName { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(Validations.PlayerPositionMaxLength)]
        public string Position { get; set; }

        [Range(Validations.PlayerSpeedMinValue, Validations.PlayerSpeedMaxValue)]
        public int Speed { get; set; }

        [Range(Validations.PlayerEnduranceMinValue, Validations.PlayerEnduranceMaxValue)]
        public int Endurance { get; set; }

        [Required]
        [StringLength(Validations.PlayerDescriptionMaxLength)]
        public string Description { get; set; }
    }
}
