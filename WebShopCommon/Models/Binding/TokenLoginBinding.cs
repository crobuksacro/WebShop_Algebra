using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebShopCommon.Models.Binding
{
    public class TokenLoginBinding
    {
        [Required]
        [DisplayName("Username")]
        public string UserName { get; set; }
        [Required]
        [DisplayName("Password")]
        public string Password { get; set; }
    }
}
