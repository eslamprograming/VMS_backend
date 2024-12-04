using DAL.IRepo.IReports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Employee")]
    public class SupplierReportsController : ControllerBase
    {
        private readonly ISupplierRepoerts supplierRepoerts;

        public SupplierReportsController(ISupplierRepoerts supplierRepoerts)
        {
            this.supplierRepoerts = supplierRepoerts;
        }
        [HttpGet("GetAllSupplyReport")]
        public async Task<IActionResult> GetAllSupplyReport()
        {
            var result = await supplierRepoerts.GetSupplierProduct();
            return Ok(result);
        }
    }
}
