using DAL.DBContext;
using DAL.Entities;
using DAL.IRepo;
using DAL.ModelVM;
using DAL.ModelVM.Sherad;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class SupplierRepo : ISupplier
    {
        private readonly ApplicationDBContext db;

        public SupplierRepo(ApplicationDBContext db)
        {
            this.db = db;
        }

        public async Task<Response<Supplier>> AddSupplier(PersonVM personVM)
        {
            try
            {
                Supplier supplier = new Supplier();
                supplier.Name = personVM.name;
                supplier.Phone = personVM.Phone;
                await db.Suppliers.AddAsync(supplier);
                await db.SaveChangesAsync();
                return new Response<Supplier>()
                {
                    success = true,
                    statuscode = "200"
                };
            }
            catch (Exception ex)
            {
                return new Response<Entities.Supplier>()
                {
                    success=false,
                    statuscode="500",
                    message=ex.Message
                };
            }
        }

        public async Task<Response<Supplier>> DeleteSupplier(int Supplier_Id)
        {
            try
            {
                var obj = await db.Suppliers.FindAsync(Supplier_Id);
                db.Suppliers.Remove(obj);
                await db.SaveChangesAsync();
                return new Response<Supplier>()
                {
                    success=true,
                    statuscode="200"
                };
            }
            catch (Exception ex)
            {
                return new Response<Supplier>()
                {
                    success=false,
                    statuscode="500",
                    message=ex.Message
                };
            }
        }

        public async Task<Response<Supplier>> GetAllSupplier(int GroupNumber)
        {
            try
            {
                int GroupCount = 0;
                if (GroupNumber == 1)
                {
                    GroupCount = (await db.Suppliers.CountAsync()/10) +1;
                }
                var sup = await db.Suppliers.Skip((GroupNumber - 1) * 10).Take(10).ToListAsync();
                return new Response<Supplier>()
                {
                    success = true,
                    statuscode = "200",
                    values=sup,
                    group=GroupNumber,
                    groups=GroupCount
                };
            }
            catch (Exception ex)
            {
                return new Response<Supplier>()
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }

        public async Task<Response<Supplier>> GetSupplier(int Supplier_Id)
        {
            try
            {
                var obj = await db.Suppliers.FindAsync(Supplier_Id);
                
                return new Response<Supplier>()
                {
                    success = true,
                    statuscode = "200",
                    Value=obj
                };
            }
            catch (Exception ex)
            {
                return new Response<Supplier>()
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }

        public async Task<Response<Supplier>> UpdateSupplier(int Supplier_Id, PersonVM personVM)
        {
            try
            {
                var obj = await db.Suppliers.FindAsync(Supplier_Id);
                obj.Name = personVM.name;
                obj.Phone = personVM.Phone;
                await db.SaveChangesAsync();
                return new Response<Supplier>()
                {
                    success = true,
                    statuscode = "200"
                };
            }
            catch (Exception ex)
            {
                return new Response<Supplier>()
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }
    }
}
