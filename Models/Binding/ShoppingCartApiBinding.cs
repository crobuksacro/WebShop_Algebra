using WebShop.Models.Base;

namespace WebShop.Models.Binding
{
    public class ShoppingCartApiBinding : ShoppingCartBase
    {
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public int? ShoppingCartId { get; set; }
    }
}
