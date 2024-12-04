using DAL.DBContext;
using DAL.Entities;
using DAL.IRepo;
using DAL.ModelVM;
using DAL.ModelVM.Sherad;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class ProductRepo : IProductRepo
    {
        private readonly ApplicationDBContext db;
        private readonly IConfiguration configuration;

        public ProductRepo(ApplicationDBContext db,IConfiguration configuration)
        {
            this.db = db;
            this.configuration = configuration;
        }

        public async Task<Response<Product>> AllProductNotInWarehouse()
        {
            try
            {
                string ConnectionStrings = configuration.GetConnectionString("DefaultConnection");
                List<Product> products = new List<Product>();
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionStrings))
                {
                    // فتح الاتصال بشكل غير متزامن
                    await sqlConnection.OpenAsync();

                    using (SqlCommand sqlCommand = new SqlCommand("getAllProductnotInWarehouse", sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        // قراءة البيانات بشكل غير متزامن
                        using (SqlDataReader reader = await sqlCommand.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                Product product = new Product()
                                {
                                    Product_Id = reader.GetInt32(reader.GetOrdinal("Product_Id")),
                                    Name = reader["Name"].ToString(),
                                    ProductAmount = reader.GetInt32(reader.GetOrdinal("AmountNotInWarehouse"))
                                };
                                if (product.ProductAmount > 0)
                                {
                                    products.Add(product);
                                }
                               
                            }
                        }
                    }
                    return new Response<Product>()
                    {
                        success = true,
                        statuscode = "200",
                        values = products
                    };
                }
            }

            catch (Exception ex)
            {
                return new Response<Product>()
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }

        public async Task<Response<Product>> CreateProduct(ProductVM productVM)
        {
            try
            {
                Product product = new Product();
                product.Name = productVM.Name;
                product.ProductAmount = productVM.ProductAmount;
                product.Description=productVM.Description;
                product.Price = productVM.Price;
                product.Category = await db.Categories.FindAsync(productVM.Category_Id);
                await db.Products.AddAsync(product);
                await db.SaveChangesAsync();
                return new Response<Product>()
                {
                    success = true,
                    statuscode = "200"
                };
            }
            catch (Exception ex)
            {
                return new Response<Product>(){
                    success=false,
                    statuscode="500",
                    message=ex.Message
                };
            }
        }

        public async Task<Response<Product>> DeleteProduct(int Product_Id)
        {
            try
            {
                var result = await db.Products.FindAsync(Product_Id);
                db.Products.Remove(result);
                await db.SaveChangesAsync();
                return new Response<Product>()
                {
                    success = true,
                    statuscode="200"
                };
            }
            catch (Exception ex)
            {
                return new Response<Product>()
                {
                    success=false,
                    statuscode="500"
                    ,message=ex.Message
                };
            }
        }

        public async Task<Response<Product>> GetAllProductInCategory(int Category_Id)
        {
            try
            {
                var result = await db.Products.Where(n => n.Category.Category_Id == Category_Id).ToListAsync();

                return new Response<Product>()
                {
                    success = true,
                    statuscode = "200",
                    values=result
                };
            }
            catch (Exception ex)
            {
                return new Response<Product>()
                {
                    success = false,
                    statuscode = "500"
                    ,
                    message = ex.Message
                };
            }
        }

        public async Task<Response<Product>> GetProduct(int Product_Id)
        {
            try
            {
                var result = await db.Products.FindAsync(Product_Id);
                return new Response<Product>()
                {
                    success = true,
                    statuscode = "200",
                    Value=result
                };
            }
            catch (Exception ex)
            {
                return new Response<Product>()
                {
                    success = false,
                    statuscode = "500"
                    ,
                    message = ex.Message
                };
            }
        }

        public async Task<Response<Product>> ProductAvailableToSell()
        {
            try
            {
                string ConnectionStrings = configuration.GetConnectionString("DefaultConnection");
                List<Product> products = new List<Product>();
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionStrings))
                {
                    // فتح الاتصال بشكل غير متزامن
                    await sqlConnection.OpenAsync();

                    using (SqlCommand sqlCommand = new SqlCommand("getAllProduct", sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        // قراءة البيانات بشكل غير متزامن
                        using (SqlDataReader reader = await sqlCommand.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                Product product = new Product()
                                {
                                    Name = reader["Name"].ToString(),
                                    Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                                    Description = reader["Description"].ToString(),
                                    ProductAmount = reader.GetInt32(reader.GetOrdinal("Amount"))
                                };
                                products.Add(product);
                            }
                        }
                    }
                }
                return new Response<Product>()
                    {
                        success = true,
                        statuscode = "200",
                        values=products
                    };
            }
            catch (Exception ex)
            {
                return new Response<Product>()
                {
                    success = false,
                    statuscode = "500"
                    ,
                    message = ex.Message
                };
            }
        }

        public async Task<Response<Product>> UpdateProduct(int Product_Id, ProductVM productVM)
        {
            try
            {
                var result = await db.Products.FindAsync(Product_Id);
                result.Name = productVM.Name;
                result.Price = productVM.Price;
                result.Description = productVM.Description;
                result.ProductAmount= productVM.ProductAmount;
                result.Category = await db.Categories.FindAsync(productVM.Category_Id);
                await db.SaveChangesAsync();
                return new Response<Product>()
                {
                    success = true,
                    statuscode = "200"
                };
            }
            catch (Exception ex)
            {
                return new Response<Product>()
                {
                    success = false,
                    statuscode = "500"
                    ,
                    message = ex.Message
                };
            }
        }
    }
}
