using GeekShopping.ProductApi.Data.DTO;
using GeekShopping.ProductApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductApi.Controllers {
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase {

        private IProductRepository _repository;

        public ProductController(IProductRepository repository) {

            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> FindById(long id) {
            
            var products = await _repository.FindById(id);
            if (products.Id <= 0) return NotFound();

            return Ok(products);
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> FindAll() {

            var product =  await _repository.FindAll();
            if (product == null) return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<List<ProductDTO>>> CreateProduct(ProductDTO productDto) {

            if (productDto == null) return BadRequest();

            var response = await _repository.Create(productDto);

            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<List<ProductDTO>>> UpdateProduct(ProductDTO productDto) {

            if (productDto == null) return BadRequest();

            var response = await _repository.Update(productDto);

            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteProduct(long id) {

            var status = await _repository.Delete(id);
            if (status == false) return BadRequest();


            return Ok("true");
        }
    }
}
