using WebShop.Models.Base;

namespace WebShop.Models.ViewModel
{
    public class ShoppingCartItemViewModel: ShoppingCartItemBase
    {
        public int Id { get; set; }
        public ProductViewModel Product { get; set; }
    }
}
