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
    public interface ISupplierRepoerts
    {
        public Task<Response<ProductSupply>> GetSupplierProduct();
    }
}
