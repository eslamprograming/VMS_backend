using BLL.IService;
using DAL.ModelVM.AuthVM;
using DAL.ModelVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BLL.Helper;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;

namespace VMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthService _authService;

        public AuthController(UserManager<ApplicationUser> userManager, IAuthService authService)
        {
            _userManager = userManager;
            _authService = authService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _authService.RegisterAsync(registerModel);
            return Ok(result);
        }
        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> UploadImage(IFormFile image)
        {
            
            string imageUrl = await CloudinaryHelper.UploadImageAsync(image);

            if (string.IsNullOrEmpty(imageUrl))
            {
                return BadRequest("Failed to upload image.");
            }

            // إرجاع الرابط العام للصورة
            return Ok(new { imageUrl });
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(string publicId)
        {

            if (string.IsNullOrEmpty(publicId))
            {
                return BadRequest("PublicId is required.");
            }

            bool isDeleted = await CloudinaryHelper.DeleteImageAsync(publicId);

            if (isDeleted)
            {
                return Ok("Image deleted successfully.");
            }
            else
            {
                return BadRequest("Failed to delete image.");
            }
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginUser loginUser)
        {
            var result = await _authService.LoginAsync(loginUser);
            return Ok(result);
        }
    }
}
