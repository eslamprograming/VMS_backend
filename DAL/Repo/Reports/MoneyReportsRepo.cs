using DAL.IRepo;
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
    public class MoneyReportsRepo:ImoneyReportsRepo
    {
        private readonly IConfiguration configuration;

        public MoneyReportsRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<Response<decimal>> NetProfitbetweenProc(DateTime startdate, DateTime enddate)
        {
            try
            {
                string connectionString = configuration.GetConnectionString("DefaultConnection");
                decimal value = 0;
                using(SqlConnection  connection = new SqlConnection(connectionString)) {
                    connection.Open();
                    using(SqlCommand command = new SqlCommand("NetProfitbetweenProc", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@startdate", startdate);
                        command.Parameters.AddWithValue("@enddate", enddate);
                        using (SqlDataReader reader = command.ExecuteReader()) { 
                            while(reader.Read()) {
                                value = reader.GetDecimal(0);              
                            }
                        }
                    }
                }
                return new Response<decimal>()
                {
                    success = true,
                    statuscode = "200",
                    Value=value
                };
            }
            catch (Exception ex)
            {
                return new Response<decimal>()
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }

        public async Task<Response<decimal>> NetProfitProc()
        {
            try
            {
                string connectionString = configuration.GetConnectionString("DefaultConnection");
                decimal value = 0;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("NetProfitProc", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                value = reader.GetDecimal(0);
                            }
                        }
                    }
                }
                return new Response<decimal>()
                {
                    success = true,
                    statuscode = "200",
                    Value = value
                };
            }
            catch (Exception ex)
            {
                return new Response<decimal>()
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }

        public async Task<Response<decimal>> NettotalOrderprice()
        {
            try
            {
                string connectionString = configuration.GetConnectionString("DefaultConnection");
                decimal value = 0;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("NettotalOrderprice", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                value = reader.GetDecimal(0);
                            }
                        }
                    }
                }
                return new Response<decimal>()
                {
                    success = true,
                    statuscode = "200",
                    Value = value
                };
            }
            catch (Exception ex)
            {
                return new Response<decimal>()
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }

        public async Task<Response<decimal>> NettotalOrderpricebetween(DateTime startdate, DateTime enddate)
        {
            try
            {
                string connectionString = configuration.GetConnectionString("DefaultConnection");
                decimal value = 0;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("NettotalOrderpricebetween", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@startdate", startdate);
                        command.Parameters.AddWithValue("@enddate", enddate);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                value = reader.GetDecimal(0);
                            }
                        }
                    }
                }
                return new Response<decimal>()
                {
                    success = true,
                    statuscode = "200",
                    Value = value
                };
            }
            catch (Exception ex)
            {
                return new Response<decimal>()
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }

        public async Task<Response<decimal>> NettotalSuppliyprice()
        {
            try
            {
                string connectionString = configuration.GetConnectionString("DefaultConnection");
                decimal value = 0;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("NettotalSuppliyprice", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                value = reader.GetDecimal(0);
                            }
                        }
                    }
                }
                return new Response<decimal>()
                {
                    success = true,
                    statuscode = "200",
                    Value = value
                };
            }
            catch (Exception ex)
            {
                return new Response<decimal>()
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }

        public async Task<Response<decimal>> NettotalSuppliypricebetween(DateTime startdate, DateTime enddate)
        {
            try
            {
                string connectionString = configuration.GetConnectionString("DefaultConnection");
                decimal value = 0;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("NettotalSuppliypricebetween", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@startdate", startdate);
                        command.Parameters.AddWithValue("@enddate", enddate);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                value = reader.GetDecimal(0);
                            }
                        }
                    }
                }
                return new Response<decimal>()
                {
                    success = true,
                    statuscode = "200",
                    Value = value
                };
            }
            catch (Exception ex)
            {
                return new Response<decimal>()
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }
    }
}
