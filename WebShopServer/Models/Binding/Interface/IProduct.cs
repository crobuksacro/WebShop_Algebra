namespace WebShop.Models.Binding.Interface
{
    public interface IProduct
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public int ProductCategoryId { get; set; }
    }
}
