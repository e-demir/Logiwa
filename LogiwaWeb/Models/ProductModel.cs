using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace LogiwaWeb.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }

        [Display(Name = "Stock Quantity")]
        public int ProductQuantity { get; set; }


        [Display(Name = "Is Active?")]
        public int Active { get; set; }
        public string ActiveString { get; set; }
        public List<SelectListItem> ActiveOrNot { get; set; }

        [Required(ErrorMessage = "Every product must have a title")]
        [StringLength(200, ErrorMessage = "Maximum character limit is 200")]
        [Display(Name ="Title")]
        public string ProductTitle { get; set; }

        [Display(Name = "Description")]
        public string ProductDesc { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "Every product must have a category Id")]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<CategoryModel> Categories { get; set; }
    }
}