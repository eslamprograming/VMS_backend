using DAL.Entities;
using DAL.ModelVM.Sherad;
using DAL.ModelVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepo
{
    public interface IOrderRepo
    {
        Task<Response<Order>> CreateOrderAsync(OrderVM order);
        Task<Response<Order>> UpdateOrderAsync(int Order_ID,OrderVM order);
        Task<Response<Order>> DeleteOrderAsync(int Order_Id);
        Task<Response<Order>> GetOrderAsync(int Order_Id);
        Task<Response<Order>> GetAllOrderAsync();
    }
}
