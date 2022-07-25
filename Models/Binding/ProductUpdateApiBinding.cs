using WebShop.Models.Base;

namespace WebShop.Models.Binding
{
    public class ProductUpdateApiBinding:ProductBase
    {
        public int Id { get; set; }
        public int ProductCategoryId { get; set; }
    }
}
