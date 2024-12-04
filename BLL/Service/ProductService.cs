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
    public class ProductService:IProductService
    {
        private readonly IProductRepo productRepo;

        public ProductService(IProductRepo productRepo)
        {
            this.productRepo = productRepo;
        }

        public async Task<Response<Product>> AllProductNotInWarehouse()
        {
            var result = await productRepo.AllProductNotInWarehouse();
            return result;
        }

        public async Task<Response<Product>> CreateProduct(ProductVM productVM)
        {
            var result= await productRepo.CreateProduct(productVM);
            return result;
        }

        public async Task<Response<Product>> DeleteProduct(int Product_Id)
        {
            var result = await productRepo.DeleteProduct(Product_Id);
            return result;
        }

        public async Task<Response<Product>> GetAllProductInCategory(int Category_Id)
        {
            var result = await productRepo.GetAllProductInCategory(Category_Id);
            return result;
        }

        public async Task<Response<Product>> GetProduct(int Product_Id)
        {
            var result = await productRepo.GetProduct(Product_Id);
            return result;
        }

        public async Task<Response<Product>> ProductAvailableToSell()
        {
            var result = await productRepo.ProductAvailableToSell();
            return result;
        }

        public async Task<Response<Product>> UpdateProduct(int Product_Id, ProductVM productVM)
        {
            var result = await productRepo.UpdateProduct(Product_Id,productVM);
            return result;
        }
    }
}
