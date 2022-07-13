using WebShop.Models.Base;

namespace WebShop.Models.ViewModel
{
    public class ProductViewModel: ProductBase
    {
        public int Id { get; set; }
        public ProductCategoryViewModel ProductCategory { get; set; }
    }
}
