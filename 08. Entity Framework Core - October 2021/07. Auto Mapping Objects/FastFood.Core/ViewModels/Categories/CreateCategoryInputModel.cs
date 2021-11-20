namespace FastFood.Core.ViewModels.Categories
{
    using System.ComponentModel.DataAnnotations;

    public class CreateCategoryInputModel
    {
        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Category name must be between 3 and 30 characters.")] 
        public string CategoryName { get; set; }
    }
}
