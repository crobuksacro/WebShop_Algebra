using WebShop.Validation;
using WebShopCommon.Models.Base;

namespace WebShop.Models.Binding
{
    public class ProductUpdateApiBinding:ProductBase
    {
        [ProductIdValidation]
        public int Id { get; set; }
        [ProductCategoryIdValidation]
        public int ProductCategoryId { get; set; }
    }
}
