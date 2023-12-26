using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KDWEBAPI.Models
{
    [Table("Products")]
    public partial class KDProduct
    {
        [Key]
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public int? SupplierID { get; set; }
        public int? CategoryID { get; set; }
        public string? QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public int? UnitsInStock { get; set; }
        public int? UnitsOnOrder { get; set; }
        public int? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }

        [NotMapped]
        public string? CategoryName { get; set; }
    }
}
