using WebShop.Validation;
using WebShopCommon.Models.Base;

namespace WebShop.Models.Binding
{
    public class ShoppingCartApiBinding : ShoppingCartBase
    {
        [ProductIdValidation]
        public int ProductId { get; set; }
        [DecimalValueGreaterThanZero]
        public decimal Quantity { get; set; }
        [DecimalValueGreaterThanZero]
        public decimal Price { get; set; }
        [ShoppingCartIdValidation]
        public int? ShoppingCartId { get; set; }
    }
}
