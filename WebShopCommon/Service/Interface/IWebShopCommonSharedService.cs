namespace WebShopCommon.Service.Interface
{
    public interface IWebShopCommonSharedService
    {
        List<int>? GetRandomNumberList(int start, int end);
    }
}