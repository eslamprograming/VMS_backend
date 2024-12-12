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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DAL.Repo
{
    public class OrderRepo : IOrderRepo
    {
        private readonly ApplicationDBContext db;
        private readonly IConfiguration _configuration;

        public OrderRepo(ApplicationDBContext db, IConfiguration configuration)
        {
            this.db = db;
            this._configuration = configuration;
        }

        public async Task<Response<Order>> CreateOrderAsync(OrderVM order)
        {
            try
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                string transactionStatus = "";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("InsertOrder", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // إعداد المعاملات
                        command.Parameters.AddWithValue("@EmployeeID", order.EmployeeID);
                        command.Parameters.AddWithValue("@CustomerID", order.CustomerID);
                        command.Parameters.AddWithValue("@OrderPrice", order.price);

                        // تجهيز جدول البيانات
                        DataTable productAmountsTable = new DataTable();
                        productAmountsTable.Columns.Add("Product_Id", typeof(int));
                        productAmountsTable.Columns.Add("Amount", typeof(int));
                        productAmountsTable.Columns.Add("Product_Price", typeof(decimal));
                        productAmountsTable.Columns.Add("warehouse_Id", typeof(int));

                        foreach (var product in order.product_Amounts)
                        {
                            productAmountsTable.Rows.Add(product.product_Id, product.Amount,product.price,product.Warehouse);
                        }

                        // تمرير البيانات كـ Table-Valued Parameter
                        SqlParameter productAmountsParam = command.Parameters.AddWithValue("@ProductAmounts", productAmountsTable);
                        productAmountsParam.SqlDbType = SqlDbType.Structured;
                        productAmountsParam.TypeName = "ProductAmountType";

                        // تنفيذ Stored Procedure
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                transactionStatus = reader["TransactionStatus"].ToString();
                                if (transactionStatus == "Commit")
                                {
                                    return new Response<Order>()
                                    {
                                        success = true,
                                        statuscode = "201"
                                    };
                                }
                            }
                        }
                    }
                }
                return new Response<Order>()
                {
                    success=false,
                    statuscode="500",
                    message= transactionStatus
                };
            }
            catch (Exception ex)
            {
                return new Response<Order>()
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }

        public async Task<Response<Order>> DeleteOrderAsync(int Order_Id)
        {
            try
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                string transactionStatus = "";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("deleteOrder", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // إعداد المعاملات
                        command.Parameters.AddWithValue("@OrderId",Order_Id);
                        
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                transactionStatus = reader["TransactionStatus"].ToString();
                                if (transactionStatus == "commit")
                                {
                                    return new Response<Order>()
                                    {
                                        success = true,
                                        statuscode = "201"
                                    };
                                }
                            }
                        }
                    }
                }
                return new Response<Order>()
                {
                    success = false,
                    statuscode = "500",
                    message = transactionStatus
                };
            }
            catch (Exception ex)
            {
                return new Response<Order>()
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }

        public async Task<Response<Order>> GetAllOrderAsync(int groupNumber)
        {
            try
            {
                int groupCount = 0;
                if (groupNumber == 1)
                {
                    groupCount = (await db.Orders.CountAsync() / 10) + 1;
                }
                var Orders = await db.Orders
                                        .Skip((groupNumber - 1) * 10)
                                        .Take(10)
                                        .ToListAsync();

                return new Response<Order>()
                {
                    success = true,
                    statuscode = "200",
                    groups = groupCount,
                    group = groupNumber,
                    values = Orders
                };
            }
            catch (Exception ex)
            {
                return new Response<Order>()
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message,
                };
            }
        }

        public async Task<Response<Order>> GetOrderAsync(int Order_Id)
        {
            try
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                Order order = new Order();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("GetOrderById", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // إعداد المعاملات
                        command.Parameters.AddWithValue("@orderID", Order_Id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            int x = 0;
                            List<OrderDetails> orderDetails1 = new List<OrderDetails>();

                            while (reader.Read())
                            {
                                if (x == 0)
                                {
                                    order.Order_Id = reader.GetInt32(0);
                                    order.OrderDate = reader.GetDateTime(1);
                                    order.OrderPrice = reader.GetDecimal(2);
                                    Customer c = new Customer();
                                    c.Name = reader.GetString(12);
                                    c.Phone = reader.GetString(13);
                                    order.Customer = c;
                                    ApplicationUser E = new ApplicationUser();
                                    E.First_Name = reader.GetString(14);
                                    order.Employee = E;
                                }
                                Product product = new Product();
                                OrderDetails orderDetails = new OrderDetails();

                                product.Name = reader.GetString(6);
                                product.Product_Id = reader.GetInt32(5);
                                product.Price = reader.GetDecimal(8);
                                product.Description = reader.GetString(7);
                                product.Photo = reader.GetString(11);

                                orderDetails.OrderDetails_Id = reader.GetInt32(15);
                                orderDetails.Product = product;
                                orderDetails.ProductAmount = reader.GetInt32(4);
                                orderDetails.ProductAmountPrice = reader.GetDecimal(3);

                                orderDetails1.Add(orderDetails);

                                ++x;

                            }
                            order.orderDetails = orderDetails1;

                        }
                    }
                }
                return new Response<Order>()
                {
                    success = true,
                    statuscode = "201",
                    Value = order
                };
            }
            catch (Exception ex)
            {
                return new Response<Order>()
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }

        public Task<Response<Order>> UpdateOrderAsync(int Order_ID, OrderVM order)
        {
            throw new NotImplementedException();
        }
    }
}
