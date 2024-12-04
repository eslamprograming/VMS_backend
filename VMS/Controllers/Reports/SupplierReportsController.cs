using DAL.IRepo.IReports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VMS.Controllers.Reports
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SupplierReportsController : ControllerBase
    {
        private readonly ISupplierReportsRepo supplier;

        public SupplierReportsController(ISupplierReportsRepo supplier)
        {
            this.supplier = supplier;
        }
        [HttpGet("TheBestSupplierGetMoney")]
        public async Task<IActionResult> TheBestSupplierGetMoney()
        {
            var result = await supplier.TheBestSupplierGetMoney();
            return Ok(result);
        }
        [HttpGet("TheBestSupplierGetMoneyBetween")]
        public async Task<IActionResult> TheBestSupplierGetMoneyBetween(DateTime startdate,DateTime enddate)
        {
            var result = await supplier.TheBestSupplierGetMoneyBetween(startdate,enddate);
            return Ok(result);
        }
        [HttpGet("TheBestSupplierSuppliy")]
        public async Task<IActionResult> TheBestSupplierSuppliy()
        {
            var result = await supplier.TheBestSupplierSuppliy();
            return Ok(result);
        }
        [HttpGet("TheBestSupplierSuppliyBetween")]
        public async Task<IActionResult> TheBestSupplierSuppliyBetween(DateTime startdate, DateTime enddate)
        {
            var result = await supplier.TheBestSupplierSuppliyBetween(startdate,enddate);
            return Ok(result);
        }
    }
}
