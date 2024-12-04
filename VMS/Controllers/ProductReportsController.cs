using DAL.IRepo.IReports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductReportsController : ControllerBase
    {
        private readonly IProductReportRepo _productReportRepo;

        public ProductReportsController(IProductReportRepo productReportRepo)
        {
            _productReportRepo = productReportRepo;
        }
        [HttpGet("bestProductSell")]
        public async Task<IActionResult> bestProductSell()
        {
            var result = await _productReportRepo.bestProductSell();
            return Ok(result);
        }
        [HttpGet("ProductNotSell")]
        public async Task<IActionResult> ProductNotSell()
        {
            var result = await _productReportRepo.ProductNotSell();
            return Ok(result);
        }
        [HttpGet("bestCountProductInWarehouse")]
        public async Task<IActionResult> bestCountProductInWarehouse()
        {
            var result = await _productReportRepo.bestCountProductInWarehouse();
            return Ok(result);
        }
        [HttpGet("bestProductSellbetween")]
        public async Task<IActionResult> bestProductSellbetween(DateTime startdate,DateTime enddate)
        {
            var result = await _productReportRepo.bestProductSellbetween(startdate,enddate);
            return Ok(result);
        }
        [HttpGet("ProductNotSellbetween")]
        public async Task<IActionResult> ProductNotSellbetween(DateTime startdate, DateTime enddate)
        {
            var result = await _productReportRepo.ProductNotSellbetween(startdate, enddate);
            return Ok(result);
        }
    }
}
