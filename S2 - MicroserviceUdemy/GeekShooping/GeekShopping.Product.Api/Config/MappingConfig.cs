using AutoMapper;
using GeekShopping.ProductApi.Data.DTO;
using GeekShopping.ProductApi.Model;

namespace GeekShopping.ProductApi.Config {
    public class MappingConfig {

        public static MapperConfiguration RegisterMapas() {

            var mappingConfig = new MapperConfiguration( config => {
                config.CreateMap<ProductDTO, Product>();
                config.CreateMap<Product, ProductDTO>();
            });

            return mappingConfig;
        }
    }
}
