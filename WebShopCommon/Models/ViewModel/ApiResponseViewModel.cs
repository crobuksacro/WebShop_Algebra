namespace WebShopCommon.Models.ViewModel
{
    public class ApiResponseViewModel
    {
        public ApiResponseViewModel()
        {
        }

        public ApiResponseViewModel(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}
