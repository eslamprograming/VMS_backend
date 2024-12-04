using DAL.IRepo.IReports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VMS.Controllers.Reports
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerReportsController : ControllerBase
    {
        private readonly ICustomerReportsRepo customerReportsRepo;

        public CustomerReportsController(ICustomerReportsRepo customerReportsRepo)
        {
            this.customerReportsRepo = customerReportsRepo;
        }
        [HttpGet("GetTheBestCustomerOrder")]
        public async Task<IActionResult> GetTheBestCustomerOrder()
        {
            var result = await customerReportsRepo.ThebestCustomerGetOrder();
            return Ok(result);
        }
        [HttpGet("ThebestCustomerPayed")]
        public async Task<IActionResult> ThebestCustomerPayed()
        {
            var result = await customerReportsRepo.ThebestCustomerPayed();
            return Ok(result);
        }
    }
}
