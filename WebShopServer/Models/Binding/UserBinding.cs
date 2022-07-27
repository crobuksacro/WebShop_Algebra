using Newtonsoft.Json;
using WebShop.Validation;

namespace WebShop.Models.Binding
{
    public class UserBinding
    {
        //Validirati empty
        public string Firstname { get; set; }
        //Validirati empty
        public string Lastname { get; set; }
        //Validirati DOB min 18g
        public DateTime DOB { get; set; }
        [UserEmailValidation]
        public string Email { get; set; }
        [StringGreaterThanThanSeven]
        public string Password { get; set; }
        public AdressBinding UserAdress { get; set; }
    }
}
