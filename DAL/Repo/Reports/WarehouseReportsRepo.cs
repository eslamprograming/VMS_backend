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
    public class WarehouseReportsRepo : IWarehouseReportsRepo
    {
        private readonly IConfiguration configuration;

        public WarehouseReportsRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<Response<Product>> GetAllProductInWarehouse(int Warehouse_Id)
        {
            try
            {
                string connectionstrings = configuration.GetConnectionString("DefaultConnection");
                List<Product> products = new List<Product>();
                using(SqlConnection sqlConnection = new SqlConnection(connectionstrings))
                {
                    sqlConnection.Open();
                    using(SqlCommand command= new SqlCommand("getAllProductInWarehouse", sqlConnection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@WarehouseId", Warehouse_Id);
                        using(SqlDataReader  reader = command.ExecuteReader()) {
                            while (reader.Read())
                            {
                                Product p = new Product();
                                p.Product_Id = reader.GetInt32(0);
                                p.Name = reader.GetString(1);
                                p.Description = reader.GetString(2);
                                p.Price = reader.GetDecimal(3);
                                p.ProductAmount = reader.GetInt32(7);
                                products.Add(p);
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
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }
    }
}
