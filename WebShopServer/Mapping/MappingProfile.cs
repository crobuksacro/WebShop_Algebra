using WebShop.Models.Binding;
using WebShop.Models.Dbo;
using WebShopCommon.Models.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace WebShop.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<IdentityRole, UserRolesViewModel>();
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
            CreateMap<ProductUpdateApiBinding, Product>();


            CreateMap<AdressBinding, Adress>();
            CreateMap<Adress, AdressViewModel>();
            CreateMap<UserBinding, ApplicationUser>()
                .ForMember(dst => dst.UserName, opts => opts.MapFrom(src => src.Email))
                .ForMember(dst => dst.EmailConfirmed, opts => opts.MapFrom(src => true));


            CreateMap<FileStorage, FileStorageViewModel>();
            CreateMap<FileStorage, FileStorageExpendedViewModel>();


            CreateMap<FileStorageViewModel, FileStorage>().
                ForMember(dst => dst.Id, opts => opts.Ignore());
        }
    }
}
