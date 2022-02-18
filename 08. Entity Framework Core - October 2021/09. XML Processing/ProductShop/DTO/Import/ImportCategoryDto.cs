namespace ProductShop.DTO.Import
{
    using System.Xml.Serialization;
    
    using Models;

    [XmlType(nameof(Category))]
    public class ImportCategoryDto
    {
        [XmlElement("name")]
        public string Name { get; set; }
    }
}
