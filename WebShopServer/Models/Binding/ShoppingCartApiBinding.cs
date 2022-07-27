using WebShopCommon.Models.Base;

namespace WebShop.Models.Binding
{
    public class ShoppingCartApiBinding : ShoppingCartBase
    {
        //Validirati ProductId 
        public int ProductId { get; set; }
        //Validirati Quantity > 0
        public decimal Quantity { get; set; }
        //Validirati Price > 0
        public decimal Price { get; set; }
        //Validirati ShoppingCartId
        public int? ShoppingCartId { get; set; }
    }
}
