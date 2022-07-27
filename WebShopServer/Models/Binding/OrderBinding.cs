using WebShop.Validation;

namespace WebShop.Models.Binding
{
    public class OrderBinding
    {
        [ShoppingCartIdValidation]
        public int ShoppingCartId { get; set; }
    }
}
