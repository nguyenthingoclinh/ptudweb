using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCSHOP.Models
{
    [Table("view_Product_Menu")]
    public class view_Product_Menu
    {
        [Key]
        public int ID { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public int MenuID { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public int Sold { get; set; }
        public int Likes { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int Status { get; set; }
        public decimal PriceSale { get; set; }
        public bool? IsActive { get; set; }
        public string? MenuName { get; set; }
    }
}
