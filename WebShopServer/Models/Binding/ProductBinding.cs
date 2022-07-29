using System.ComponentModel.DataAnnotations;
using WebShop.Validation;
using WebShopCommon.Models.Base;

namespace WebShop.Models.Binding
{
    public class ProductBinding: ProductBase
    {
        [ProductCategoryIdValidation]
        public int ProductCategoryId { get; set; }
        [Display (Name = "Slika proizvoda")]
        public IFormFile ProductImg { get; set; }
    }
}
