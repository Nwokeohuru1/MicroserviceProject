using System.ComponentModel.DataAnnotations;

namespace CustomerApi.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; } 
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerAge { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool DelFlag  { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


    }
}
