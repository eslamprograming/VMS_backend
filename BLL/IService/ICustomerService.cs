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
    public interface ICustomerService
    {
        Task<Response<Customer>> AddCustomerasync(CustomerVM customerVM);
        Task<Response<Customer>> UpdateCustomerasync(int CustomerId, CustomerVM customerVM);
        Task<Response<Customer>> DeleteCustomerasync(int CustomerId);
        Task<Response<Customer>> GetCustomerAsync(int CustomerId);
        Task<Response<Customer>> GetCustomerbyphoneAsync(string phoneNumber);
        Task<Response<Customer>> GetALLCustomerAsync();
    }
}
