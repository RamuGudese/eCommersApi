using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecomApi.Controllers.Models
{
    [Table("productTbl")]

    public class productModel

    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int productId { get; set; }
        public int catId { get; set; }
        [MaxLength(50)]
        public string productName { get; set; } = string.Empty;
        [MaxLength(10)]
        public string shotName { get; set; } = string.Empty;
        public float price { get; set; }
        [MaxLength(1000)]
        public string description { get; set; } = string.Empty;
        public Nullable<DateTime> CreateDate { get; set; } = DateTime.Now;
        public Nullable<DateTime> modifiedDate { get; set; } = DateTime.Now;





    }
}