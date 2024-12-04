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
    [Authorize(Roles = "Employee")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;
        private readonly UserManager<ApplicationUser> userManager;

        
        public OrderController(UserManager<ApplicationUser> userManager, IOrderService orderService)
        {
            this.userManager = userManager;
            this.orderService = orderService;
        }

        [HttpPost("Order")]
        public async Task<IActionResult> CreateOrder([FromBody]OrderVM orderVM)
        {
            orderVM.EmployeeID = User.FindFirstValue("uid");
            var result= await orderService.CreateOrder(orderVM);
            return Ok(result);
        }
        [HttpGet("GetOrder")]
        public async Task<IActionResult> GetOrder(int Order_Id)
        {
            var result = await orderService.GetOrderAsync(Order_Id);
            return Ok(result);
        }
        [HttpDelete("DeleteOrder")]
        public async Task<IActionResult> DeleteOrder(int Order_Id)
        {
            var result = await orderService.DeleteOrderAsync(Order_Id);
            return Ok(result);
        }
    }
}
