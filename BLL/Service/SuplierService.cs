using BLL.IService;
using DAL.Entities;
using DAL.IRepo;
using DAL.ModelVM;
using DAL.ModelVM.Sherad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class SuplierService : ISupplicerService
    {
        private readonly ISupplier supplier;

        public SuplierService(ISupplier supplier)
        {
            this.supplier = supplier;
        }

        public async Task<Response<Supplier>> AddSupplier(PersonVM personVM)
        {
            try
            {
                var result = await supplier.AddSupplier(personVM);
                return result;
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

        public async Task<Response<Supplier>> DeleteSupplier(int Supplier_Id)
        {
            var result = await supplier.DeleteSupplier(Supplier_Id);
            return result;
        }

        public async Task<Response<Supplier>> GetAllSupplier(int GroupNumber)
        {
            var result = await supplier.GetAllSupplier(GroupNumber);
            return result;
        }

        public async Task<Response<Supplier>> GetSupplier(int Supplier_Id)
        {
            
            var result = await supplier.GetSupplier(Supplier_Id);
            return result;
        }

        public async Task<Response<Supplier>> UpdateSupplier(int Supplier_Id, PersonVM personVM)
        {
            var result = await supplier.UpdateSupplier(Supplier_Id,personVM);
            return result;
        }
    }
}
