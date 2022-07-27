using WebShop.Validation;
using WebShopCommon.Models.Base;

namespace WebShop.Models.Binding
{
    public class ProductBinding: ProductBase
    {
        [ProductCategoryIdValidation]
        public int ProductCategoryId { get; set; }
    }
}
