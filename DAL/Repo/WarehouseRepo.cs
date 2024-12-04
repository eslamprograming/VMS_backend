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
    public class WarehouseRepo:IWarehouseRepo
    {
        private readonly ApplicationDBContext db;
        private readonly IConfiguration configuration;
        public WarehouseRepo(ApplicationDBContext db, IConfiguration configuration)
        {
            this.db = db;
            this.configuration = configuration;
        }

        public async Task<Response<Warehouse>> CreateWarehouse(WarehouseVM warehouseVM)
        {
            try
            {
                Warehouse warehouse = new Warehouse();
                warehouse.Name = warehouseVM.Name;
                warehouse.Location = warehouseVM.Location;
                warehouse.Capacaty = warehouseVM.Capacity;
                await db.Warehouse.AddAsync(warehouse);
                await db.SaveChangesAsync();
                return new Response<Warehouse>()
                {
                    success = true,
                    statuscode = "200"
                };
            }
            catch (Exception ex)
            {
                return new Response<Warehouse>()
                {
                    success=false,
                    statuscode="500",
                    message=ex.Message
                };
            }
        }

        public async Task<Response<Warehouse>> DeleteWarehouse(int warehouse_Id)
        {
            try
            {
                var result = await db.Warehouse.FindAsync(warehouse_Id);
                db.Warehouse.Remove(result);
                await db.SaveChangesAsync();
                return new Response<Warehouse>()
                {
                    success = true,
                    statuscode = "200"
                };
            }
            catch (Exception ex)
            {
                return new Response<Warehouse>()
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }

        public async Task<Response<Warehouse>> GetAllWarehouse(int GroupNumber)
        {
            try
            {
                int groub = 0;
                if(GroupNumber ==1)
                {
                    groub = (await db.Warehouse.CountAsync() / 10) + 1;
                }
                var result = await db.Warehouse.Skip((GroupNumber - 1) * 10).Take(10).ToListAsync();
                return new Response<Warehouse>()
                {
                    success = true,
                    statuscode = "200",
                    values=result
                };
            }
            catch (Exception ex)
            {
                return new Response<Warehouse>()
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }

        public async Task<Response<Warehouse>> GetWarehouse(int Warehouse_Id)
        {
            try
            {
                var result = await db.Warehouse.FindAsync(Warehouse_Id);
                return new Response<Warehouse>()
                {
                    success = true,
                    statuscode = "200",
                    Value=result
                };
            }
            catch (Exception ex)
            {
                return new Response<Warehouse>()
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }

        public async Task<Response<DAL.ModelVM.ProductWarehouse2>> GetWarehouseInProduct(int Product_Id)
        {
            try
            {

                string ConnectionString = configuration.GetConnectionString("DefaultConnection");
                List<DAL.ModelVM.ProductWarehouse2> warehouses = new List<DAL.ModelVM.ProductWarehouse2>();

                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    await sqlConnection.OpenAsync();
                    using(SqlCommand sqlCommand=new SqlCommand("GetAllWarehouseForProduct", sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@product_Id", Product_Id);

                        using(SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            while(await reader.ReadAsync())
                            {
                                DAL.ModelVM.ProductWarehouse2 warehouse = new DAL.ModelVM.ProductWarehouse2();
                                warehouse.Warehouse_Id = reader.GetInt32(0);
                                warehouse.Name = reader.GetString(1);
                                warehouse.Location = reader.GetString(2);
                                warehouse.Capacaty = reader.GetDecimal(3);
                                warehouse.Amount = reader.GetInt32(4);
                                warehouses.Add(warehouse);
                            }

                        }
                    }
                }
                return new Response<DAL.ModelVM.ProductWarehouse2>()
                {
                    success=true,
                    statuscode="200",
                    values= warehouses
                };
            }
            catch (Exception ex)
            {
                return new Response<DAL.ModelVM.ProductWarehouse2>()
                {
                    success=false,
                    statuscode="500",
                    message=ex.Message
                };
            }
        }

        public async Task<Response<Warehouse>> UpdateWarehouse(int Warehouse_Id, WarehouseVM warehouseVM)
        {
            try
            {
                var result = await db.Warehouse.FindAsync(Warehouse_Id);
                result.Name = warehouseVM.Name;
                result.Location = warehouseVM.Location;
                result.Capacaty = warehouseVM.Capacity;
                await db.SaveChangesAsync();
                return new Response<Warehouse>()
                {
                    success = true,
                    statuscode = "200"
                };
            }
            catch (Exception ex)
            {
                return new Response<Warehouse>()
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }
    }
}
