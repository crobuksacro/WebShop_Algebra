using WebShop.Models.Binding;
using WebShop.Models.Dbo;
using WebShop.Models.ViewModel;
using AutoMapper;

namespace WebShop.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductBinding, Product>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductCategoryBinding, ProductCategory>();
            CreateMap<ProductCategory, ProductCategoryViewModel>();
            CreateMap<ProductCategoryUpdateBinding, ProductCategory>();
            CreateMap<ShoppingCartItemBinding, ShoppingCartItem>();
            CreateMap<ShoppingCartItem, ShoppingCartItemViewModel>();
            CreateMap<ApplicationUser, ApplicationUserViewModel>();
            CreateMap<ShoppingCart, ShoppingCartViewModel>();
            CreateMap<Order, OrderViewModel>();

            CreateMap<ProductViewModel, ProductUpdateBinding>();
            CreateMap<ProductUpdateBinding, Product>();

            CreateMap<AdressBinding, Adress>();
            CreateMap<Adress, AdressViewModel>();
        }
    }
}
