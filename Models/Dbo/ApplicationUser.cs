using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace WebShop.Models.Dbo
{
    public class ApplicationUser : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DOB { get; set; }
        public ICollection<Adress> Adress { get; set; }
        public ICollection<ShoppingCart> ShoppingCart { get; set; }
    }
}
