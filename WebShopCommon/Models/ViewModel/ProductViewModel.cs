using WebShopCommon.Models.Base;

namespace WebShopCommon.Models.ViewModel
{
    public class ProductViewModel: ProductBase
    {
        public int Id { get; set; }
        public ProductCategoryViewModel ProductCategory { get; set; }
    }
}
