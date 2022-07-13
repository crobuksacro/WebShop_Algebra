using WebShop.Models.Base;

namespace WebShop.Models.ViewModel
{
    public class ShoppingCartItemViewModel: ShoppingCartItemBase
    {
        public ProductViewModel Product { get; set; }
    }
}
