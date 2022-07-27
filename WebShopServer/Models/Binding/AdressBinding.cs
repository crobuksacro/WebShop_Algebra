using WebShop.Validation;
using WebShopCommon.Models.Base;

namespace WebShop.Models.Binding
{
    public class AdressBinding: AdressBase
    {
        [UserIdValidation]
        public string UserId { get; set; }
    }
}
