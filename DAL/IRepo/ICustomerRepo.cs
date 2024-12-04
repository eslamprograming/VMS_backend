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
    public interface ICustomerRepo
    {
        Task<Response<Customer>> AddCustomerasync(CustomerVM customerVM);
        Task<Response<Customer>> UpdateCustomerasync(int CustomerId,CustomerVM customerVM);
        Task<Response<Customer>> DeleteCustomerasync(int CustomerId);
        Task<Response<Customer>> GetCustomerAsync(int CustomerId);
        Task<Response<Customer>> GetALLCustomerAsync(int groupNumber);

    }
}
