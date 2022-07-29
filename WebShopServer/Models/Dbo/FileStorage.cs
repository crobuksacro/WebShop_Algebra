using WebShop.Models.Dbo.Base;
using WebShopCommon.Models.Base;

namespace WebShop.Models.Dbo
{
    public class FileStorage : FileStorageBase, IEntityBase
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
    }
}
