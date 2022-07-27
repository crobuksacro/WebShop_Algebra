using Newtonsoft.Json;

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
        //Validirati Email uniq
        public string Email { get; set; }
        //Validirati Password > 7znakova 
        public string Password { get; set; }
        public AdressBinding UserAdress { get; set; }
    }
}
