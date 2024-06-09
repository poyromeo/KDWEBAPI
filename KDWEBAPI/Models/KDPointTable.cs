using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KDWEBAPI.Models
{
    [Table("PointTable")]
    public partial class KDPointTable
    {
        [Key]
        public int Id { get; set; }
        public string? Logo { get; set; }
        public string? Name { get; set; }
        public int? P { get; set; }
        public int? W { get; set; }
        public int? D { get; set; }
        public int? L { get; set; }
        public int? GD { get; set; }
        public int? Point { get; set; }
    }
}
