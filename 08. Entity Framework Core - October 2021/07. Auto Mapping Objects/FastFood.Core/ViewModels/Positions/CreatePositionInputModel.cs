namespace FastFood.Core.ViewModels.Positions
{
    using System.ComponentModel.DataAnnotations;

    public class CreatePositionInputModel
    {

        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Position name must be between 3 and 30 characters.")]
        public string PositionName { get; set; }
    }
}
