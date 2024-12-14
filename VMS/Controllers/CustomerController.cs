using DAL.IRepo;
using DAL.ModelVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Employee")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepo customerRepo;

        public CustomerController(ICustomerRepo customerRepo)
        {
            this.customerRepo = customerRepo;
        }
        [HttpPost("AddCustomer")]
        public async Task<IActionResult> AddCustomer(CustomerVM customerVM)
        {
            var result = await customerRepo.AddCustomerasync(customerVM);
            return Ok(result);
        }
        [HttpDelete("DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer(int Customer_Id)
        {
            var result = await customerRepo.DeleteCustomerasync(Customer_Id);
            return Ok(result);
        }
        [HttpGet("GetAllCustomer")]
        public async Task<IActionResult> GetAllCustomer(int GroupNumber)
        {
            var result=await customerRepo.GetALLCustomerAsync(GroupNumber);
            return Ok(result);
        }
        [HttpPut("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer(int Customer_Id,CustomerVM customerVM)
        {
            var result = await customerRepo.UpdateCustomerasync(Customer_Id, customerVM);
            return Ok(result);
        }
        [HttpGet("GetCustomer")]
        public async Task<IActionResult> GetCustomer(int Customer_Id)
        {
            var result = await customerRepo.GetCustomerAsync(Customer_Id);
            return Ok(result);
        }
        [HttpGet("GetCustomerByPhone")]
        public async Task<IActionResult> GetCustomerByPhone(string phone)
        {
            var result = await customerRepo.GetCustomerbyphoneAsync(phone);
            return Ok(result);
        }
    }
}
