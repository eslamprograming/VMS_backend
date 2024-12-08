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
    public interface IProductService
    {
        Task<Response<Product>> CreateProduct(ProductVM productVM);
        Task<Response<Product>> DeleteProduct(int Product_Id);
        Task<Response<Product>> GetAllProductInCategory(int Category_Id);
        Task<Response<Product>> GetAllProduct();
        Task<Response<Product>> UpdateProduct(int Product_Id, ProductVM productVM);
        Task<Response<Product>> GetProduct(int Product_Id);
        Task<Response<Product>> ProductAvailableToSell();
        Task<Response<Product>> AllProductNotInWarehouse();

    }
}
