using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShopCommon.Service.Interface;

namespace WebShopCommon.Service.Implementation
{
    public class WebShopCommonSharedService : IWebShopCommonSharedService
    {

        public List<int>? GetRandomNumberList(int start, int end)
        {
            if (start > end)
            {
                return null;
            }

            if (end == 0)
            {
                return null;
            }
            Random random = new Random();
            List<int> list = new List<int>();
            while (list.Count() < end)
            {
                var randomNumber = random.Next(start, end);
                var find = list.FirstOrDefault(x => x == randomNumber);
                if (find != null)
                {
                    list.Add(randomNumber);
                }
            }
            return list;
        }


    }
}
