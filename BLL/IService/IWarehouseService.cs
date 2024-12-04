using DAL.Entities;
using DAL.ModelVM.Sherad;
using DAL.ModelVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IService
{
    public interface IWarehouseService
    {
        Task<Response<Warehouse>> CreateWarehouse(WarehouseVM warehouseVM);
        Task<Response<Warehouse>> DeleteWarehouse(int warehouse_Id);
        Task<Response<Warehouse>> GetAllWarehouse(int GroupNumber);
        Task<Response<Warehouse>> GetWarehouse(int Warehouse_Id);
        Task<Response<DAL.ModelVM.ProductWarehouse2>> GetWarehouseInProduct(int Product_Id);
        Task<Response<Warehouse>> UpdateWarehouse(int Warehouse_Id, WarehouseVM warehouseVM);

    }
}
