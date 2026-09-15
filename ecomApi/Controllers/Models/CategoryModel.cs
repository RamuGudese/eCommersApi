using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecomApi.Controllers.Models
{
    [Table("categoryTbl")] 

    public class CategoryModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        [MaxLength(100)]
        [Required]
        public string CategoryName { get; set; } = string.Empty;
        [MaxLength(200)]
        [Required]
        public string CategoryLogo { get; set; } = string.Empty;
       
    }
}
