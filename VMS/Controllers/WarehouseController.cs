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

    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService warehouseService;

        public WarehouseController(IWarehouseService warehouseService)
        {
            this.warehouseService = warehouseService;
        }
        [HttpPost("CreateWarehose")]
        public async Task<IActionResult> CreateWarehouse(WarehouseVM warehouseVM)
        {
            var result = await warehouseService.CreateWarehouse(warehouseVM);
            return Ok(result);
        }
        [HttpDelete("DeleteWarehose")]
        public async Task<IActionResult> DeleteWarehose(int Warehouse_Id)
        {
            var result = await warehouseService.DeleteWarehouse(Warehouse_Id);
            return Ok(result);
        }
        [HttpGet("GetAllWarehose")]
        public async Task<IActionResult> GetAllWarehose(int Group)
        {
            var result = await warehouseService.GetAllWarehouse(Group);
            return Ok(result);
        }
        [HttpGet("GetWarehose")]
        public async Task<IActionResult> GetWarehose(int warehouse_Id)
        {
            var result = await warehouseService.GetWarehouse(warehouse_Id);
            return Ok(result);
        }
        [HttpGet("GetWarehoseInProduct")]

        public async Task<IActionResult> GetWarehoseInProduct(int Product_Id)
        {
            var result = await warehouseService.GetWarehouseInProduct(Product_Id);
            return Ok(result);
        }
        [HttpPut("UpdateWarehose")]
        public async Task<IActionResult> UpdateWarehose(int warehouse_Id,WarehouseVM warehouseVM)
        {
            var result = await warehouseService.UpdateWarehouse(warehouse_Id,warehouseVM);
            return Ok(result);
        }
    }
}
