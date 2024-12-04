using DAL.DBContext;
using DAL.Entities;
using DAL.IRepo;
using DAL.ModelVM.Sherad;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL.Repo
{
    public class CategoryRepo:ICategoryRepo
    {
        private readonly ApplicationDBContext db;

        public CategoryRepo(ApplicationDBContext db)
        {
            this.db = db;
        }

        public async Task<Response<Category>> AddCategory(string Name)
        {
            try
            {
                Category C1 = new Category();
                C1.name = Name;
                await db.Categories.AddAsync(C1);
                await db.SaveChangesAsync();
                return new Response<Category>()
                {
                    success=true,
                    statuscode="200"
                };
            }
            catch (Exception ex)
            {
                return new Response<Category>()
                {
                    success=false,
                    statuscode="500",
                    message=ex.Message
                };
            }
        }

        public async Task<Response<Category>> DeleteCategory(int CatergoryId)
        {
            try
            {
                db.Categories.Remove(await db.Categories.FindAsync(CatergoryId));
                await db.SaveChangesAsync();
                return new Response<Category>()
                {
                    success = true,
                    statuscode = "200"
                };
            }
            catch (Exception ex)
            {
                return new Response<Category>()
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }

        public async Task<Response<Category>> GetAllCategory()
        {
            try
            {
                var result = await db.Categories.ToListAsync();
                return new Response<Category>()
                {
                    success = true,
                    statuscode = "200",
                    values=result
                };
            }
            catch (Exception ex)
            {
                return new Response<Category>()
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }

        public async Task<Response<Category>> UpdateCategory(int CatergoryId, string Name)
        {
            try
            {
                Category C1 = await db.Categories.FindAsync(CatergoryId);
                C1.name = Name;
                await db.SaveChangesAsync();
                return new Response<Category>()
                {
                    success = true,
                    statuscode = "200"
                };
            }
            catch (Exception ex)
            {
                return new Response<Category>()
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }
    }
}
