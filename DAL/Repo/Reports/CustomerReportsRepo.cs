using DAL.Entities;
using DAL.IRepo.IReports;
using DAL.ModelVM.Sherad;
using DAL.Repo.Reports.ModelReportsVM;
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
    public class CustomerReportsRepo : ICustomerReportsRepo
    {
        private readonly IConfiguration configuration;

        public CustomerReportsRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<Response<CustomerReportsVM>> ThebestCustomerGetOrder()
        {
            try
            {
                string connectionString = configuration.GetConnectionString("DefaultConnection");
                List<CustomerReportsVM> customerReportsVMs = new List<CustomerReportsVM>();
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand command = new SqlCommand("ThebestCustomerOrder", sqlConnection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerReportsVM C1 = new CustomerReportsVM();

                                C1.Customer_Id = reader.GetInt32(0);
                                C1.Name = reader.GetString(1);
                                C1.phone = reader.GetString(2);
                                C1.OrderCount= reader.GetInt32(3);
                                C1.totalOrderPrice = reader.GetDecimal(4);
                                customerReportsVMs.Add(C1);
                            }
                        }
                    }
                }
                return new Response<CustomerReportsVM>()
                {
                    success = true,
                    statuscode = "200",
                    values=customerReportsVMs
                };
            }
            catch (Exception ex)
            {
                return new Response<CustomerReportsVM>()
                {
                    success = false,
                    message = ex.Message,
                    statuscode = "500"
                };
            }
        }

        public async Task<Response<CustomerReportsVM>> ThebestCustomerPayed()
        {
            try
            {
                string connectionString = configuration.GetConnectionString("DefaultConnection");
                List<CustomerReportsVM> customerReportsVMs = new List<CustomerReportsVM>();
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand command = new SqlCommand("ThebestCustomerPayed", sqlConnection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerReportsVM C1 = new CustomerReportsVM();

                                C1.Customer_Id = reader.GetInt32(0);
                                C1.Name = reader.GetString(1);
                                C1.phone = reader.GetString(2);
                                C1.totalOrderPrice = reader.GetDecimal(3);
                                C1.OrderCount = reader.GetInt32(4);
                                customerReportsVMs.Add(C1);
                            }
                        }
                    }
                }
                return new Response<CustomerReportsVM>()
                {
                    success = true,
                    statuscode = "200",
                    values = customerReportsVMs
                };
            }
            catch (Exception ex)
            {
                return new Response<CustomerReportsVM>()
                {
                    success = false,
                    message = ex.Message,
                    statuscode = "500"
                };
            }
        }
    }
}
