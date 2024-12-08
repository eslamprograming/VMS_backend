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
    public interface IProductRepo
    {
        Task<Response<Product>> CreateProduct(Product productVM,int Cat_Id);
        Task<Response<Product>> DeleteProduct(int Product_Id);
        Task<Response<Product>> GetAllProductInCategory(int Category_Id);
        Task<Response<Product>> UpdateProduct(int Product_Id,ProductVM productVM);
        Task<Response<Product>> GetProduct(int Product_Id);
        Task<Response<Product>> ProductAvailableToSell();
        Task<Response<Product>> AllProductNotInWarehouse();


    }
}
