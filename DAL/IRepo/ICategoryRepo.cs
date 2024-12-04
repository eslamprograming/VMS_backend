using DAL.DBContext;
using DAL.Entities;
using DAL.ModelVM.Sherad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepo
{
    public interface ICategoryRepo
    {
        Task<Response<Category>> AddCategory(string Name);
        Task<Response<Category>> DeleteCategory(int CatergoryId);
        Task<Response<Category>> UpdateCategory(int CatergoryId,string Name);
        Task<Response<Category>> GetAllCategory();



    }
}
