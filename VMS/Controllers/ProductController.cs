using BLL.IService;
using DAL.ModelVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Employee")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct([FromForm]ProductVM productVM)
        {
            var result = await _productService.CreateProduct(productVM);
            return Ok(result);
        }
        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int Product_Id)
        {
            var result = await _productService.DeleteProduct(Product_Id);
            return Ok(result);
        }
        [HttpGet("GetAllProductInCategory")]
        public async Task<IActionResult> GetAllProductInCategory(int Category_Id)
        {
            var result = await _productService.GetAllProductInCategory(Category_Id);
            return Ok(result);
        }
        [HttpGet("GetAllProduct")]
        public async Task<IActionResult> GetAllProduct()
        {
            var result = await _productService.GetAllProduct();
            return Ok(result);
        }
        [HttpGet("GetProduct")]
        public async Task<IActionResult> GetProduct(int Product_Id)
        {
            var result = await _productService.GetProduct(Product_Id);
            return Ok(result);
        }
        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(int Product_Id,[FromForm] ProductVM productVM)
        {
            var result = await _productService.UpdateProduct(Product_Id,productVM);
            return Ok(result);
        }
        [HttpGet("GetProductToSells")]
        public async Task<IActionResult> GetProductToSells()
        {
            var result = await _productService.ProductAvailableToSell();
            return Ok(result);
        }
        [HttpGet("GetProductNotInWarehouse")]
        public async Task<IActionResult> GetProductNotInWarehouse()
        {
            var result = await _productService.AllProductNotInWarehouse();
            return Ok(result);
        }
    }
}
