using DAL.IRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VMS.Controllers.Reports
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MoneyReportsController : ControllerBase
    {
        private readonly ImoneyReportsRepo money;

        public MoneyReportsController(ImoneyReportsRepo money)
        {
            this.money = money;
        }
        [HttpGet("NetProfitbetweenProc")]
        public async Task<IActionResult> NetProfitbetweenProc(DateTime startdate, DateTime enddate)
        {
            var result = await money.NetProfitbetweenProc(startdate, enddate);
            return Ok(result);
        }
        [HttpGet("NetProfitProc")]
        public async Task<IActionResult> NetProfitProc()
        {
            var result = await money.NetProfitProc();
            return Ok(result);
        }
        [HttpGet("NettotalOrderprice")]
        public async Task<IActionResult> NettotalOrderprice()
        {
            var result = await money.NettotalOrderprice();
            return Ok(result);
        }
        [HttpGet("NettotalOrderpricebetween")]
        public async Task<IActionResult> NettotalOrderpricebetween(DateTime startdate, DateTime enddate)
        {
            var result = await money.NettotalOrderpricebetween(startdate, enddate);
            return Ok(result);
        }
        [HttpGet("NettotalSuppliyprice")]
        public async Task<IActionResult> NettotalSuppliyprice()
        {
            var result = await money.NettotalSuppliyprice();
            return Ok(result);
        }
        [HttpGet("NettotalSuppliypricebetween")]
        public async Task<IActionResult> NettotalSuppliypricebetween(DateTime startdate, DateTime enddate)
        {
            var result = await money.NettotalSuppliypricebetween(startdate, enddate);
            return Ok(result);
        }
    }
}
