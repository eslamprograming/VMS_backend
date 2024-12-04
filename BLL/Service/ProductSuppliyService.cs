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
    public class ProductSuppliyService : IProductSuppliyService
    {
        private readonly IProductSuppliy productSuppliy;

        public ProductSuppliyService(DAL.IRepo.IProductSuppliy productSuppliy)
        {
            this.productSuppliy = productSuppliy;
        }

        public async Task<Response<ProductSuppliy>> AddProductSuppliy(ProductSuppliyVM productSuppliyVM)
        {
            try
            {
                var result = await productSuppliy.CreateProductSuppliy(productSuppliyVM);
                return result;
            }
            catch (Exception ex)
            {
                return new Response<ProductSuppliy>()
                {
                    success=false,
                    statuscode="500",
                    message=ex.Message
                };
            }
        }

        public async Task<Response<ProductSuppliy>> PutProductInWarehouse(PutProductInWarehouse putProductInWarehouse)
        {
            var result = await productSuppliy.PutProductInWarehouse(putProductInWarehouse);
            return result;
        }
    }
}
