using BLL.IService;
using DAL.ModelVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace VMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Employee")]
    public class ProductSuppliyController : ControllerBase
    {
        private readonly IProductSuppliyService productSuppliyService;
        private readonly UserManager<ApplicationUser> userManager;
        public ProductSuppliyController(IProductSuppliyService productSuppliyService, UserManager<ApplicationUser> userManager)
        {
            this.productSuppliyService = productSuppliyService;
            this.userManager = userManager;
        }
        [HttpPost("AddProductSuppliy")]
        public async Task<IActionResult> AddProductSuppliy(ProductSuppliyVM productSuppliyVM)
        {
            productSuppliyVM.EmployeeID = User.FindFirstValue("uid");
            var result = await productSuppliyService.AddProductSuppliy(productSuppliyVM);
            return Ok(result);
        }
        [HttpPost("PutProductInWarehouse")]
        public async Task<IActionResult> PutProductInWarehouse(PutProductInWarehouse putProductInWarehouse)
        {
            var result = await productSuppliyService.PutProductInWarehouse(putProductInWarehouse);
            return Ok(result);
        }

    }
}
