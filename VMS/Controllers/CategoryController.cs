using DAL.IRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepo categoryRepo;

        public CategoryController(ICategoryRepo categoryRepo)
        {
            this.categoryRepo = categoryRepo;
        }
        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategory(string name)
        {
            var result=await categoryRepo.AddCategory(name);
            return Ok(result);
        }
        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(int CategoryId)
        {
            var result = await categoryRepo.DeleteCategory(CategoryId);
            return Ok(result);
        }
        [HttpPatch("UpdateCategoryName")]
        public async Task<IActionResult> UpdateCategoryName(int Category_Id,string name)
        {
            var result = await categoryRepo.UpdateCategory(Category_Id,name);
            return Ok(result);
        }
        [HttpGet("GetAllCategory")]
        public async Task<IActionResult> GetAllCategory()
        {
            var result = await categoryRepo.GetAllCategory();
            return Ok(result);
        }
    }
}
