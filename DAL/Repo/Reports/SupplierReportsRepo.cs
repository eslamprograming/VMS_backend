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
    public class SupplierReportsRepo:ISupplierReportsRepo
    {
        private readonly IConfiguration configuration;

        public SupplierReportsRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<Response<SupplierReportsVM>> TheBestSupplierGetMoney()
        {
            try
            {
                string connectionstrings = configuration.GetConnectionString("DefaultConnection");
                List<SupplierReportsVM> suppliers = new List<SupplierReportsVM>();
                using(SqlConnection connection=new SqlConnection(connectionstrings))
                {
                    connection.Open();
                    using(SqlCommand command=new SqlCommand("TheBestSupplierGetMoney", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        using(SqlDataReader  reader=command.ExecuteReader()) {
                            while (reader.Read())
                            {
                                SupplierReportsVM supplier = new SupplierReportsVM();
                                supplier.Supplier_Id = reader.GetInt32(0);
                                supplier.Name = reader.GetString(1);
                                supplier.Phone = reader.GetString(2);
                                supplier.total_Price = reader.GetDecimal(3);
                                suppliers.Add(supplier);
                            }
                        }
                    }
                }
                return new Response<SupplierReportsVM>()
                {
                    success=true,
                    statuscode="200",
                    values=suppliers
                };
            }
            catch (Exception ex)
            {
                return new Response<SupplierReportsVM>()
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }

        public async Task<Response<SupplierReportsVM>> TheBestSupplierGetMoneyBetween(DateTime startdate, DateTime enddate)
        {
            try
            {
                string connectionstrings = configuration.GetConnectionString("DefaultConnection");
                List<SupplierReportsVM> suppliers = new List<SupplierReportsVM>();
                using (SqlConnection connection = new SqlConnection(connectionstrings))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("TheBestSupplierGetMoneyBetween", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@startdate",startdate);
                        command.Parameters.AddWithValue("@enddate",enddate);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SupplierReportsVM supplier = new SupplierReportsVM();
                                supplier.Supplier_Id = reader.GetInt32(0);
                                supplier.Name = reader.GetString(1);
                                supplier.Phone = reader.GetString(2);
                                supplier.total_Price = reader.GetDecimal(3);
                                suppliers.Add(supplier);
                            }
                        }
                    }
                }
                return new Response<SupplierReportsVM>()
                {
                    success = true,
                    statuscode = "200",
                    values = suppliers
                };
            }
            catch (Exception ex)
            {
                return new Response<SupplierReportsVM>()
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }

        public async Task<Response<SupplierReportsVM>> TheBestSupplierSuppliy()
        {
            try
            {
                string connectionstrings = configuration.GetConnectionString("DefaultConnection");
                List<SupplierReportsVM> suppliers = new List<SupplierReportsVM>();
                using (SqlConnection connection = new SqlConnection(connectionstrings))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("TheBestSupplierSuppliy", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SupplierReportsVM supplier = new SupplierReportsVM();
                                supplier.Supplier_Id = reader.GetInt32(0);
                                supplier.Name = reader.GetString(1);
                                supplier.Phone = reader.GetString(2);
                                supplier.Count = reader.GetInt32(3);
                                supplier.total_Price = reader.GetDecimal(4);
                                suppliers.Add(supplier);
                            }
                        }
                    }
                }
                return new Response<SupplierReportsVM>()
                {
                    success = true,
                    statuscode = "200",
                    values = suppliers
                };
            }
            catch (Exception ex)
            {
                return new Response<SupplierReportsVM>()
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }

        public async Task<Response<SupplierReportsVM>> TheBestSupplierSuppliyBetween(DateTime startdate,DateTime enddate)
        {
            try
            {
                string connectionstrings = configuration.GetConnectionString("DefaultConnection");
                List<SupplierReportsVM> suppliers = new List<SupplierReportsVM>();
                using (SqlConnection connection = new SqlConnection(connectionstrings))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("TheBestSupplierSuppliyBetween", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@startdate",startdate);
                        command.Parameters.AddWithValue("@enddate",enddate);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SupplierReportsVM supplier = new SupplierReportsVM();
                                supplier.Supplier_Id = reader.GetInt32(0);
                                supplier.Name = reader.GetString(1);
                                supplier.Phone = reader.GetString(2);
                                supplier.Count = reader.GetInt32(3);
                                supplier.total_Price = reader.GetDecimal(4);
                                suppliers.Add(supplier);
                            }
                        }
                    }
                }
                return new Response<SupplierReportsVM>()
                {
                    success = true,
                    statuscode = "200",
                    values = suppliers
                };
            }
            catch (Exception ex)
            {
                return new Response<SupplierReportsVM>()
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }
    }
}
