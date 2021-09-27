using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogiwaAPI.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }        
        public int ProductQuantity { get; set; }
        public int Active { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "Product title can only be 200 characters long")]
        public string ProductTitle { get; set; }
        public string ProductDesc { get; set; }
        public int CategoryId { get; set; }

        [NotMapped]
        public string CategoryName { get; set; }

        [NotMapped]
        public string ActiveString { get; set; }

    }
}
