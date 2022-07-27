using WebShop.Validation;
using WebShopCommon.Models.Base;
using WebShopCommon.Models.ViewModel;

namespace WebShop.Models.Binding
{
    public class ProductUpdateBinding : ProductBase
    {
        [ProductIdValidation]
        public int Id { get; set; }
        public ProductCategoryViewModel ProductCategory { get; set; }
        [ProductCategoryIdValidation]
        public int ProductCategoryId { get; set; }
    }
}
