using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCSHOP.Models
{
    [Table("Users")]
    public class Users
    {
        [Key]
        public int ID { get; set; }
        public string? FullName { get; set; }
        public string? Avatar { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public bool? IsActive { get; set; }
    }
}
