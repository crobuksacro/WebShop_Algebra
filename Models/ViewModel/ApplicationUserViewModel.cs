using WebShop.Models.Base;

namespace WebShop.Models.ViewModel
{
    public class ApplicationUserViewModel: ApplicationUserBase
    {
        public string Id { get; set; }
        public List<AdressViewModel> Adress { get; set; }
    }
}
