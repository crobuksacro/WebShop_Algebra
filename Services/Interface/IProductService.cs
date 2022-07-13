﻿using WebShop.Models.Binding;
using WebShop.Models.ViewModel;

namespace WebShop.Services.Interface
{
    public interface IProductService
    {
        Task<OrderViewModel> SuspendOrder(int id);
        Task<ProductViewModel> UpdateProductAsync(ProductUpdateBinding model);
        Task UpdateShoppinCartStatus();
        Task<OrderViewModel> GetOrderAsync(int id);
        Task<List<OrderViewModel>> GetOrdersAsync();
        Task<OrderViewModel> AddOrder(OrderBinding model);
        Task<ShoppingCartViewModel> GetShoppingCartAsync(string userId);
        Task<ProductViewModel> AddProductAsync(ProductBinding model);
        Task<ProductViewModel> GetProductAsync(int id);
        Task<List<ProductViewModel>> GetProductsAsync();
        Task<ProductCategoryViewModel> UpdateProductCategoryAsync(ProductCategoryUpdateBinding model);
        Task<List<ProductCategoryViewModel>> GetProductCategorysAsync();
        Task<ProductCategoryViewModel> GetProductCategoryAsync(int id);
        Task<ProductCategoryViewModel> AddProductCategoryAsync(ProductCategoryBinding model);
        Task<ShoppingCartViewModel> AddShoppingCartAsync(ShoppingCartBinding model);
    }
}