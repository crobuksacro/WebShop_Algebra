using WebShopCommon.Models.Base;

namespace WebShopCommon.Models.ViewModel
{
    public class ShoppingCartItemViewModel: ShoppingCartItemBase
    {
        public int Id { get; set; }
        public ProductViewModel Product { get; set; }
    }
}
