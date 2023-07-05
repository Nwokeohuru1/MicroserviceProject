namespace ProductApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool DelFlag { get; set; }
        public int? Quantity { get; set; }
        public int? Price { get; set; }
    }
}
