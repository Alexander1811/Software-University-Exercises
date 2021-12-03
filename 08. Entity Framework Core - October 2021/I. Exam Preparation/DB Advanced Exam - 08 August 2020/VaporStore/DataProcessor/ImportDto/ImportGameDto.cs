namespace VaporStore.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using VaporStore.Common;

    public class ImportGameDto
    {
        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

        [Required]
        public string ReleaseDate { get; set; }

        [Required]
        public string Developer { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        [MinLength(ValidationConstants.GameTagsMinCount)]
        public string[] Tags { get; set; }
    }
}
