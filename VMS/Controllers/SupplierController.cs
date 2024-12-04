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

    public class SupplierController : ControllerBase
    {
        private readonly ISupplicerService supplicerService;

        public SupplierController(ISupplicerService supplicerService)
        {
            this.supplicerService = supplicerService;
        }
        [HttpPost("AddSupplier")]
        public async Task<IActionResult> AddSupplier(PersonVM personVM)
        {
            try
            {
                var result = await supplicerService.AddSupplier(personVM);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return Ok(ex.Message);
            }
        }
        [HttpDelete("DeleteSupplier")]
        public async Task<IActionResult> DeleteSupplier(int Supplier_Id)
        {
            var result = await supplicerService.DeleteSupplier(Supplier_Id);
            return Ok(result);
        }
        [HttpGet("GetAllSupplier")]
        public async Task<IActionResult> GetAllSuplier(int GroupNumber)
        {
            var result = await supplicerService.GetAllSupplier(GroupNumber);
            return Ok(result);
        }
        [HttpGet("GetSupplier")]
        public async Task<IActionResult> GetSuplier(int Supplier_Id)
        {
            var result = await supplicerService.GetSupplier(Supplier_Id);
            return Ok(result);
        }
        [HttpPut("UpdateSupplier")]
        public async Task<IActionResult> UpdateSupplier(int supplier_Id, PersonVM personVM)
        {
            var result = await supplicerService.UpdateSupplier(supplier_Id,personVM);
            return Ok(result);
        }
    }
}
