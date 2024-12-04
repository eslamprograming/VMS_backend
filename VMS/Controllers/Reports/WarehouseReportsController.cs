using DAL.IRepo.IReports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VMS.Controllers.Reports
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WarehouseReportsController : ControllerBase
    {
        private readonly IWarehouseReportsRepo _warehouseReportsRepo;

        public WarehouseReportsController(IWarehouseReportsRepo warehouseReportsRepo)
        {
            _warehouseReportsRepo = warehouseReportsRepo;
        }

        [HttpGet("GetAllProductInWarehouse")]
        public async Task<IActionResult> GetAllProductInWarehouse(int Warehouse_Id)
        {
            var result = await _warehouseReportsRepo.GetAllProductInWarehouse(Warehouse_Id);
            return Ok(result);
        }
    }
}
