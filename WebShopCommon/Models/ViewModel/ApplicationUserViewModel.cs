using WebShopCommon.Models.Base;

namespace WebShopCommon.Models.ViewModel
{
    public class ApplicationUserViewModel: ApplicationUserBase
    {
        public string Id { get; set; }
        public List<AdressViewModel> Adress { get; set; }
    }
}
