using System.ComponentModel.DataAnnotations;

namespace LogiwaWeb.Models
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }

        [Display(Name = "Minimum Stock Quantity")]
        [Required(ErrorMessage = "Every category must have a stock quantity")]
        public int CategoryQuantity { get; set; }

        [Display(Name = "Category Title")]
        [Required(ErrorMessage = "Every category must have a title")]
        public string CategoryTitle { get; set; }
    }
}