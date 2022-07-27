namespace WebShop.Extensions
{
    public static class DecimalExtensions
    {
        public static bool GreaterThan(this decimal input, decimal compared)
        {
            return input > compared;
        }

    }
}
