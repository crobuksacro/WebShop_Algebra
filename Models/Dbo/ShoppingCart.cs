using WebShop.Models.Base;
using WebShop.Models.Dbo.Base;

namespace WebShop.Models.Dbo
{
    public class ShoppingCart: ShoppingCartBase, IEntityBase
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public ShoppingCartStatus ShoppingCartStatus { get; set; }
    }
}
