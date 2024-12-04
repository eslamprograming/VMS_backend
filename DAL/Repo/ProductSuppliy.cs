using DAL.Entities;
using DAL.IRepo;
using DAL.ModelVM;
using DAL.ModelVM.Sherad;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class ProductSuppliy : IProductSuppliy
    {
        private readonly IConfiguration configuration;

        public ProductSuppliy(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<Response<Entities.ProductSuppliy>> CreateProductSuppliy(ProductSuppliyVM productSuppliyVM)
        {
            try
            {
                string ConnectionStirngs = configuration.GetConnectionString("DefaultConnection");
                using (SqlConnection sqlConnection=new SqlConnection(ConnectionStirngs))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("InsertProductSuppliy", sqlConnection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@EmployeeId", productSuppliyVM.EmployeeID);
                    sqlCommand.Parameters.AddWithValue("@SuppliyerId", productSuppliyVM.SupplierID);
                    sqlCommand.Parameters.AddWithValue("@ProductSuppliy_Price", productSuppliyVM.price);

                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("Product_Id",typeof(int));
                    dataTable.Columns.Add("Product_Amount", typeof(int));
                    dataTable.Columns.Add("Product_Price", typeof(decimal));

                    foreach (var item in productSuppliyVM.product_Amounts)
                    {
                        dataTable.Rows.Add(item.product_Id,item.Amount,item.price);
                    }
                    SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("@ProductAmounts", dataTable);
                    sqlParameter.SqlDbType = SqlDbType.Structured;
                    sqlParameter.TypeName = "productSuppliytable";

                    sqlCommand.ExecuteNonQueryAsync();


                }
                return new Response<Entities.ProductSuppliy>()
                {
                    success=true,
                    statuscode="200"
                };
            }
            catch (Exception ex)
            {
                return new Response<Entities.ProductSuppliy>()
                {
                    success=false,
                    statuscode="500",
                    message=ex.Message
                };
            }
        }

        public async Task<Response<Entities.ProductSuppliy>> PutProductInWarehouse(PutProductInWarehouse putProductInWarehouse)
        {
            try
            {
                string ConnectionStirngs = configuration.GetConnectionString("DefaultConnection");
                using (SqlConnection sqlConnection=new SqlConnection(ConnectionStirngs))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("PutProductInWarehouse", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@product_Id", putProductInWarehouse.product_Id);
                    sqlCommand.Parameters.AddWithValue("@warehouse_Id", putProductInWarehouse.Warehouse_Id);
                    sqlCommand.Parameters.AddWithValue("@amount", putProductInWarehouse.Amount);
                    await sqlCommand.ExecuteNonQueryAsync();
                }
                return new Response<Entities.ProductSuppliy>()
                {
                    success = true,
                    statuscode = "200"
                };
            }
            catch (Exception ex)
            {
                return new Response<Entities.ProductSuppliy>()
                {
                    success=false,
                    statuscode="500",
                    message=ex.Message
                };
            }
        }
    }
}
