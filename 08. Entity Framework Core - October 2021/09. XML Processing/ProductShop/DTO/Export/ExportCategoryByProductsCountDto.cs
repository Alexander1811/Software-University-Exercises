namespace ProductShop.DTO.Export
{
    using System.Xml.Serialization;

    using Models;

    [XmlType(nameof(Category))]
    public class ExportCategoryByProductsCountDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("count")]
        public int Count { get; set; }

        [XmlElement("averagePrice")]
        public decimal AveragePrice { get; set; }

        [XmlElement("totalRevenue")]
        public decimal TotalRevenue { get; set; }
    }
}
