using GeekShopping.web.Areas.Product.Models;
using GeekShopping.web.Areas.Product.Services.ISercies;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.web.Areas.Product.Controllers {

    public class ProductController : Controller {

        private readonly IProductService _productService;

        public ProductController(IProductService productService) {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        public async Task<ActionResult> ProductIndex() {

            var product = await _productService.FindAllProducts();

            return View(product);
        }

        public async Task<ActionResult> ProductForm(long id) {

            if (id == 0) {
                return View();
            }

            var model = await _productService.FindProductById(id);


            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Save(ProductModel model) {

            if (!ModelState.IsValid) {
                return View(model);
            }

            var product = new ProductModel();

            if (model.Id == null) {

                model.Id = 0;
                product = await _productService.CreateProduct(model);

            } else {

                product = await _productService.UpdateProduct(model);
            }
           

            if (product == null) {
                return View(model);
            }

            return RedirectToAction(nameof(ProductIndex));
        }

        public async Task<ActionResult> Delete(long id) {

            if (id == 0) {
                return RedirectToAction(nameof(ProductIndex));
            }

            var model = await _productService.DeleteById(id);


            return RedirectToAction(nameof(ProductIndex));
        }

    }
}
