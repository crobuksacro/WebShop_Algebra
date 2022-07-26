using System.ComponentModel.DataAnnotations;

namespace WebShopCommon.Models.Base
{
    public abstract class ProductCategoryBase
    {
        [Required(ErrorMessage = "Obavezan unos!")]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
