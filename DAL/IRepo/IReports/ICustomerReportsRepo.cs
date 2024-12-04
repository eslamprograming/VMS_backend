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
    public interface ICustomerReportsRepo
    {
        Task<Response<CustomerReportsVM>> ThebestCustomerGetOrder();
        Task<Response<CustomerReportsVM>> ThebestCustomerPayed();

    }
}
