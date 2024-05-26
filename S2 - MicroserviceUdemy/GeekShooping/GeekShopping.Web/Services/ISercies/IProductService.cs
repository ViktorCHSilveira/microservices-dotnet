using GeekShopping.web.Models;

namespace GeekShopping.web.Services.ISercies {
    public interface IProductService {

        Task<IEnumerable<ProductModel>> FindAllProducts();

        Task<ProductModel> FindProductById(long id);
        Task<ProductModel> CreateProduct(ProductModel product);
        Task<ProductModel> UpdateProduct(ProductModel product);
        Task<bool> DeleteyId(long id);
    }
}
