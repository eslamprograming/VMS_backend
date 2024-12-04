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
    public class WarehouseService:IWarehouseService
    {
        private readonly IWarehouseRepo warehouseRepo;

        public WarehouseService(IWarehouseRepo warehouseRepo)
        {
            this.warehouseRepo = warehouseRepo;
        }

        public async Task<Response<Warehouse>> CreateWarehouse(WarehouseVM warehouseVM)
        {
            var result = await warehouseRepo.CreateWarehouse(warehouseVM);
            return result;
        }

        public async Task<Response<Warehouse>> DeleteWarehouse(int warehouse_Id)
        {
            var result = await warehouseRepo.DeleteWarehouse(warehouse_Id);
            return result;
        }

        public async Task<Response<Warehouse>> GetAllWarehouse(int GroupNumber)
        {
            var result = await warehouseRepo.GetAllWarehouse(GroupNumber);
            return result;
        }

        public async Task<Response<Warehouse>> GetWarehouse(int Warehouse_Id)
        {
            var result = await warehouseRepo.GetWarehouse(Warehouse_Id);
            return result;
        }

        public async Task<Response<DAL.ModelVM.ProductWarehouse2>> GetWarehouseInProduct(int Product_Id)
        {
            var result = await warehouseRepo.GetWarehouseInProduct(Product_Id);
            return result;
        }

        public async Task<Response<Warehouse>> UpdateWarehouse(int Warehouse_Id, WarehouseVM warehouseVM)
        {
            var result = await warehouseRepo.UpdateWarehouse(Warehouse_Id,warehouseVM);
            return result;
        }
    }
}
