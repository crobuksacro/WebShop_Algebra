using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
