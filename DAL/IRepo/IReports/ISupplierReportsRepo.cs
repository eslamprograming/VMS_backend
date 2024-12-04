using DAL.Entities;
using DAL.ModelVM.Sherad;
using DAL.Repo.Reports.ModelReportsVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepo.IReports
{
    public interface ISupplierReportsRepo
    {
        //TheBestSupplierGetMoney,TheBestSupplierGetMoneyBetween,
        //TheBestSupplierSuppliy,TheBestSupplierSuppliyBetween

        Task<Response<SupplierReportsVM>> TheBestSupplierGetMoney();
        Task<Response<SupplierReportsVM>> TheBestSupplierGetMoneyBetween(DateTime startdate,DateTime enddate);
        Task<Response<SupplierReportsVM>> TheBestSupplierSuppliy();
        Task<Response<SupplierReportsVM>> TheBestSupplierSuppliyBetween(DateTime startdate,DateTime enddate);

    }
}
