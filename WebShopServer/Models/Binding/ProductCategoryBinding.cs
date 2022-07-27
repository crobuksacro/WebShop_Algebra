using WebShopCommon.Models.Base;

namespace WebShop.Models.Binding
{
    public class ProductCategoryBinding: ProductCategoryBase
    {
    }

    public class ProductCategoryUpdateBinding : ProductCategoryBinding
    {
        //Validirati Id
        public int Id { get; set; }
    }
}
