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
    public interface IProductSuppliy
    {
        Task<Response<ProductSuppliy>> CreateProductSuppliy(ProductSuppliyVM productSuppliyVM);
        Task<Response<ProductSuppliy>> PutProductInWarehouse(PutProductInWarehouse putProductInWarehouse);
    }
}
