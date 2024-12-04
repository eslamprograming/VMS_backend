using DAL.Entities;
using DAL.ModelVM.Sherad;
using DAL.Repo.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepo.IReports
{
    public interface IProductReportRepo
    {
        Task<Response<ProductReportsVM>> bestProductSell(); 
        Task<Response<Product>> ProductNotSell();
        Task<Response<Product>> bestCountProductInWarehouse();
        Task<Response<ProductReportsVM>> bestProductSellbetween(DateTime startdate,DateTime enddate);
        Task<Response<Product>> ProductNotSellbetween(DateTime startdate, DateTime enddate);

    }
}
