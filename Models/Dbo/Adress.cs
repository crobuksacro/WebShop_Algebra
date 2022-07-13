using WebShop.Models.Base;
using WebShop.Models.Dbo.Base;
using System.ComponentModel.DataAnnotations;

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
