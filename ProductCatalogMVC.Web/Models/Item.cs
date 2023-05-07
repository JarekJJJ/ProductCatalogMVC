namespace ProductCatalogMVC.Web.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Category { get; set; }
        public decimal Prize { get; set; }
        public int Quantity { get; set; }
    }
}
