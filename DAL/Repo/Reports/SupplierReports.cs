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
    
    public class SupplierReports : ISupplierRepoerts
    {
        private readonly IConfiguration configuration;

        public SupplierReports(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<Response<ProductSupply>> GetSupplierProduct()
        {
            try
            {
                string ConnectionStrings = configuration.GetConnectionString("DefaultConnection");
                List<ProductSupply> ProductSupplier = new List<ProductSupply>();
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionStrings))
                {
                    // فتح الاتصال بشكل غير متزامن
                    await sqlConnection.OpenAsync();

                    using (SqlCommand sqlCommand = new SqlCommand("getAllSuppliyProduct", sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        // قراءة البيانات بشكل غير متزامن
                        using (SqlDataReader reader = await sqlCommand.ExecuteReaderAsync())
                        {
                            
                            while (await reader.ReadAsync())
                            {

                                ProductSupply PS = new ProductSupply()
                                {

                                    ProductSupply_Id = reader.GetInt32(reader.GetOrdinal("ProductSuppliy_Id")),
                                    SupplyDate = reader.GetDateTime(reader.GetOrdinal("DateTime")),
                                    ProductSupply_Price = reader.GetDecimal(reader.GetOrdinal("ProductSuppliy_Price")),
                                    Employee = reader["EmployeeName"].ToString(),
                                    Supplier = reader["Name"].ToString()
                                };
                                ProductSupplier.Add(PS);
                            }
                        }
                    }
                    return new Response<ProductSupply>()
                    {
                        success = true,
                        statuscode = "200",
                        values= ProductSupplier
                    };
                }
            }
            catch (Exception ex)
            {
                return new Response<ProductSupply>()
                {
                    success=false,
                    statuscode="500",
                    message=ex.Message
                };
            }
        }
    }
}
