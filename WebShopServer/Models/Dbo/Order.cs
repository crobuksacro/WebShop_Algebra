using WebShop.Models.Dbo.Base;
using WebShopCommon.Models.Base;

namespace WebShop.Models.Dbo
{
    public class Order : OrderBase, IEntityBase
    {
        public ShoppingCart ShoppingCart { get; set; }
        public int Id { get; set; }
        public DateTime Created { get; set; }
    }
}
