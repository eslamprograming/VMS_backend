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
    public class CustomerRepo : ICustomerRepo
    {
        private readonly ApplicationDBContext db;

        public CustomerRepo(ApplicationDBContext db)
        {
            this.db = db;
        }

        public async Task<Response<Customer>> AddCustomerasync(CustomerVM customerVM)
        {
            try
            {
                var result = db.Customers.Where(n => n.Phone == customerVM.Phone).ToListAsync();

                if (result != null)
                {
                    return new Response<Customer>()
                    {
                        success = false,
                        statuscode = "400",
                        message = "هذا التليفون موجود !"
                    };
                }

                Customer customer=new Customer();
                customer.Name = customerVM.Name;
                customer.Phone=customerVM.Phone;
                
                await db.Customers.AddAsync(customer);
                await db.SaveChangesAsync();

                return new Response<Customer>()
                {
                    success = true,
                    statuscode = "201",
                    Value =customer
                };
            }
            catch (Exception ex)
            {
                return new Response<Customer>()
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message,
                };
            }
        }

        public async Task<Response<Customer>> DeleteCustomerasync(int CustomerId)
        {
            try
            {
                var customer = await db.Customers.FindAsync(CustomerId);
                db.Customers.Remove(customer);
                await db.SaveChangesAsync();
                return new Response<Customer>()
                {
                    success = true,
                    statuscode="200"
                };
            }
            catch (Exception ex)
            {
                return new Response<Customer>()
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message,
                };
            }
        }

        public async Task<Response<Customer>> GetALLCustomerAsync(int groupNumber)
        {
            try
            {
                int groupCount = 0;
                if (groupNumber == 1)
                {
                    groupCount = (await db.Customers.CountAsync() / 10)+1;
                }
                var Customer = await db.Customers
                                        .Skip((groupNumber - 1) * 10)
                                        .Take(10)
                                        .ToListAsync();

                return new Response<Customer>()
                {
                    success = true,
                    statuscode = "200",
                    groups= groupCount,
                    group= groupNumber,
                    values=Customer
                };
            }
            catch (Exception ex)
            {
                return new Response<Customer>()
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message,
                };
            }
        }

        public async Task<Response<Customer>> GetCustomerAsync(int CustomerId)
        {
            try
            {
                var Customer = await db.Customers.FindAsync(CustomerId);
                return new Response<Customer>()
                {
                    success = true,
                    statuscode="200",
                    Value= Customer
                };
            }
            catch (Exception ex)
            {
                return new Response<Customer>()
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message,
                };
            }
        }
        public async Task<Response<Customer>> GetCustomerbyphoneAsync(string phoneNumber)
        {
            try
            {
                var Customer = await db.Customers.Where(n=>n.Phone==phoneNumber).ToListAsync();
                return new Response<Customer>()
                {
                    success = true,
                    statuscode = "200",
                    values = Customer
                };
            }
            catch (Exception ex)
            {
                return new Response<Customer>()
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message,
                };
            }
        }
        public async Task<Response<Customer>> UpdateCustomerasync(int CustomerId, CustomerVM customerVM)
        {
            try
            {
                var Customer = await db.Customers.FindAsync(CustomerId);
                Customer.Name= customerVM.Name;
                Customer.Phone= customerVM.Phone;
                await db.SaveChangesAsync();
                return new Response<Customer>()
                {
                    success = true,
                    statuscode = "200",
                    Value = Customer
                };
            }
            catch (Exception ex)
            {
                return new Response<Customer>()
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message,
                };
            }
        }
    }
}
