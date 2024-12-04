using DAL.Entities;
using DAL.ModelVM;
using DAL.ModelVM.Sherad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepo
{
    public interface ISupplier
    {
        Task<Response<Supplier>> AddSupplier(PersonVM personVM);
        Task<Response<Supplier>> DeleteSupplier(int Supplier_Id);
        Task<Response<Supplier>> UpdateSupplier(int Supplier_Id,PersonVM personVM);
        Task<Response<Supplier>> GetAllSupplier(int GroupNumber);
        Task<Response<Supplier>> GetSupplier(int Supplier_Id);
    }
}
