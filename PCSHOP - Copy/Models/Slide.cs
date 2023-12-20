using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCSHOP.Models
{
    [Table("Slide")]
    public class Slide
    {
        [Key]
        public long ID { get; set; }
        public string? Title { get; set; }
        public string? Abstract { get; set; }
        public string? Images { get; set; }
        public string? Link { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool? IsActive { get; set; }
        public int SlideOrder { get; set; }
        public int Category { get; set; }
        public int Status { get; set; }
    }
}
