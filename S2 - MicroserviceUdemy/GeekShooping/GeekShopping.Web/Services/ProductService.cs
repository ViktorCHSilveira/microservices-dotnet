﻿using GeekShopping.web.Models;
using GeekShopping.web.Services.ISercies;
using GeekShopping.web.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace GeekShopping.web.Services {
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

        public async Task<ProductModel> CreateProduct([FromBody] ProductModel model) {

            var response = await _httpClient.PostAsJson(BasePath, model);

            if (!response.IsSuccessStatusCode) {
                throw new Exception("Something went wrong when calling API");
            }

            return await response.ReadContentAs<ProductModel>();
        }

        public async Task<ProductModel> UpdateProduct([FromBody] ProductModel model) {

            var response = await _httpClient.PutAsJson(BasePath, model);

            if (!response.IsSuccessStatusCode) {
                throw new Exception("Something went wrong when calling API");
            }

            return await response.ReadContentAs<ProductModel>();
        }

        public async Task<bool> DeleteyId(long id) {

            var response = await _httpClient.DeleteAsync($"{BasePath}/{id}");

            if (!response.IsSuccessStatusCode) {
                throw new Exception("Something went wrong when calling API");
            }
            return await response.ReadContentAs<bool>();
        }

    }
}