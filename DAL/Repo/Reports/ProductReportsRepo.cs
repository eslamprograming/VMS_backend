using DAL.Entities;
using DAL.IRepo.IReports;
using DAL.ModelVM.Sherad;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo.Reports
{
    public class ProductReportsRepo:IProductReportRepo
    {
        private readonly IConfiguration configuration;

        public ProductReportsRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<Response<Product>> bestCountProductInWarehouse()
        {
            try
            {
                string connectionString = configuration.GetConnectionString("DefaultConnection");
                List<Product> products = new List<Product>();
                using(SqlConnection sqlConnection= new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand command = new SqlCommand("bestCountProductInWarehouse", sqlConnection)) {
                        command.CommandType = CommandType.StoredProcedure;
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Product product = new Product();
                                product.Product_Id = reader.GetInt32(0);
                                product.Name = reader.GetString(1);
                                product.Description=reader.GetString(2);
                                product.Price = reader.GetDecimal(3);
                                product.ProductAmount = reader.GetInt32(4);
                                products.Add(product);
                            }
                        }
                    }
                }

                return new Response<Product>()
                {
                    success=true,
                    statuscode="200",
                    values=products
                };
            }
            catch (Exception ex)
            {
                return new Response<Product>()
                {
                    success=false,
                    message=ex.Message,
                    statuscode="500"
                };
            }
        }

        public async Task<Response<ProductReportsVM>> bestProductSell()
        {
            try
            {
                string connectionString = configuration.GetConnectionString("DefaultConnection");
                List<ProductReportsVM> products = new List<ProductReportsVM>();
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand command = new SqlCommand("bestProductSell", sqlConnection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ProductReportsVM product = new ProductReportsVM();
                                product.Product_Id = reader.GetInt32(0);
                                product.Name = reader.GetString(1);
                                product.ProductAmount = reader.GetInt32(2);
                                product.Price = reader.GetDecimal(3);
                                product.Total_Price = reader.GetDecimal(4);
                                products.Add(product);
                            }
                        }
                    }
                }
                return new Response<ProductReportsVM>()
                {
                    success = true,
                    statuscode = "200",
                    values=products
                };
            }
            catch (Exception ex)
            {
                return new Response<ProductReportsVM>()
                {
                    success = false,
                    message = ex.Message,
                    statuscode = "500"
                };
            }
        }

        public async Task<Response<ProductReportsVM>> bestProductSellbetween(DateTime startdate, DateTime enddate)
        {
            try
            {
                string connectionString = configuration.GetConnectionString("DefaultConnection");
                List<ProductReportsVM> products = new List<ProductReportsVM>();
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand command = new SqlCommand("bestProductSellbetween", sqlConnection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@startdate", startdate);
                        command.Parameters.AddWithValue("@enddate", enddate);


                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ProductReportsVM product = new ProductReportsVM();
                                product.Product_Id = reader.GetInt32(0);
                                product.Name = reader.GetString(1);
                                product.ProductAmount = reader.GetInt32(3);
                                product.Price = reader.GetDecimal(2);
                                product.Total_Price = reader.GetDecimal(4);
                                products.Add(product);
                            }
                        }
                    }
                }
                return new Response<ProductReportsVM>()
                {
                    success = true,
                    statuscode = "200",
                    values=products
                };
            }
            catch (Exception ex)
            {
                return new Response<ProductReportsVM>()
                {
                    success = false,
                    message = ex.Message,
                    statuscode = "500"
                };
            }
        }

        public async Task<Response<Product>> ProductNotSell()
        {
            try
            {
                string connectionString = configuration.GetConnectionString("DefaultConnection");
                List<Product> products = new List<Product>();
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand command = new SqlCommand("ProductNotSell", sqlConnection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Product product = new Product();
                                product.Product_Id = reader.GetInt32(0);
                                product.Name = reader.GetString(1);
                                product.ProductAmount = reader.GetInt32(4);
                                product.Price = reader.GetDecimal(3);
                                product.Description = reader.GetString(2);
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
            catch (Exception ex)
            {
                return new Response<Product>()
                {
                    success = false,
                    message = ex.Message,
                    statuscode = "500"
                };
            }
        }

        public async Task<Response<Product>> ProductNotSellbetween(DateTime startdate, DateTime enddate)
        {
            try
            {
                string connectionString = configuration.GetConnectionString("DefaultConnection");
                List<Product> products = new List<Product>();
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand command = new SqlCommand("getProductNotSellingbetweenTwoDate", sqlConnection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@startdate", startdate);
                        command.Parameters.AddWithValue("@enddate", enddate);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Product product = new Product();
                                product.Product_Id = reader.GetInt32(0);
                                product.Name = reader.GetString(1);
                                product.ProductAmount = reader.GetInt32(4);
                                product.Price = reader.GetDecimal(3);
                                product.Description = reader.GetString(2);
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
            catch (Exception ex)
            {
                return new Response<Product>()
                {
                    success = false,
                    message = ex.Message,
                    statuscode = "500"
                };
            }
        }
    }
}
