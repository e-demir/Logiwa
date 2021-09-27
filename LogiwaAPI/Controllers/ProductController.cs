using LogiwaAPI.Models;
using LogiwaAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LogiwaAPI.Controllers
{

    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productrepository;

        public ProductController(IProductRepository productRepository)
        {
            _productrepository = productRepository;
        }

        [HttpGet]
        [Route("api/[controller]/[action]")]
        public IActionResult GetAllProducts()
        {
            return Ok(_productrepository.GetAllProducts());
        }

        [HttpGet]
        [Route("api/[controller]/[action]/{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _productrepository.GetProduct(id);

            if (product != null)
            {
                return Ok(product);
            }

            return NotFound($"The product with Id: {id} was not found ");
        }

        [HttpPost]
        [Route("api/[controller]/[action]")]
        public IActionResult AddProduct(Product product)
        {
            _productrepository.AddProduct(product);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + product.ProductId, product);
        }

        [HttpPost]
        [Route("api/[controller]/[action]/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _productrepository.GetProduct(id);

            if (product != null)
            {
                _productrepository.DeleteProduct(product);
                return Ok();
            }

            return NotFound($"The product with Id: {id} was not found ");
        }

        [HttpPost]
        [Route("api/[controller]/[action]/{id}")]
        public IActionResult EditProduct(int id, Product product)
        {
            var existingProduct = _productrepository.GetProduct(id);

            if (existingProduct != null)
            {
                product.ProductId = existingProduct.ProductId;
                _productrepository.EditProduct(product);
            }

            return Ok(product);
        }

    }
}
