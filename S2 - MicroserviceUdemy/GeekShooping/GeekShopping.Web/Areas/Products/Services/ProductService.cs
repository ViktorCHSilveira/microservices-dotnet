﻿using GeekShopping.web.Areas.Product.Models;
using GeekShopping.web.Areas.Product.Services.ISercies;
using GeekShopping.web.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Reflection;

namespace GeekShopping.web.Areas.Product.Services {
    public class ProductService : IProductService {

        private readonly HttpClient _httpClient;
        public const string BasePath = "api/v1/product";

        public ProductService(HttpClient httpClient) {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<IEnumerable<ProductModel>> FindAllProducts() {
            var response = await _httpClient.GetAsync(BasePath);
            return await response.ReadContentAs<List<ProductModel>>();
        }

        public async Task<ProductModel> FindProductById(long id) {
            var response = await _httpClient.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<ProductModel>();
        }

        public async Task<ProductModel> CreateProduct(ProductModel model) {

            var response = await _httpClient.PostAsJson(BasePath, model);

            if (!response.IsSuccessStatusCode) {
                throw new Exception("Something went wrong when calling API");
            }

            return await response.ReadContentAs<ProductModel>();
        }

        public async Task<ProductModel> UpdateProduct(ProductModel model) {

            var response = await _httpClient.PutAsJson(BasePath, model);

            if (!response.IsSuccessStatusCode) {
                throw new Exception("Something went wrong when calling API");
            }

            return await response.ReadContentAs<ProductModel>();
        }

        public async Task<bool> DeleteById(long id) {


            var response = await _httpClient.DeleteAsync($"{BasePath}?id={id}");

            if (!response.IsSuccessStatusCode) {
                throw new Exception("Something went wrong when calling API");
            }
            return await response.ReadContentAs<bool>();
        }

    }
}
