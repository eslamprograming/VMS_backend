using DAL.ModelVM;
using DAL.ModelVM.AuthVM;
using DAL.ModelVM.Sherad;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IService
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(RegisterModel model);
        Task<AuthModel> LoginAsync(LoginUser loginuser);
        Task<AuthModel> UpdateAsync(UpdateVM userUpdate, ApplicationUser user);
        Task<Response<ApplicationUser>> UploadPhotoAsync(IFormFile Photo, string User_Id);
        Task<Response<ApplicationUser>> DeletePhotoAsync(string User_Id);
        Task<Response<ApplicationUser>> UpdatePhotoAsync(IFormFile Photo, string User_Id);
    }
}
