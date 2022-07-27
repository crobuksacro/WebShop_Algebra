namespace WebShop.Extensions
{
    public static class StringExtensions
    {
        public static bool StringGreaterThan(this string input, int lenght)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            return input.Count() > lenght;
        }

    }
}
