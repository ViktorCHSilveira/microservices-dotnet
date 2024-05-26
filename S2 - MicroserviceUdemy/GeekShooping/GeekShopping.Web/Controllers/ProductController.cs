using GeekShopping.web.Services.ISercies;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.web.Controllers {
    public class ProductController : Controller{

        private readonly IProductService _productService;

        public ProductController(IProductService productService) {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        public async Task<ActionResult> ProductIndex() {

            var product = await _productService.FindAllProducts();

            return View(product);
        }
    }
}
