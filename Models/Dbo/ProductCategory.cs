using WebShop.Models.Base;
using WebShop.Models.Dbo.Base;

namespace WebShop.Models.Dbo
{
    public class ProductCategory: ProductCategoryBase, IEntityBase
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
    }
}
