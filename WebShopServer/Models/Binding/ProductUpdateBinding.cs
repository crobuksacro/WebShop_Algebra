using WebShopCommon.Models.Base;
using WebShopCommon.Models.ViewModel;

namespace WebShop.Models.Binding
{
    public class ProductUpdateBinding : ProductBase
    {
        //Validirati ProductCategoryId
        public int Id { get; set; }
        public ProductCategoryViewModel ProductCategory { get; set; }
        //Validirati ProductCategoryId
        public int ProductCategoryId { get; set; }
    }
}
