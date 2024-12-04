using DAL.Entities;
using DAL.ModelVM.Sherad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepo.IReports
{
    public interface IWarehouseReportsRepo
    {
        Task<Response<Product>> GetAllProductInWarehouse(int Warehouse_Id);
    }
}
