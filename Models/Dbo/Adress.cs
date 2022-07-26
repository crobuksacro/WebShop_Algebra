using System.ComponentModel.DataAnnotations;
using WebShop.Models.Dbo.Base;
using WebShopCommon.Models.Base;

namespace WebShop.Models.Dbo
{
    public class Adress: AdressBase, IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public DateTime Created { get; set; }
    }
}
