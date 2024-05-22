using AutoMapper;
using GeekShopping.ProductApi.Data.DTO;
using GeekShopping.ProductApi.Model;
using GeekShopping.ProductApi.Model.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GeekShopping.ProductApi.Repository {
    public class ProductRepository : IProductRepository {

        private readonly MySQLContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(IMapper mapper, MySQLContext context) {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<ProductDTO>> FindAll() {

            List<Product> products = await _context.Products.ToListAsync();

            return _mapper.Map<List<ProductDTO>>(products);
        }

        public async Task<ProductDTO> FindById(long id) {

            Product products = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync() ?? new Product() ;

            return _mapper.Map<ProductDTO>(products);
        }

        public async Task<ProductDTO> Create(ProductDTO dto) {

            Product products = _mapper.Map<Product>(dto);
            _context.Products.Add(products);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductDTO>(products);
        }

        public async Task<ProductDTO> Update(ProductDTO dto) {

            Product products = _mapper.Map<Product>(dto);
            _context.Products.Update(products);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductDTO>(products);
        }

        public async Task<bool> Delete(long id) {
            try {
               
                Product products = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync() ?? new Product();

                if (products.Id <= 0) return false;

                _context.Products.Remove(products);
                await _context.SaveChangesAsync();

                return true;

            } catch (Exception) {
                return false;
                
            }
        }

    }
}
