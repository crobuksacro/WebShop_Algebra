namespace WebShop.Models
{
    public static class Roles
    {
        //public const string SuperAdmin = "SuperAdmin";
        public const string Admin = "Admin";
        public const string BasicUser = "BasicUser";
        public const string Employee = "Employee";
    }
    public static class CorsPolicy
    {
        public const string AllowAll = "AllowAllCors";
    }
    public enum ShoppingCartStatus
    {
        Pending,
        Succeeded,
        Suspended

    }

}
