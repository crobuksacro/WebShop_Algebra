﻿using WebShop.Models.Binding.Interface;
using WebShop.Validation;

namespace WebShop.Models.Binding
{
    [ProductValidation]
    public class CarProduct: IProduct
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public int ProductCategoryId { get; set; }
    }
}
