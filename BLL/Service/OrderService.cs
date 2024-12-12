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
    public class OrderService : IOrderService
    {
        private readonly IOrderRepo orderRepo;

        public OrderService(IOrderRepo orderRepo)
        {
            this.orderRepo = orderRepo;
        }

        public async Task<Response<Order>> CreateOrder(OrderVM order)
        {
            try
            {
                var result= await orderRepo.CreateOrderAsync(order);
                return result;
            }
            catch (Exception ex)
            {

                return new Response<Order>
                {
                    success=false,
                    statuscode="500"
                };
            }
        }

        public async Task<Response<Order>> DeleteOrderAsync(int Order_Id)
        {
            var result = await orderRepo.DeleteOrderAsync(Order_Id);
            return result;
        }

        public async Task<Response<Order>> GetAllOrderAsync(int groupNumber)
        {
            var result = await orderRepo.GetAllOrderAsync(groupNumber);
            return result;
        }

        public async Task<Response<Order>> GetOrderAsync(int Order_Id)
        {
            var result = await orderRepo.GetOrderAsync(Order_Id);
            return result;
        }

        public Task<Response<Order>> UpdateOrderAsync(int Order_ID, OrderVM order)
        {
            throw new NotImplementedException();
        }
    }
}
