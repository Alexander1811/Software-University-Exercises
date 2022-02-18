namespace ProductShop.DTO.Import
{
    using System.Xml.Serialization;
    
    using Models;

    [XmlType(nameof(CategoryProduct))]
    public class ImportCategoryProductDto
    {
        [XmlElement("CategoryId")]
        public int CategoryId { get; set; }
        
        [XmlElement("ProductId")]
        public int ProductId { get; set; }
    }
}
