namespace WebShop.Models.Base
{
    public abstract class ApplicationUserBase
    {  
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DOB { get; set; }
    }
}
