namespace CarDealer.DTO.Import
{
    using System.Xml.Serialization;

    using Models;

    [XmlType(nameof(Supplier))]
    public class ImportSupplierDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("isImporter")]
        public string IsImporter { get; set; }
    }
}
