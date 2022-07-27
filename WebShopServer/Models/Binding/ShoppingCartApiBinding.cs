using WebShop.Validation;
using WebShopCommon.Models.Base;

namespace WebShop.Models.Binding
{
    public class ShoppingCartApiBinding : ShoppingCartBase
    {
        [ProductIdValidation]
        public int ProductId { get; set; }
        //Validirati Quantity > 0
        public decimal Quantity { get; set; }
        //Validirati Price > 0
        public decimal Price { get; set; }
        [ShoppingCartIdValidation]
        public int? ShoppingCartId { get; set; }
    }
}
