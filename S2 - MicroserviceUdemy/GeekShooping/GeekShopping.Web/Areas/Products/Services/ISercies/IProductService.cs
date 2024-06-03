﻿using GeekShopping.web.Areas.Product.Models;

namespace GeekShopping.web.Areas.Product.Services.ISercies {
    public interface IProductService {

        Task<IEnumerable<ProductModel>> FindAllProducts();

        Task<ProductModel> FindProductById(long id);
        Task<ProductModel> CreateProduct(ProductModel product);
        Task<ProductModel> UpdateProduct(ProductModel product);
        Task<bool> DeleteById(long id);
    }
}
