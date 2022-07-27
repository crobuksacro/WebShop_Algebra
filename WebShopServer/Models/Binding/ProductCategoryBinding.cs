using WebShop.Validation;
using WebShopCommon.Models.Base;

namespace WebShop.Models.Binding
{
    public class ProductCategoryBinding: ProductCategoryBase
    {
    }

    public class ProductCategoryUpdateBinding : ProductCategoryBinding
    {
        [ProductCategoryIdValidation]
        public int Id { get; set; }
    }
}
