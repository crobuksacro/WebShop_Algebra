using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShopCommon.Models.Base
{
    public abstract class ProductBase
    {
        [Required]
        [StringLength(200, MinimumLength = 2)]
        [Display(Name = "Naziv")]
        public string Title { get; set; }
        [Display(Name = "Opis")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Količina")]
        [Column(TypeName = "decimal(9, 2)")] // Postoji još nekoliko načina za ASP.NET Core 5, ali ovo je najlakši. Prilagodite po potrebi
        public decimal Quantity { get; set; }

        [Required]
        [Display(Name = "Cijena")]
        [Column(TypeName = "decimal(9, 2)")]
        public decimal Price { get; set; }
    }
}
