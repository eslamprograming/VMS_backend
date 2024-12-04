using DAL.Entities;
using DAL.ModelVM;
using DAL.ModelVM.Sherad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IService
{
    public interface IOrderService
    {
        Task<Response<Order>> CreateOrder(OrderVM order);
        Task<Response<Order>> UpdateOrderAsync(int Order_ID, OrderVM order);
        Task<Response<Order>> DeleteOrderAsync(int Order_Id);
        Task<Response<Order>> GetOrderAsync(int Order_Id);
        Task<Response<Order>> GetAllOrderAsync();
    }
}
