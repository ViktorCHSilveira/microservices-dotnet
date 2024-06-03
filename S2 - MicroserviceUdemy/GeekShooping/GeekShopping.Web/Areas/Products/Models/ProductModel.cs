using System.ComponentModel.DataAnnotations;

namespace GeekShopping.web.Areas.Product.Models
{
    public class ProductModel
    {

        public long? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string CategoryName { get; set; }

        [Required]
        public string ImageUrl { get; set; }

    }
}
