using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KDWEBAPI.Models
{
    [Table("Swiper")]
    public partial class KDSwiper
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? ImagePath { get; set; }
        public string? Content { get; set; }
    }
}
