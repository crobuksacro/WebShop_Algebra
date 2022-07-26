﻿using WebShopCommon.Models.Base;
using WebShopCommon.Models.ViewModel;

namespace WebShop.Models.Binding
{
    public class ProductUpdateBinding : ProductBase
    {
        public int Id { get; set; }
        public ProductCategoryViewModel ProductCategory { get; set; }
        public int ProductCategoryId { get; set; }
    }
}
